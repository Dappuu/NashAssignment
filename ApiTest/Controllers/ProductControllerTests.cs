using AutoFixture;
using BackEndApi.Controllers;
using BackEndApi.Helpers;
using BackEndApi.Mappers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Category;
using ViewModels.Product;
using ViewModels.ProductSku;
using ViewModels.Size;

namespace ApiTest.Controllers
{
	public class ProductControllerTests : SetUpTest
	{
		[Fact]
		public async Task GetAll_ValidQuery_ReturnsOkResultWithProductDtoList()
		{
			// Arrange
			var query = new QueryObject
			{
				Name = "Test",
				SortBy = "Name",
				IsDescending = false
			};

			var products = new List<Product>
			{
				new Product { Id = 1, Name = "Test Product 1", Price = 10.99m, UnitsSold = 5 },
				new Product { Id = 2, Name = "Test Product 2", Price = 15.99m, UnitsSold = 8 },
				new Product { Id = 3, Name = "Another Product", Price = 5.99m, UnitsSold = 3 }
			};

			var filteredProducts = products.Where(p => p.Name.Contains(query.Name));
			var orderedProducts = filteredProducts.OrderBy(p => p.Name);
			var productsAfter = orderedProducts.ToList();

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetAll(
				It.IsAny<Expression<Func<Product, bool>>>(),
				It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(),
				"Category"
			)).ReturnsAsync(productsAfter);

			// Act
			var result = await _productController.GetAll(query);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var returnedProductDtos = Assert.IsAssignableFrom<List<ProductDto>>(okResult.Value);

			Assert.Equal(productsAfter.Count, returnedProductDtos.Count);
            for (int i = 0; i < productsAfter.Count; i++)
            {
				Assert.Equal(productsAfter[i].Id, returnedProductDtos[i].Id);
			}
        }
		[Fact]
		public async Task GetById_ExistingProductId_ReturnsOkResultWithProductDto()
		{
			// Arrange
			var productId = 5;
			var product = _fixture.Build<Product>()
				.With(c => c.Id, productId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productId))
				.ReturnsAsync(product);

