using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ProductSku;

namespace BackEndApi.Controllers
{
    [Route("api/productSku")]
    [ApiController]
    public class ProductSkuController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductSkuController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productSku = await _unitOfWork.ProductSkuRepository.GetByID(id);
            if (productSku is null)
            {
                return NotFound();
            }
            return Ok(productSku.ToProductSkuDto());
        }
        //POST api/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestProductskuDto productSkuDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productSkuModel = productSkuDto.ToProductSkuFromCreateDto();
            var product = await _unitOfWork.ProductRepository.GetInfoProduct(productSkuModel.ProductId);
            if (product is null)
            {
                return NotFound("Not Found The Product Of ProductSku");
            }
			if (product.productSkus == null)
			{
				product.productSkus = new List<ProductSku>();
			}
			product.productSkus.Add(productSkuModel);
			product.UnitsInStock = product.productSkus.Sum(p => p.UnitsInStock);
			try
			{
				await _unitOfWork.ProductSkuRepository.Insert(productSkuModel);
				_unitOfWork.ProductRepository.Update(product);
				await _unitOfWork.Save();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex);
			};
            return CreatedAtAction(nameof(GetById), new { id = productSkuModel.Id }, productSkuModel.ToProductSkuDto());
        }
    }
}
