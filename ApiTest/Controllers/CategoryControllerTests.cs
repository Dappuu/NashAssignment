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

namespace ApiTest.Controllers
{
	public class CategoryControllerTests : SetUpTest
	{
		[Fact]
		public async Task GetAll_ReturnsOkResultWithCategories()
		{
			// Arange 
			var categories = _fixture.Build<Category>()
			.CreateMany()
			.ToList();
			categories.ForEach(c => c.ParentId = null);
			categories.ForEach(c => c.Parent = null);
			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetAll(null, null, "SubCategories"))
				.ReturnsAsync(categories);

			// Act
			var result = await _categoryController.GetAll();

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var categoriesDto = Assert.IsType<List<CategoryDto>>(okResult.Value);
			Assert.Equal(categories.Count, categoriesDto.Count);
		}
		[Fact]
		public async Task GetById_ExistingCategoryId_ReturnsOkResultWithCategoryDto()
		{
			// Arrange
			var categoryId = 5;
			var category = _fixture.Build<Category>()
				.With(c => c.Id, categoryId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(categoryId))
				.ReturnsAsync(category);

			// Act
			var result = await _categoryController.GetById(categoryId);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var categoryDto = Assert.IsType<CategoryDto>(okResult.Value);
			Assert.Equal(categoryId, categoryDto.Id);
			Assert.Equal(category.Name, categoryDto.Name);
		}
		[Fact]
		public async Task GetById_NonExistingCategoryId_ReturnsNotFoundResult()
		{
			// Arrange
			var categoryId = 10;
			Category? nullCategory = null;

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(categoryId))
				.ReturnsAsync(nullCategory);