			// Act
			var result = await _productController.GetById(productId);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var productDto = Assert.IsType<ProductDto>(okResult.Value);
			Assert.Equal(product.Id, productDto.Id);
		}
		[Fact]
		public async Task GetById_NonExistingProductId_ReturnsNotFoundResult()
		{
			// Arrange
			var productId = 10;
			Product? nullProductSku = null;

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(productId))
				.ReturnsAsync(nullProductSku);

			// Act
			var result = await _productController.GetById(productId);

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}
		[Fact]
		public async Task Post_ValidProduct_ReturnsCreatedResult()
		{
			// Arrange
			var category = _fixture.Build<Category>()
				.Create();
			category.SubCategories = null;
			var categoryId = category.Id;


			var productDto = _fixture.Build<CreateRequestProductDto>()
				.With(p => p.CategoryId, categoryId)
				.Create();

			var productModel = productDto.ToProductFromCreateDto();


			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(productModel.CategoryId))
				.ReturnsAsync(category);

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.Insert(productModel))
				.Returns(Task.CompletedTask);

			_mockUnitOfWork.Setup(uow => uow.Save())
				.Returns(Task.CompletedTask);

			// Act
			var result = await _productController.Post(productDto);

			// Assert
			var createdResult = Assert.IsType<CreatedAtActionResult>(result);
			var createdProductDto = Assert.IsType<ProductDto>(createdResult.Value);

			Assert.Equal(productModel.Id, createdProductDto.Id);
			Assert.Equal(categoryId, createdProductDto.CategoryId);
		}
		[Fact]
		public async Task Post_CategoryHasSubCategories_ReturnsBadRequestResult()
		{
			// Arrange
			var productDto = new CreateRequestProductDto
			{
				CategoryId = 1
			};

			var category = new Category
			{
				Id = 1,
				SubCategories = new List<Category> { new Category() }
			};

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(productDto.CategoryId))
				.ReturnsAsync(category);

			// Act
			var result = await _productController.Post(productDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.Equal("Cannot Add Product To Parent Category", badRequestResult.Value);
		}
		[Fact]
		public async Task Post_CategoryNotFound_ReturnsNotFoundResult()
		{
			// Arrange
			var productDto = new CreateRequestProductDto
			{
				CategoryId = 1
			};

			Category? category = null; 

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(productDto.CategoryId))
				.ReturnsAsync(category);

			// Act
			var result = await _productController.Post(productDto);

			// Assert
			var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
			Assert.Equal("Not Found The Category Of Product", notFoundResult.Value);
		}
		[Fact]
		public async Task Post_InvalidModel_ReturnsBadRequestWithModelStateErrors()
		{
			// Arrange
			var invalidProductDto = new CreateRequestProductDto();

			_productController.ModelState.AddModelError("PropertyName", "Error message");

			// Act
			var result = await _productController.Post(invalidProductDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			var errors = Assert.IsType<SerializableError>(badRequestResult.Value);

			// Verify specific model errors based on your scenario
			Assert.True(errors.ContainsKey("PropertyName"));
			var errorMessages = (string[])errors["PropertyName"];
			Assert.Single(errorMessages);
			Assert.Equal("Error message", errorMessages[0]);
		}
		[Fact]
		public async Task Put_InvalidModel_ReturnsBadRequestWithModelStateErrors()
		{
			// Arrange
			var productId = 1; // Set the desired product ID for testing purposes.
			var invalidProductDto = new UpdateRequestProductDto();

			_productController.ModelState.AddModelError("PropertyName", "Error message");

			// Act
			var result = await _productController.Put(productId, invalidProductDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			var errors = Assert.IsType<SerializableError>(badRequestResult.Value);

			// Verify specific model errors based on your scenario
			Assert.True(errors.ContainsKey("PropertyName"));
			var errorMessages = (string[])errors["PropertyName"];
			Assert.Single(errorMessages);
			Assert.Equal("Error message", errorMessages[0]);
		}
		[Fact]
		public async Task Put_ProductNotFound_ReturnsNotFoundResult()
		{
			// Arrange
			var productId = 1;
			var updatedDto = new UpdateRequestProductDto();

			Product? product = null; 

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetByID(productId))
				.ReturnsAsync(product);

			// Act
			var result = await _productController.Put(productId, updatedDto);

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}
		[Fact]
		public async Task Put_ValidModel_ReturnsOkResultWithUpdatedProductDto()
		{
			// Arrange
			var productId = 1; // Set the desired product ID for testing purposes.
			var updatedDto = new UpdateRequestProductDto
			{
				Name = "Updated Product",
				Price = 19.99m
			};

			var product = new Product { Id = productId, Name = "Old Product", Price = 10.99m };

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetByID(productId))
				.ReturnsAsync(product);

			// Act
			var result = await _productController.Put(productId, updatedDto);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var updatedProductDto = Assert.IsAssignableFrom<ProductDto>(okResult.Value);

			Assert.Equal(productId, updatedProductDto.Id);
			Assert.Equal(updatedDto.Name, updatedProductDto.Name);
			Assert.Equal(updatedDto.Price, updatedProductDto.Price);
		}
		[Fact]
		public async Task Delete_ProductNotFound_ReturnsNotFoundResult()
		{
			// Arrange
			var productId = 1; 

			Product? product = null; 

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetByID(productId))
				.ReturnsAsync(product);

			// Act
			var result = await _productController.Delete(productId);

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}
		[Fact]
		public async Task Delete_ProductDeleted_ReturnsNoContentResult()
		{
			// Arrange
			var productId = 1;

			var product = new Product { Id = productId, Name = "Product to delete" };

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetByID(productId))
				.ReturnsAsync(product);

			// Act
			var result = await _productController.Delete(productId);

			// Assert
			Assert.IsType<NoContentResult>(result);
			_mockUnitOfWork.Verify(uow => uow.ProductRepository.Delete(product), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Delete_ExceptionThrown_ReturnsStatusCode500WithErrorMessage()
		{
			// Arrange
			var productId = 1; 

			var product = new Product { Id = productId, Name = "Product to delete" };

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetByID(productId))
				.ReturnsAsync(product);

			_mockUnitOfWork.Setup(uow => uow.Save())
				.ThrowsAsync(new Exception("Some error occurred."));

			// Act
			var result = await _productController.Delete(productId);

			// Assert
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);

			_mockUnitOfWork.Verify(uow => uow.ProductRepository.Delete(product), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
	}
}
