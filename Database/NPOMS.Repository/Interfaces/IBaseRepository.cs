using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
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

		Task UpdateAsync(T oldEntity, T newEntity, bool trackChanges, int currentUserId);

		Task DeleteAsync(T entity);

		Task SaveAsync();

		Task UpdateRangeAsync(IEnumerable<T> newEntities, int currentUserId);
        Task InsertMultiItemsAsync(List<T> entity);

        Task UpdateAsync(T entity);

		Task UpdateAsync1(T entity);
    }
}
