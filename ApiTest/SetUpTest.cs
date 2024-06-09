using AutoFixture;
using BackEndApi.Controllers;
using BackEndApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTest
{
	public class SetUpTest
	{
		protected readonly CategoryController _categoryController;
		protected readonly Mock<ICategoryRepository> _mockCategoryRepo;

		protected readonly SizeController _sizeController;
		protected readonly Mock<ISizeRepository> _mockSizeRepo;

		protected readonly ProductSkuController _productSkuController;
		protected readonly Mock<IProductSkuRepository> _mockProductSkuRepo;

		protected readonly ProductController _productController;
		protected readonly Mock<IProductRepository> _mockProductRepo;

		protected readonly CommentController _commentController;
		protected readonly Mock<ICommentRepository> _mockCommentRepo;

		//protected readonly AccountController _accountController;
		//protected readonly Mock<Iacc> _mockAccountRepo;

		protected readonly Mock<IUnitOfWork> _mockUnitOfWork;
		protected readonly Fixture _fixture;
		public SetUpTest()
		{
			_fixture = new Fixture();
			_fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			_fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(x => _fixture.Behaviors.Remove(x));

			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_categoryController = new CategoryController(_mockUnitOfWork.Object);
			_categoryController.ControllerContext = new ControllerContext();
			_categoryController.ControllerContext.HttpContext = new DefaultHttpContext();
			_mockCategoryRepo = new Mock<ICategoryRepository>();

			_sizeController = new SizeController(_mockUnitOfWork.Object);
			_sizeController.ControllerContext = new ControllerContext();
			_sizeController.ControllerContext.HttpContext = new DefaultHttpContext();
			_mockSizeRepo = new Mock<ISizeRepository>();

			_productSkuController = new ProductSkuController(_mockUnitOfWork.Object);
			_productSkuController.ControllerContext = new ControllerContext();
			_productSkuController.ControllerContext.HttpContext = new DefaultHttpContext();
			_mockProductSkuRepo = new Mock<IProductSkuRepository>();

			_productController = new ProductController(_mockUnitOfWork.Object);
			_productController.ControllerContext = new ControllerContext();
			_productController.ControllerContext.HttpContext = new DefaultHttpContext();
			_mockProductRepo = new Mock<IProductRepository>();

			_commentController = new CommentController(_mockUnitOfWork.Object);
			_commentController.ControllerContext = new ControllerContext();
			_commentController.ControllerContext.HttpContext = new DefaultHttpContext();
			_mockCommentRepo = new Mock<ICommentRepository>();

			//_sizeController = new SizeController(_mockUnitOfWork.Object);
			//_sizeController.ControllerContext = new ControllerContext();
			//_sizeController.ControllerContext.HttpContext = new DefaultHttpContext();
			//_mockSizeRepo = new Mock<ISizeRepository>();

		}
	}
}
