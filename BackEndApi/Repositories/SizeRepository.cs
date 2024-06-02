using BackEndApi.Data;
using BackEndApi.Interfaces;
using BackEndApi.Models;

namespace BackEndApi.Repositories
{
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        private readonly ApplicationDbContext _context;
        public SizeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
