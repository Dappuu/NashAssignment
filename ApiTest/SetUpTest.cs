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
		protected readonly Mock<IUnitOfWork> _mockUnitOfWork;
		protected readonly Mock<ICategoryRepository> _mockCategoryRepo;
		protected readonly Fixture _fixture;
		// protected readonly ApplicationDbContext _context;
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
			// _context = new ApplicationDbContext()
		}
	}
}
