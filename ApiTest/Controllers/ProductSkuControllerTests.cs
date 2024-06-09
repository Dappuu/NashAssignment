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
using ViewModels.ProductSku;
using ViewModels.Size;

namespace ApiTest.Controllers
{
	public class ProductSkuControllerTests : SetUpTest
	{
		[Fact]
		public async Task GetById_ExistingProductSkuId_ReturnsOkResultWithProductSkuDto()
		{
			// Arrange
			var productSkuId = 5;
			var productSku = _fixture.Build<ProductSku>()
				.With(c => c.Id, productSkuId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetInfoProductSku(productSkuId))
				.ReturnsAsync(productSku);

			// Act
			var result = await _productSkuController.GetById(productSkuId);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var productSkuDto = Assert.IsType<ProductSkuDto>(okResult.Value);
			Assert.Equal(productSku.Id, productSkuDto.Id);
			Assert.Equal(productSku.ProductId, productSkuDto.ProductId);
			Assert.Equal(productSku.SizeId, productSkuDto.SizeId);
		}
		[Fact]
		public async Task GetById_NonExistingProductSkuId_ReturnsNotFoundResult()
		{
			// Arrange
			var productSkuId = 10;
			ProductSku? nullProductSku = null;

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetInfoProductSku(productSkuId))
				.ReturnsAsync(nullProductSku);

