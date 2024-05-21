using BackEndApi.Helpers;
using BackEndApi.Models;

namespace BackEndApi.Interfaces
{
	public interface ICategoryRepository : IGenericRepository<Category>
	{
		Task<Category?> GetByIdAsync(int id);
	}
}
