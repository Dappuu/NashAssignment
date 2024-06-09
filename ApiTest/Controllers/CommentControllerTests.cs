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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Category;
using ViewModels.Comment;
using ViewModels.Size;

namespace ApiTest.UnitTests
{
		public class CommentControllerTests : SetUpTest
		{
			[Fact]
			public async Task GetAll_CommentsExist_ReturnsOkResultWithCommentDtos()
			{
				// Arrange
				var comments = new List<Comment>
				{
				new Comment { Id = 1, Content = "Comment 1", ProductId = 1, UserId = "1", User = new User { Id = "1", UserName = "User 1" } },
				new Comment { Id = 2, Content = "Comment 2", ProductId = 1, UserId = "2", User = new User { Id = "2", UserName = "User 2" } }
				};

				_mockUnitOfWork.Setup(uow => uow.CommentRepository.GetAll(null, null, "User"))
					.ReturnsAsync(comments);

				// Act
				var result = await _commentController.GetAll();

				// Assert
				var okResult = Assert.IsType<OkObjectResult>(result);
				var commentDtos = Assert.IsAssignableFrom<List<CommentDto>>(okResult.Value);

				Assert.Equal(comments.Count, commentDtos.Count);
				Assert.Equal(comments[0].Id, commentDtos[0].Id);
				Assert.Equal(comments[0].Content, commentDtos[0].Content);
				Assert.Equal(comments[1].Id, commentDtos[1].Id);
				Assert.Equal(comments[1].Content, commentDtos[1].Content);
			}
		[Fact]
		public async Task GetByProductId_CommentsExist_ReturnsOkResultWithCommentDtos()
		{
			// Arrange
			var productId = 1;
			var comments = new List<Comment>
			{
				new Comment { Id = 1, Content = "Comment 1", ProductId = productId, UserId = "1", User = new User { Id = "1", UserName = "User 1" } },
				new Comment { Id = 2, Content = "Comment 2", ProductId = productId, UserId = "2", User = new User { Id = "2", UserName = "User 2" } }
			};

			_mockUnitOfWork.Setup(uow => uow.CommentRepository.GetAll(c => c.ProductId == productId, null, "User"))
				.ReturnsAsync(comments);

			// Act
			var result = await _commentController.GetByProductId(productId);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var commentDtos = Assert.IsAssignableFrom<List<CommentDto>>(okResult.Value);

			Assert.Equal(comments.Count, commentDtos.Count);
			Assert.Equal(comments[0].Id, commentDtos[0].Id);
			Assert.Equal(comments[0].Content, commentDtos[0].Content);
			Assert.Equal(comments[1].Id, commentDtos[1].Id);
			Assert.Equal(comments[1].Content, commentDtos[1].Content);
		}
		[Fact]
		public async Task GetById_CommentExists_ReturnsOkResultWithCommentDto()
		{
			// Arrange
			var commentId = 5;
			var comment = new Comment { Id = commentId, Content = "Comment 1", UserId = "1", User = new User { Id = "1", UserName = "User 1" } };

			_mockUnitOfWork.Setup(uow => uow.CommentRepository.GetByIdAsync(commentId))
				.ReturnsAsync(comment);

			// Act
			var result = await _commentController.GetById(commentId);

			// Assert
			var okResult = Assert.IsType<OkObjectResult>(result);
			var commentDto = Assert.IsAssignableFrom<CommentDto>(okResult.Value);

			Assert.Equal(comment.Id, commentDto.Id);
			Assert.Equal(comment.Content, commentDto.Content);
			Assert.Equal(comment.User.UserName, commentDto.UserName);
		}
		[Fact]
		public async Task GetById_CommentDoesNotExist_ReturnsNotFoundResult()
		{
			// Arrange
			var commentId = 5;
			Comment? comment = null;

			_mockUnitOfWork.Setup(uow => uow.CommentRepository.GetByIdAsync(commentId))
				.ReturnsAsync(comment);

			// Act
			var result = await _commentController.GetById(commentId);

			// Assert
			Assert.IsType<NotFoundResult>(result);
		}
		[Fact]
		public async Task Post_ValidCommentDto_ReturnsCreatedAtActionResultWithCommentDto()
		{
			// Arrange
			var commentDto = new CreateRequestCommentDto
			{
				ProductId = 1,
				Content = "This is a comment",
				Rating = 5
			};

			var productModel = new Product { Id = 1, Name = "Product 1" };
			var userId = "12345";

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(commentDto.ProductId))
				.ReturnsAsync(productModel);

