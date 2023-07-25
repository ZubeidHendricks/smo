using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NPOMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected RepositoryContext RepositoryContext { get; set; }

		public BaseRepository(RepositoryContext repositoryContext)
		{
			this.RepositoryContext = repositoryContext;
		}

		protected BaseRepository(RepositoryContext repositoryContext, IMemoryCache cache)
		{
			RepositoryContext = repositoryContext;
		}

		public IQueryable<T> FindAll()
		{
			return this.RepositoryContext.Set<T>().AsNoTracking();
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
		}

		public void Create(T entity)
		{
			this.RepositoryContext.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			this.RepositoryContext.Set<T>().Update(entity);
		}

		public void Delete(T entity)
		{
			this.RepositoryContext.Set<T>().Remove(entity);
		}

		public void Save()
		{
			this.RepositoryContext.SaveChanges();
		}

		public async Task CreateAsync(T entity)
		{
			try
			{
				this.RepositoryContext.Set<T>().Add(entity);
				await this.RepositoryContext.SaveChangesAsync();
			}
			catch(Exception ex)
			{

			}
		}

		public async Task CreateAndDetachAsync(T entity)
		{
			this.RepositoryContext.Set<T>().Add(entity);
			await this.RepositoryContext.SaveChangesAsync();
			this.RepositoryContext.Entry(entity).State = EntityState.Detached;
		}

		public async Task UpdateAsync(T oldEntity, T newEntity, bool trackChanges, int currentUserId)
		{
			// Only add to AuditLog table if trackChanges is true
			if (trackChanges)
			{
				if (oldEntity != null)
				{
					this.RepositoryContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
					await this.RepositoryContext.SaveChangesAsync(Convert.ToInt32(currentUserId));
				}
			}
			else
			{
				this.RepositoryContext.Set<T>().Update(newEntity);
				await this.RepositoryContext.SaveChangesAsync();
			}
		}

		public async Task UpdateAsync(T newEntity, bool trackChanges, int currentUserId)
		{
			// Only add to AuditLog table if trackChanges is true
			if (trackChanges)
			{

				//this.RepositoryContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
				this.RepositoryContext.Set<T>().Update(newEntity);
				await this.RepositoryContext.SaveChangesAsync();

			}
			else
			{
				this.RepositoryContext.Set<T>().Update(newEntity);
				await this.RepositoryContext.SaveChangesAsync();
			}
		}

		public async Task DeleteAsync(T entity)
		{
			this.RepositoryContext.Set<T>().Remove(entity);
			await this.RepositoryContext.SaveChangesAsync();
		}

		public async Task SaveAsync()
		{
			await this.RepositoryContext.SaveChangesAsync();
		}

		public void InsertMultiItemsAsync(List<T> entity)
		{
			this.RepositoryContext.Set<T>().AddRange(entity);
			this.RepositoryContext.SaveChangesAsync();
		}


		public async Task UpdateAsync(T entity)
		{
			try
			{
				this.RepositoryContext.Set<T>().Update(entity);
				await this.RepositoryContext.SaveChangesAsync();

			}
			catch (Exception ex)
			{

			}
		}

		public async Task UpdateAsync1(T entity)
		{
			try
			{
				this.RepositoryContext.Set<T>().Update(entity);
				await this.RepositoryContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{

			}
		}
	}
}
