using BackEndApi.Helpers;
using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Linq.Expressions;
using ViewModels.Category;
using ViewModels.Product;

namespace BackEndApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            Expression<Func<Product, bool>> filter = null!;
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null!;
            if (!(string.IsNullOrWhiteSpace(query.Name)))
            {
                filter = c => c.Name.Contains(query.Name);
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                orderBy = query.SortBy switch
                {
                    var sort when sort.Equals("Name", StringComparison.OrdinalIgnoreCase) =>
                        query.IsDescending ? c => c.OrderByDescending(c => c.Name) : c => c.OrderBy(c => c.Name),
                    var sort when sort.Equals("Price", StringComparison.OrdinalIgnoreCase) =>
                        query.IsDescending ? c => c.OrderByDescending(c => c.Price) : c => c.OrderBy(c => c.Price),
                    var sort when sort.Equals("UnitsSold", StringComparison.OrdinalIgnoreCase) =>
                        query.IsDescending ? c => c.OrderByDescending(c => c.UnitsSold) : c => c.OrderBy(c => c.UnitsSold),
					var sort when sort.Equals("CreatedDate", StringComparison.OrdinalIgnoreCase) =>
					    query.IsDescending ? c => c.OrderByDescending(c => c.CreatedDate) : c => c.OrderBy(c => c.CreatedDate),
					var sort when sort.Equals("UpdatedDate", StringComparison.OrdinalIgnoreCase) =>
					query.IsDescending ? c => c.OrderByDescending(c => c.UpdatedDate) : c => c.OrderBy(c => c.UpdatedDate),
					_ => orderBy
                };
            }
            var products = await _unitOfWork.ProductRepository.GetAll(filter, orderBy, includeProperties: "Category");
            var productDto = products.Select(c => c.ToProductDto());
            return Ok(productDto);
        }
        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _unitOfWork.ProductRepository.GetInfoProduct(id);
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        //POST api/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productModel = productDto.ToProductFromCreateDto();
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(productModel.CategoryId);
            if (category is null)
            {
                return NotFound("Not Found The Category Of Product");
            }
            if (category.SubCategories is not null && category.SubCategories.Any())
            {
                return BadRequest("Cannot Add Product To Parent Category");
            }
            await _unitOfWork.ProductRepository.Insert(productModel);
            await _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = productModel.Id }, productModel.ToProductDto());
        }

        // PUT api/product/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateRequestProductDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _unitOfWork.ProductRepository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedDto.Name;
            product.ProductSkuName = updatedDto.ProductSkuName;
            product.Description = updatedDto.Description;
            product.Material = updatedDto.Material;
            product.Price = updatedDto.Price;
            product.Discount = updatedDto.Discount;
            product.ImageUrl = updatedDto.ImageUrl;
            product.Active = updatedDto.Active;
            product.UpdatedDate = DateTime.Now;
            
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();
            return Ok(product.ToProductDto());
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _unitOfWork.ProductRepository.GetByID(id);

            if (product is null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Delete(product);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting Product.", Details = ex.Message });
            }
            return NoContent();
        }
    }
}
