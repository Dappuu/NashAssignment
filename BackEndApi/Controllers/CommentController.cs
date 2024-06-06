using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Category;
using ViewModels.Comment;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        // GET: api/comment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _unitOfWork.CommentRepository.GetAll(includeProperties: "User");
            var commentsDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentsDto);
        }
		[HttpGet("product/{productId:int}")]
		public async Task<IActionResult> GetByProductId([FromRoute] int productId)
        {
			var comments = await _unitOfWork.CommentRepository.GetAll(includeProperties: "User", filter: c => c.ProductId == productId);
			var commentsDto = comments.Select(c => c.ToCommentDto());
			return Ok(commentsDto);
		}
		// GET api/comment/5
		[HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            if (comment is null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
		// POST api/comment
		[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productModel = await _unitOfWork.ProductRepository.GetInfoProduct(commentDto.ProductId);
            if (productModel is null)
            {
                return NotFound("Product of comment Not Found.");
            }
            var commentModel = commentDto.ToCommentFromCreateDto();
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim is null)
            {
                return Unauthorized("User is not authorized.");
            }
            var userId = userIdClaim.Value.ToString();
			if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid UserId");
            }
            commentModel.UserId = userId;
            await _unitOfWork.CommentRepository.Insert(commentModel);
			if (productModel.Comments == null)
			{
				productModel.Comments = new List<Comment>();
			}
			productModel.Rating = productModel.Comments.Average(p => p.Rating);
			_unitOfWork.ProductRepository.Update(productModel);
			try
			{
				await _unitOfWork.Save();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			}
			return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        //// PUT api/category/5
        //[HttpPut]
        //[Route("{id:int}")]
        //public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateRequestCategoryDto updatedDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var category = await _unitOfWork.CategoryRepository.GetByID(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    category.Name = updatedDto.Name;
        //    _unitOfWork.CategoryRepository.Update(category);
        //    await _unitOfWork.Save();
        //    return Ok(category.ToCategoryDto());
        //}

        //// DELETE api/category/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

        //    if (category is null)
        //    {
        //        return NotFound("Category not found.");
        //    }

        //    if (category.SubCategories is not null && category.SubCategories.Any())
        //    {
        //        return BadRequest("Cannot delete category because it is linked to subcategories.");
        //    }
        //    try
        //    {
        //        _unitOfWork.CategoryRepository.Delete(category);
        //        await _unitOfWork.Save();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { Message = "An error occurred while deleting the category.", Details = ex.Message });
        //    }
        //    return NoContent();
        //}
    }
}
