using BackEndApi.Data;
using BackEndApi.Interfaces;
using BackEndApi.Models;

namespace BackEndApi.Repositories
{
    public class ProductSkuRepository : GenericRepository<ProductSku>, IProductSkuRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductSkuRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
