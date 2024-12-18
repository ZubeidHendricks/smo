using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NPOMS.Repository.Interfaces;
using System.Linq.Expressions;

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
			try
			{
                return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
            }
			catch(Exception x) {
				return null;
			}

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
					try {
                        this.RepositoryContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                        await this.RepositoryContext.SaveChangesAsync(Convert.ToInt32(currentUserId));
                    }
					catch (Exception ex)
					{
					
					}
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

        public async Task UpdateRangeAsync(IEnumerable<T> newEntities, int currentUserId)
		{
			try {
                // Update the entities in the DbContext
                this.RepositoryContext.Set<T>().UpdateRange(newEntities);

                // Save changes to the database
                await this.RepositoryContext.SaveChangesAsync();
            } catch(Exception ex) {
			throw ex;
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

		public async Task InsertMultiItemsAsync(List<T> entity)
		{
			try {
                this.RepositoryContext.Set<T>().AddRange(entity);
                await this.RepositoryContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				return;
			}
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
