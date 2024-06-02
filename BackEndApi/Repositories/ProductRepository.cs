using BackEndApi.Data;
using BackEndApi.Interfaces;
using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
		public async Task<Product?> GetInfoProduct(int id)
		{
			var query =  _context.Products.Where(p => p.Id == id);
			if (query == null)
			{
				return null;
			}
			query = query.Include(p => p.Comments).Include(p => p.Category);
			if (await query.AnyAsync(p => p.productSkus != null))
			{
				query = query.Include(p => p.productSkus!).ThenInclude(psku => psku.Size);
			}
			return await query.FirstOrDefaultAsync();
		}
	}
}
