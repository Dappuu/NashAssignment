using BackEndApi.Models;

namespace BackEndApi.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<Comment?> GetByIdAsync(int id);
    }
}
