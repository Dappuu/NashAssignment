using BackEndApi.Models;
using BackEndApi.Repositories;

namespace BackEndApi.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
        ICategoryRepository CategoryRepository { get;  }
        IProductRepository ProductRepository { get; }

    }
}
