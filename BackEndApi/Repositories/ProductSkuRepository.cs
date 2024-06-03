using BackEndApi.Data;
using BackEndApi.Interfaces;
using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repositories
{
    public class ProductSkuRepository : GenericRepository<ProductSku>, IProductSkuRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductSkuRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProductSku?> GetInfoProductSku(int id)
        {
            var query = _context.ProductSkus.Where(ps => ps.Id == id);
            if (query == null)
            {
                return null;
            }
            query = query.Include(ps => ps.Size);
            return await query.FirstOrDefaultAsync();
        }
    }
}
