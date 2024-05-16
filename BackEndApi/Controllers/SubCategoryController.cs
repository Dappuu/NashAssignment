using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.SubCatgegory;

namespace BackEndApi.Controllers
{
    [ApiController]
    [Route("api/subcategory")]
    public class SubCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoryController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        // GET: api/subcategory
        [HttpGet]
        public async Task<IActionResult> GetAllSubCategory()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categories = await _unitOfWork.CategoryRepository.GetAll(includeProperties: "SubCategories");
            var categoriesSubDto = categories.Where(c => c.SubCategories.Any()).Select(c => c.ToSubCategoryDto());
            return Ok(categoriesSubDto);
        }
        // GET api/subcategory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSub([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _unitOfWork.CategoryRepository.GetByIdSubAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            return Ok(category.ToSubCategoryDto());
        }
        // POST api/subcategory
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestSubCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryModel = categoryDto.ToSubCategoryFromCreateDto();
            await _unitOfWork.CategoryRepository.Insert(categoryModel);
            await _unitOfWork.Save();
            return CreatedAtAction(nameof(GetByIdSub), new { id = categoryModel.Id }, categoryModel.ToSubCategoryDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateRequestSubCategoryDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _unitOfWork.CategoryRepository.GetByID(id);
            category.Name = updatedDto.Name;
            category.ParentId = updatedDto.ParentId;
            await _unitOfWork.Save();
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Update(category);
            return Ok(category.ToCategoryDto());
        }
    }
}
