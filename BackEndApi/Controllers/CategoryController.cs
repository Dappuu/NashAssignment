using BackEndApi.Helpers;
using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using ViewModels.Category;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> GetAllCategory()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categories = await _unitOfWork.CategoryRepository.GetAll(includeProperties: "Products");
            var categoriesProductDto = categories.Where(c => !c.SubCategories.Any()).Select(c => c.ToCategoryDto());
            return Ok(categoriesProductDto);
        }
        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        // POST api/<Category>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryModel = categoryDto.ToCategoryFromCreateDto();
            await _unitOfWork.CategoryRepository.Insert(categoryModel);
            await _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new {id = categoryModel.Id}, categoryModel.ToCategoryDto());
        }

        // PUT api/<Category>/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] UpdateRequestCategoryDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _unitOfWork.CategoryRepository.GetByID(id);
            category.Name = updatedDto.Name;

            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.Save();
            return Ok(category.ToCategoryDto());
        }

        // DELETE api/<Category>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _unitOfWork.CategoryRepository.GetByID(id);
            
            if (category is null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Delete(category);
            try
            {
                await _unitOfWork.Save();
            }
            catch
            {
                return BadRequest("Cannot delete the parent Category!");
            }
            return NoContent();
        }
    }
}
