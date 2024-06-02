using BackEndApi.Interfaces;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Category;
using ViewModels.ProductSku;
using ViewModels.Size;

namespace BackEndApi.Controllers
{
    [Route("api/size")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SizeController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        // GET: api/size
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sizes = await _unitOfWork.SizeRepository.GetAll();
            var sizesDto = sizes.Select(s => s.ToSizeDto());
            return Ok(sizesDto);
        }
        // GET: api/size/4
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var size = await _unitOfWork.SizeRepository.GetByID(id);
            if (size is null)
            {
                return NotFound();
            }
            return Ok(size.ToSizeDto());
        }
        //POST api/size
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRequestSizeDto sizeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sizeModel = sizeDto.ToSizeFromCreateDto();
            var sizes = await _unitOfWork.SizeRepository.GetAll();
            var existed = sizes.Any(c => c.Name.ToLower() == sizeModel.Name.ToLower());
            if (existed)
            {
                return BadRequest("Size Already Exist.");
            }
            await _unitOfWork.SizeRepository.Insert(sizeModel);
            await _unitOfWork.Save();
            return CreatedAtAction(nameof(GetById), new { id = sizeModel.Id }, sizeModel.ToSizeDto());
        }
        // PUT api/size/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateRequestSizeDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var size = await _unitOfWork.SizeRepository.GetByID(id);
            if (size == null)
            {
                return NotFound();
            }
            size.Name = updatedDto.Name;
            _unitOfWork.SizeRepository.Update(size);
            await _unitOfWork.Save();
            return Ok(size.ToSizeDto());
        }

        // DELETE api/size/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var size = await _unitOfWork.SizeRepository.GetByID(id);

            if (size is null)
            {
                return NotFound("Size not found.");
            }
            try
            {
                _unitOfWork.SizeRepository.Delete(size);
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting size.", Details = ex.Message });
            }
            return NoContent();
        }
    }
}
