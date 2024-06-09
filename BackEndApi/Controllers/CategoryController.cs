using BackEndApi.Helpers;
using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using ViewModels.Category;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAll(includeProperties: "SubCategories");
			var categoriesProductDto = categories.Where(c => c.ParentId is null).Select(c => c.ToCategoryDto()).ToList();
			return Ok(categoriesProductDto);
        }
        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        // POST api/category
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestCategoryDto categoryDto)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var categoryModel = categoryDto.ToCategoryFromCreateDto();
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            var existed = categories.Any(c => c.Name.ToLower() == categoryModel.Name.ToLower());
            if (existed)
            {
                return BadRequest("Category Already Exist.");
            }
            await _unitOfWork.CategoryRepository.Insert(categoryModel);
            await _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());
        }

        // PUT api/category/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateRequestCategoryDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _unitOfWork.CategoryRepository.GetByID(id);
            if (category == null)
            {
                return NotFound();
            }
            category.Name = updatedDto.Name;
            category.Description = updatedDto.Description;
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.Save();
            return Ok(category.ToCategoryDto());
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

            if (category is null)
            {
                return NotFound("Category not found.");
            }
            if (category.SubCategories is not null && category.SubCategories.Any())
            {
                return BadRequest("Cannot delete category because it is linked to subcategories.");
            }
			try
			{
				_unitOfWork.CategoryRepository.Delete(category);
				await _unitOfWork.Save();
			}
			catch (Exception ex)
			{
                return StatusCode(500, new { Message = "An error occurred while deleting category.", Details = ex.Message });
			}
			return NoContent();
        }
    }
}