			_mockUnitOfWork.Setup(uow => uow.CommentRepository.Insert(It.IsAny<Comment>()))
				.Callback<Comment>(c => c.Id = 1)
				.Returns(Task.CompletedTask);

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.Update(productModel));

			_mockUnitOfWork.Setup(uow => uow.Save())
				.Returns(Task.CompletedTask);

			var claims = new List<Claim> { new Claim("UserId", userId) };
			var identity = new ClaimsIdentity(claims);
			var claimsPrincipal = new ClaimsPrincipal(identity);

			var controller = new CommentController(_mockUnitOfWork.Object)
			{
				ControllerContext = new ControllerContext
				{
					HttpContext = new DefaultHttpContext
					{
						User = claimsPrincipal
					}
				}
			};
			// Act
			var result = await controller.Post(commentDto);

			// Assert
			var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
			var commentDtoResult = Assert.IsAssignableFrom<CommentDto>(createdAtActionResult.Value);

			Assert.Equal(1, commentDtoResult.Id);
			Assert.Equal(commentDto.Content, commentDtoResult.Content);
			Assert.Equal(productModel.Id, commentDtoResult.ProductId);
		}
		[Fact]
		public async Task Post_InvalidCommentDto_ReturnsBadRequestResultWithModelStateErrors()
		{
			// Arrange
			var commentDto = new CreateRequestCommentDto
			{
			};

			_commentController.ModelState.AddModelError("Text", "The Text field is required.");

			// Act
			var result = await _commentController.Post(commentDto);

			// Assert
			var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
			var modelState = Assert.IsType<SerializableError>(badRequestResult.Value);

			Assert.True(modelState.ContainsKey("Text"));
		}
		[Fact]
		public async Task Post_ProductDoesNotExist_ReturnsNotFoundResult()
		{
			// Arrange
			var commentDto = new CreateRequestCommentDto
			{
				ProductId = 1,
				Content = "This is a comment",
				Rating = 5
			};

			Product? productModel = null;

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(commentDto.ProductId))
				.ReturnsAsync(productModel);

			// Act
			var result = await _commentController.Post(commentDto);

			// Assert
			var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
			var errorMessage = Assert.IsType<string>(notFoundResult.Value);

			Assert.Equal("Product of comment Not Found.", errorMessage);
		}
		[Fact]
		public async Task Post_SaveThrowsException_ReturnsInternalServerErrorResult()
		{
			// Arrange
			var commentDto = new CreateRequestCommentDto
			{
				ProductId = 1,
				Content = "This is a comment",
				Rating = 5
			};

			var productModel = new Product { Id = 1, Name = "Product 1" };
			var userId = "12345";

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.GetInfoProduct(commentDto.ProductId))
				.ReturnsAsync(productModel);

			_mockUnitOfWork.Setup(uow => uow.CommentRepository.Insert(It.IsAny<Comment>()))
				.Callback<Comment>(c => c.Id = 1)
				.Returns(Task.CompletedTask);

			_mockUnitOfWork.Setup(uow => uow.ProductRepository.Update(productModel));

			_mockUnitOfWork.Setup(uow => uow.Save())
				.Throws(new Exception("An error occurred while saving."));

			var claims = new List<Claim> { new Claim("UserId", userId) };
			var identity = new ClaimsIdentity(claims);
			var claimsPrincipal = new ClaimsPrincipal(identity);

			var controller = new CommentController(_mockUnitOfWork.Object)
			{
				ControllerContext = new ControllerContext
				{
					HttpContext = new DefaultHttpContext
					{
						User = claimsPrincipal
					}
				}
			};

			// Act
			var result = await controller.Post(commentDto);

			// Assert
			var internalServerErrorResult = Assert.IsType<ObjectResult>(result);
			Assert.Equal(StatusCodes.Status500InternalServerError, internalServerErrorResult.StatusCode);
		}
	}

}
