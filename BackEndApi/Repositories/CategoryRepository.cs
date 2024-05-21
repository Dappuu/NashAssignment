using BackEndApi.Data;
using BackEndApi.Helpers;
using BackEndApi.Interfaces;
using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackEndApi.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
		public async Task<Category?> GetByIdAsync(int id)
		{
			var category = await _context.Categories.Include(c => c.Products).Include(c => c.SubCategories)!.ThenInclude(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
			return category;
		}
	}
}
