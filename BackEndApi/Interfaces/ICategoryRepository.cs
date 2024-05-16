using BackEndApi.Helpers;
using BackEndApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetAllAsync(QueryObject query);
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> GetByIdSubAsync(int id);
    }
}
