using BackEndApi.Data;
using BackEndApi.Interfaces;
using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Comment?> GetByIdAsync(int id)
        {
            var comment = await _context.Comments.Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
            return comment;
        }
    }
}
