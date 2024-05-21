using System.Linq.Expressions;

namespace BackEndApi.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
		Task<List<TEntity>> GetAll(
			Expression<Func<TEntity, bool>>? filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			string includeProperties = "");
		Task<TEntity?> GetByID(int id);
		Task Insert(TEntity entity);
		void Delete(TEntity entityToDelete);
		void Update(TEntity entityToUpdate);
	}
}
