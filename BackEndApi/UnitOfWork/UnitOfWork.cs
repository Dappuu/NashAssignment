using BackEndApi.Data;
using BackEndApi.Interfaces;
using BackEndApi.Repositories;

namespace BackEndApi.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public ICategoryRepository CategoryRepository { get; private set; }
		public IProductRepository ProductRepository { get; private set; }
		public ICommentRepository CommentRepository { get; private set; }
		public IProductSkuRepository ProductSkuRepository { get; private set; }
		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			CategoryRepository = new CategoryRepository(context);
			ProductRepository = new ProductRepository(context);
			CommentRepository = new CommentRepository(context);
			ProductSkuRepository = new ProductSkuRepository(context);
		}
		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
