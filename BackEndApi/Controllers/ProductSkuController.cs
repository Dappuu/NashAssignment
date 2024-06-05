using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Category;
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
        // GET api/productSku/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var productSku = await _unitOfWork.ProductSkuRepository.GetInfoProductSku(id);
            if (productSku is null)
            {
                return NotFound();
            }
            return Ok(productSku.ToProductSkuDto());
        }
        //POST api/productSku
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestProductskuDto productSkuDto)
        {
            var productSkuModel = productSkuDto.ToProductSkuFromCreateDto();
            var product = await _unitOfWork.ProductRepository.GetInfoProduct(productSkuModel.ProductId);
            if (product is null)
            {
                return NotFound("Not Found The Product Of ProductSku");
            }
            var productSkus = await _unitOfWork.ProductSkuRepository.GetAll();
            if (productSkus.Any(c => c.ProductId == productSkuModel.ProductId && c.SizeId == productSkuModel.SizeId))
            {
                return BadRequest("ProductSku Already Exists.");
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
        // PUT api/productSku/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateRequestProductSkuDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productSku = await _unitOfWork.ProductSkuRepository.GetInfoProductSku(id);
            if (productSku == null)
            {
                return NotFound();
            }
            productSku.SizeId = updatedDto.SizeId;
            productSku.UnitsInStock = updatedDto.UnitsInStock;
            _unitOfWork.ProductSkuRepository.Update(productSku);

            var product = await _unitOfWork.ProductRepository.GetInfoProduct(productSku.ProductId);
            product!.UnitsInStock = product.productSkus!.Sum(p => p.UnitsInStock);
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();
            return Ok(productSku.ToProductSkuDto());
        }
        // DELETE api/productSku/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var productSku = await _unitOfWork.ProductSkuRepository.GetByID(id);

            if (productSku is null)
            {
                return NotFound("ProductSku not found.");
            }
            try
            {
                _unitOfWork.ProductSkuRepository.Delete(productSku);
                var product = await _unitOfWork.ProductRepository.GetInfoProduct(productSku.ProductId);
                product!.UnitsInStock = product.productSkus!.Sum(p => p.UnitsInStock);
                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting productSku.", Details = ex.Message });
            }
            return NoContent();
        }
    }
}
