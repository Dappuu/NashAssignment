using BackEndApi.Data;
using BackEndApi.Interfaces;
using BackEndApi.Models;

namespace BackEndApi.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }
    }
}
