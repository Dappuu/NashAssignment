using BackEndApi.Models;

namespace BackEndApi.Interfaces
{
    public interface IProductSkuRepository : IGenericRepository<ProductSku>
    {
        public Task<ProductSku?> GetInfoProductSku(int id);
    }
}
