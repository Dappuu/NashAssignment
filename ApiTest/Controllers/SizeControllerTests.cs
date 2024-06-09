using AutoFixture;
using BackEndApi.Controllers;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Category;
using ViewModels.Size;

namespace ApiTest.Controllers
{
	public class SizeControllerTests : SetUpTest
	{
		[Fact]
		public async Task GetAll_ReturnsOkResultWithSizes()
		{
			// Arange 
			var sizes = _fixture.Build<Size>()
				.CreateMany()
				.ToList();
			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetAll(null, null, ""))
				.ReturnsAsync(sizes);

			// Act
			var result = await _sizeController.GetAll();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var sizesDto = Assert.IsType<List<SizeDto>>(okResult.Value);
			Assert.Equal(sizes.Count, sizesDto.Count);
		}
		[Fact]
		public async Task GetById_ExistingSizeId_ReturnsOkResultWithSizeDto()
		{
			// Arrange
			var sizeId = 5;
			var size = _fixture.Build<Size>()
				.With(c => c.Id, sizeId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetByID(sizeId))
				.ReturnsAsync(size);

			// Act
			var result = await _sizeController.GetById(sizeId);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var sizeDto = Assert.IsType<SizeDto>(okResult.Value);
			Assert.Equal(size.Id, sizeDto.Id);
			Assert.Equal(size.Name, sizeDto.Name);
		}
		[Fact]
		public async Task GetById_NonExistingSizeId_ReturnsNotFoundResult()
		{
			// Arrange
			var sizeId = 10;
			Size? nullSize = null;

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetByID(sizeId))
				.ReturnsAsync(nullSize);

			// Act
			var result = await _sizeController.GetById(sizeId);

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}
		[Fact]
		public async Task Post_ValidSizeDto_ReturnsCreatedAtActionResult()
		{
			// Arrange
			var sizeRequestDto = _fixture.Build<CreateRequestSizeDto>()
				.Create();

			var sizeModel = sizeRequestDto.ToSizeFromCreateDto();
			var sizes = _fixture.Build<Size>()
				.CreateMany()
				.ToList();

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetAll(null, null, string.Empty))
				.ReturnsAsync(sizes);

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.Insert(It.IsAny<Size>()))
				.Verifiable();

			_mockUnitOfWork.Setup(uow => uow.Save())
				.Verifiable();

			// Act
			var result = await _sizeController.Post(sizeRequestDto);

			// Assert
			var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
			Assert.Equal(nameof(SizeController.GetById), createdAtActionResult.ActionName);
			Assert.Equal(sizeModel.Id, createdAtActionResult.RouteValues!["id"]);
			Assert.Equal(sizeModel.Id, (createdAtActionResult.Value as SizeDto)!.Id);

			_mockUnitOfWork.Verify(uow => uow.SizeRepository.Insert(It.IsAny<Size>()), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Post_SizeAlreadyExists_ReturnsBadRequest()
		{
			// Arrange
			var sizeRequestDto = _fixture.Build<CreateRequestSizeDto>()
				.Create();

			var sizeModel = sizeRequestDto.ToSizeFromCreateDto();
			var sizesWithDuplicate = new List<Size>
			{
				new Size { Name = sizeModel.Name } 
			};

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetAll(null, null, string.Empty))
				.ReturnsAsync(sizesWithDuplicate);

			// Act
			var result = await _sizeController.Post(sizeRequestDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.Equal("Size Already Exists.", badRequestResult.Value);

			_mockUnitOfWork.Verify(uow => uow.SizeRepository.Insert(It.IsAny<Size>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Post_InvalidModelState_ReturnsBadRequest()
		{
			// Arrange
			var sizeDto = new CreateRequestSizeDto(); // Create an instance with missing required properties or other invalid state

			_sizeController.ModelState.AddModelError("Name", "The Name field is required."); // Add a model state error to simulate invalid state

			// Act
			var result = await _sizeController.Post(sizeDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.IsType<SerializableError>(badRequestResult.Value);
		}
		[Fact]
		public async Task Put_ExistingSizeId_ReturnsOkResultWithUpdatedSizeDto()
		{
			// Arrange
			int sizeId = 5;
			var updatedDto = _fixture.Build<UpdateRequestSizeDto>()
				.Create();

			var size = _fixture.Build<Size>()
				.With(c => c.Id, sizeId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetByID(sizeId))
				.ReturnsAsync(size);

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.Update(It.IsAny<Size>()))
				.Verifiable();


			// Act
			var result = await _sizeController.Put(sizeId, updatedDto);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var updatedSizeDto = Assert.IsType<SizeDto>(okResult.Value);

			Assert.Equal(size.Id, updatedSizeDto.Id);
			Assert.Equal(updatedDto.Name, updatedSizeDto.Name);

			_mockUnitOfWork.Verify(uow => uow.SizeRepository.Update(It.IsAny<Size>()), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Put_NonExistingSizeId_ReturnsNotFound()
		{
			// Arrange
			int sizeId = 10; 
			var updatedDto = _fixture.Build<UpdateRequestSizeDto>()
				.Create();

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetByID(sizeId))
				.ReturnsAsync((Size?)null); 

			// Act
			var result = await _sizeController.Put(sizeId, updatedDto);

			// Assert
			Assert.IsType<NotFoundResult>(result);

			_mockUnitOfWork.Verify(uow => uow.SizeRepository.Update(It.IsAny<Size>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Put_InvalidModelState_ReturnsBadRequest()
		{
			// Arrange
			int sizeId = 5;
			var updatedDto = new UpdateRequestSizeDto();

			_sizeController.ModelState.TryAddModelError("Name", "The Name field is required.");

			// Act
			var result = await _sizeController.Put(sizeId, updatedDto);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);

			_mockUnitOfWork.Verify(uow => uow.SizeRepository.Update(It.IsAny<Size>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Delete_ValidId_ReturnsNoContent()
		{
			// Arrange
			int sizeId = 5;
			var size = _fixture.Build<Size>().With(c => c.Id, sizeId).Create();

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetByID(sizeId))
				.ReturnsAsync(size);

			// Act
			var result = await _sizeController.Delete(sizeId);

			// Assert
			Assert.IsType<NoContentResult>(result);
			_mockUnitOfWork.Verify(uow => uow.SizeRepository.Delete(size), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Delete_SizeNotFound_ReturnsNotFound()
		{
			// Arrange
			int sizeId = 5;

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetByID(sizeId))
				.ReturnsAsync((Size?)null);

			// Act
			var result = await _sizeController.Delete(sizeId);

			// Assert
			var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
			Assert.Equal("Size not found.", notFoundResult.Value);
		}
		[Fact]
		public async Task Delete_ExceptionThrown_ReturnsStatusCode500WithErrorMessage()
		{
			// Arrange
			int sizeId = 5;
			var size = _fixture.Build<Size>().With(c => c.Id, sizeId).Create();

			_mockUnitOfWork.Setup(uow => uow.SizeRepository.GetByID(sizeId))
				.ReturnsAsync(size);

			_mockUnitOfWork.Setup(uow => uow.Save())
				.ThrowsAsync(new Exception("Some error occurred."));

			// Act
			var result = await _sizeController.Delete(sizeId);

			// Assert
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
		}
	}
}