			// Act
			var result = await _categoryController.GetById(categoryId);

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}
		[Fact]
		public async Task Post_ValidCategoryDto_ReturnsCreatedAtActionResult()
		{
			// Arrange
			var categoryRequestDto = _fixture.Build<CreateRequestCategoryDto>()
				.Create();

			var categoryModel = categoryRequestDto.ToCategoryFromCreateDto();
			var categories = _fixture.Build<Category>()
				.CreateMany()
				.ToList();

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetAll(null, null, string.Empty))
				.ReturnsAsync(categories);

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.Insert(It.IsAny<Category>()))
				.Verifiable();

			_mockUnitOfWork.Setup(uow => uow.Save())
				.Verifiable();

			// Act
			var result = await _categoryController.Post(categoryRequestDto);

			// Assert
			var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
			Assert.Equal(nameof(CategoryController.GetById), createdAtActionResult.ActionName);
			Assert.Equal(categoryModel.Id, createdAtActionResult.RouteValues!["id"]);
			Assert.Equal(categoryModel.Id, (createdAtActionResult.Value as CategoryDto)!.Id);

			_mockUnitOfWork.Verify(uow => uow.CategoryRepository.Insert(It.IsAny<Category>()), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Post_CategoryAlreadyExists_ReturnsBadRequest()
		{
			// Arrange
			var categoryRequestDto = _fixture.Build<CreateRequestCategoryDto>()
				.Create();

			var categoryModel = categoryRequestDto.ToCategoryFromCreateDto();
			var categoriesWithDuplicate = new List<Category>
			{
				new Category { Name = categoryModel.Name } // Adding a category with the same name
			};

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetAll(null, null, string.Empty))
				.ReturnsAsync(categoriesWithDuplicate);

			// Act
			var result = await _categoryController.Post(categoryRequestDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.Equal("Category Already Exist.", badRequestResult.Value);

			_mockUnitOfWork.Verify(uow => uow.CategoryRepository.Insert(It.IsAny<Category>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Post_InvalidModelState_ReturnsBadRequest()
		{
			// Arrange
			var categoryDto = new CreateRequestCategoryDto(); // Create an instance with missing required properties or other invalid state

			_categoryController.ModelState.AddModelError("Name", "The Name field is required."); // Add a model state error to simulate invalid state

			// Act
			var result = await _categoryController.Post(categoryDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.IsType<SerializableError>(badRequestResult.Value);
		}
		[Fact]
		public async Task Put_ExistingCategoryId_ReturnsOkResultWithUpdatedCategoryDto()
		{
			// Arrange
			int categoryId = 5;
			var updatedDto = _fixture.Build<UpdateRequestCategoryDto>()
				.Create();

			var category = _fixture.Build<Category>()
				.With(c => c.Id, categoryId)
				.Create();

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByID(categoryId))
				.ReturnsAsync(category);

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.Update(It.IsAny<Category>()))
				.Verifiable();


			// Act
			var result = await _categoryController.Put(categoryId, updatedDto);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var updatedCategoryDto = Assert.IsType<CategoryDto>(okResult.Value);

			Assert.Equal(category.Id, updatedCategoryDto.Id);
			Assert.Equal(updatedDto.Name, updatedCategoryDto.Name);
			Assert.Equal(updatedDto.Description, updatedCategoryDto.Description);

			_mockUnitOfWork.Verify(uow => uow.CategoryRepository.Update(It.IsAny<Category>()), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Put_NonExistingCategoryId_ReturnsNotFound()
		{
			// Arrange
			int categoryId = 10; // ID of a non-existing category
			var updatedDto = _fixture.Build<UpdateRequestCategoryDto>()
				.Create();

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByID(categoryId))
				.ReturnsAsync((Category?)null); // Return null to simulate category not found

			// Act
			var result = await _categoryController.Put(categoryId, updatedDto);

			// Assert
			Assert.IsType<NotFoundResult>(result);

			_mockUnitOfWork.Verify(uow => uow.CategoryRepository.Update(It.IsAny<Category>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Put_InvalidModelState_ReturnsBadRequest()
		{
			// Arrange
			int categoryId = 5;
			var updatedDto = new UpdateRequestCategoryDto(); // Create an instance with missing or invalid 

			_categoryController.ModelState.TryAddModelError("Name", "The Name field is required.");

			// Act
			var result = await _categoryController.Put(categoryId, updatedDto);

			// Assert
			Assert.IsType<BadRequestObjectResult>(result);

			_mockUnitOfWork.Verify(uow => uow.CategoryRepository.Update(It.IsAny<Category>()), Times.Never);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Never);
		}
		[Fact]
		public async Task Delete_ValidId_ReturnsNoContent()
		{
			// Arrange
			int categoryId = 5;
			var category = _fixture.Build<Category>().With(c => c.Id, categoryId).Create();

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(categoryId))
				.ReturnsAsync(category);

			// Act
			var result = await _categoryController.Delete(categoryId);

			// Assert
			Assert.IsType<NoContentResult>(result);
			_mockUnitOfWork.Verify(uow => uow.CategoryRepository.Delete(category), Times.Once);
			_mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
		}
		[Fact]
		public async Task Delete_CategoryNotFound_ReturnsNotFound()
		{
			// Arrange
			int categoryId = 5;

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(categoryId))
				.ReturnsAsync((Category?)null);

			// Act
			var result = await _categoryController.Delete(categoryId);

			// Assert
			var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
			Assert.Equal("Category not found.", notFoundResult.Value);
		}
		[Fact]
		public async Task Delete_CategoryWithSubcategories_ReturnsBadRequest()
		{
			// Arrange
			int categoryId = 5;
			var category = _fixture.Build<Category>().With(c => c.Id, categoryId).Create();
			category.SubCategories = _fixture.CreateMany<Category>(3).ToList(); // Simulate having subcategories

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(categoryId))
				.ReturnsAsync(category);

			// Act
			var result = await _categoryController.Delete(categoryId);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			Assert.Equal("Cannot delete category because it is linked to subcategories.", badRequestResult.Value);
		}
		[Fact]
		public async Task Delete_ExceptionThrown_ReturnsStatusCode500WithErrorMessage()
		{
			// Arrange
			int categoryId = 5;
			var category = _fixture.Build<Category>().With(c => c.Id, categoryId).Create();

			_mockUnitOfWork.Setup(uow => uow.CategoryRepository.GetByIdAsync(categoryId))
				.ReturnsAsync(category);

			_mockUnitOfWork.Setup(uow => uow.Save())
				.ThrowsAsync(new Exception("Some error occurred."));

			// Act
			var result = await _categoryController.Delete(categoryId);

			// Assert
			var objectResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
		}
	}
}
