namespace BackEndApi.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		Task Save();
		ICategoryRepository CategoryRepository { get; }
		IProductRepository ProductRepository { get; }
		ICommentRepository CommentRepository { get; }
		IProductSkuRepository ProductSkuRepository { get; }
	}
}
