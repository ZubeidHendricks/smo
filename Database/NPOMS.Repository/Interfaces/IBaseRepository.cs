using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces
{
	public interface IBaseRepository<T>
    {
		IQueryable<T> FindAll();

		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

		void Create(T entity);

		void Update(T entity);

		void Delete(T entity);

		void Save();

		Task CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(T entity);

		Task SaveAsync();
	}
}
