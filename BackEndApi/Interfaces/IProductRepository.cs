using BackEndApi.Models;

namespace BackEndApi.Interfaces
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		public Task<Product?> GetInfoProduct(int id);
	}
}