			// Act
			var result = await _productSkuController.GetById(productSkuId);

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}
		[Fact]
		public async Task Post_ValidProductSku_ReturnsCreatedResult()
		{
			// Arrange
			var product = _fixture.Build<Product>()
				.Create();
			product.productSkus = null;
			var productId = product.Id;

			var productSkuDto = _fixture.Build<CreateRequestProductskuDto>()
				.With(p => p.ProductId, productId)
				.Create();

			var productSkuModel = productSkuDto.ToProductSkuFromCreateDto();

			var productSkus = _fixture.Build<ProductSku>()
				.With(c => c.ProductId, productId)
				.CreateMany()
				.ToList();

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productId))
				.ReturnsAsync(product);

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetAll(null, null, string.Empty))
				.ReturnsAsync(productSkus);

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.Insert(productSkuModel))
				.Returns(Task.CompletedTask);

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.Update(product));

			_mockUnitOfWork.Setup(uow => uow.Save())
				.Returns(Task.CompletedTask);

			// Act
			var result = await _productSkuController.Post(productSkuDto);

			// Assert
			var createdResult = Assert.IsType<CreatedAtActionResult>(result);
			var createdProductSkuDto = Assert.IsType<ProductSkuDto>(createdResult.Value);

			Assert.Equal(productSkuModel.Id, createdProductSkuDto.Id);
			Assert.Equal(productId, createdProductSkuDto.ProductId);
		}
		[Fact]
		public async Task Post_ProductSkuAlreadyExists_ReturnsBadRequest()
		{
			// Arrange
			var product = _fixture.Create<Product>();
			var productId = product.Id;

			var productSkuDto = _fixture.Build<CreateRequestProductskuDto>()
				.With(p => p.ProductId, productId)
				.Create();

			var productSkuModel = productSkuDto.ToProductSkuFromCreateDto();

			var productSkus = _fixture.Build<ProductSku>()
				.With(c => c.ProductId, productId)
				.CreateMany()
				.ToList();
			productSkus.Add(productSkuModel);

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productId))
				.ReturnsAsync(product);

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetAll(null, null, string.Empty))
				.ReturnsAsync(productSkus);
			// Act
			var result = await _productSkuController.Post(productSkuDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.Equal("ProductSku Already Exists.", badRequestResult.Value);

			_mockUnitOfWork.Verify(uow => uow.SizeRepository.Insert(It.IsAny<Size>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Post_InvalidModelState_ReturnsBadRequest()
		{
			// Arrange
			var productSkuDto = new CreateRequestProductskuDto();

			_productSkuController.ModelState.AddModelError("Name", "The Name field is required.");

			// Act
			var result = await _productSkuController.Post(productSkuDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.IsType<SerializableError>(badRequestResult.Value);
		}
		[Fact]
		public async Task Post_ProductNotFound_ReturnsNotFoundResult()
		{
			// Arrange
			var productSkuDto = new CreateRequestProductskuDto();

			var productId = 1; // Set the desired product ID for testing purposes.
			Product? product = null; // Simulate a null product.

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productId))
				.ReturnsAsync(product);

			var controller = new ProductSkuController(_mockUnitOfWork.Object);

			// Act
			var result = await _productSkuController.Post(productSkuDto);

			// Assert
			var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
			Assert.Equal("Not Found The Product Of ProductSku", notFoundResult.Value);
		}
		[Fact]
		public async Task Post_ExceptionThrown_ReturnsInternalServerErrorResult()
		{
			// Arrange
			var productId = 1; 
			var product = _fixture.Build<Product>()
				.With(p => p.Id, productId)
				.Create();
			product.productSkus = null;

			var productSkuDto = _fixture.Build<CreateRequestProductskuDto>()
				.With(p => p.ProductId, productId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productId))
				.ReturnsAsync(product);

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetAll(null, null, string.Empty))
				.ReturnsAsync(new List<ProductSku>());

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.Insert(It.IsAny<ProductSku>()))
				.ThrowsAsync(new Exception("Some error occurred."));

			// Act
			var result = await _productSkuController.Post(productSkuDto);

			// Assert
			var statusCodeResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
		}
		[Fact]
		public async Task Put_ExistingProductSkuId_ReturnsOkResultWithUpdatedProductSkuDto()
		{
			// Arrange
			int productSkuId = 5;
			var updatedDto = _fixture.Build<UpdateRequestProductSkuDto>()
				.Create();

			var productSku = _fixture.Build<ProductSku>()
				.With(c => c.Id, productSkuId)
				.Create();
			var product = _fixture.Build<Product>()
				.With(p => p.Id, productSku.ProductId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetInfoProductSku(productSkuId))
				.ReturnsAsync(productSku);

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.Update(It.IsAny<ProductSku>()))
				.Verifiable();

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productSku.ProductId))
				.ReturnsAsync(product);

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.Update(product))
				.Verifiable();

			_mockUnitOfWork.Setup(uow => uow.Save())
				.Returns(Task.CompletedTask)
				.Verifiable();
			// Act
			var result = await _productSkuController.Put(productSkuId, updatedDto);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var updatedProductSkuDto = Assert.IsType<ProductSkuDto>(okResult.Value);

			Assert.Equal(productSku.Id, updatedProductSkuDto.Id);
			Assert.Equal(updatedDto.SizeId, updatedProductSkuDto.SizeId);
			Assert.Equal(updatedDto.UnitsInStock, updatedProductSkuDto.UnitsInStock);

			_mockUnitOfWork.Verify(uow => uow.ProductSkuRepository.Update(It.IsAny<ProductSku>()), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.ProductRepository.Update(It.IsAny<Product>()), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Put_NonExistingSizeId_ReturnsNotFound()
		{
			// Arrange
			int productSkuId = 10;
			var updatedDto = _fixture.Build<UpdateRequestProductSkuDto>()
				.Create();

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetInfoProductSku(productSkuId))
				.ReturnsAsync((ProductSku?)null);

			// Act
			var result = await _productSkuController.Put(productSkuId, updatedDto);

			// Assert
			Assert.IsType<NotFoundResult>(result);

			_mockUnitOfWork.Verify(uow => uow.ProductSkuRepository.Update(It.IsAny<ProductSku>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Put_InvalidModelState_ReturnsBadRequest()
		{
			// Arrange
			int productSkuId = 5;
			var updatedDto = new UpdateRequestProductSkuDto();

			_productSkuController.ModelState.TryAddModelError("Name", "The Name field is required.");

			// Act
			var result = await _productSkuController.Put(productSkuId, updatedDto);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);

			_mockUnitOfWork.Verify(uow => uow.ProductSkuRepository.Update(It.IsAny<ProductSku>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Delete_ValidId_ReturnsNoContent()
		{
			// Arrange
			int productSkuId = 5;
			var productSku = _fixture.Build<ProductSku>()
				.With(c => c.Id, productSkuId)
				.Create();
			var product = _fixture.Build<Product>()
				.With(c => c.Id, productSku.ProductId)
				.Create();
			product.productSkus = new List<ProductSku> { productSku };

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetByID(productSkuId))
				.ReturnsAsync(productSku);
			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productSku.ProductId))
				.ReturnsAsync(product);

			// Act
			var result = await _productSkuController.Delete(productSkuId);

			// Assert
			Assert.IsType<NoContentResult>(result);
			_mockUnitOfWork.Verify(uow => uow.ProductSkuRepository.Delete(productSku), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.ProductRepository.Update(product), Times.Once);
		}
		[Fact]
		public async Task Delete_SizeNotFound_ReturnsNotFound()
		{
			// Arrange
			int productSkuId = 5;

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetByID(productSkuId))
				.ReturnsAsync((ProductSku?)null);

			// Act
			var result = await _productSkuController.Delete(productSkuId);

			// Assert
			var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
			Assert.Equal("ProductSku not found.", notFoundResult.Value);
		}
		[Fact]
		public async Task Delete_ExceptionThrown_ReturnsStatusCode500WithErrorMessage()
		{
			// Arrange
			int productSkuId = 5;
			var productSku = _fixture.Build<ProductSku>().With(c => c.Id, productSkuId).Create();

			_mockUnitOfWork.Setup(uow => uow.ProductSkuRepository.GetByID(productSkuId))
				.ReturnsAsync(productSku);

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productSku.ProductId))
				.ReturnsAsync(_fixture.Create<Product>());

			_mockUnitOfWork.Setup(uow => uow.Save())
				.ThrowsAsync(new Exception("Some error occurred."));

			// Act
			var result = await _productSkuController.Delete(productSkuId);

			// Assert
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
		}
	}
}
