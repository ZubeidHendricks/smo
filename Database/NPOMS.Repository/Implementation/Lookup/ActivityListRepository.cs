﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Lookup;
using NPOMS.Repository.Interfaces.Lookup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Lookup
{
	public class ActivityListRepository : BaseRepository<ActivityList>, IActivityListRepository
	{
		#region Constructors

		public ActivityListRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ActivityList>> GetEntities(bool returnInactive)
		{
			if (returnInactive)
			{
				return await FindAll()
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
			else
			{
				return await FindAll()
								.Where(x => x.IsActive)
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
		}

		public async Task<IEnumerable<ActivityList>> SearchByName(string name)
		{
			return await FindByCondition(x => x.Name.Contains(name)).AsNoTracking().ToListAsync();
		}

        public async Task <ActivityList> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task CreateEntity(ActivityList model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(ActivityList model, int currentUserId)
		{
			await UpdateAsync(null, model, false, currentUserId);
		}

		public async Task DeleteEntity(int id, int currentUserId)
		{
			var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
			model.IsActive = false;

			await UpdateAsync(null, model, false, currentUserId);
		}

		public async Task<ActivityList> GetByName(string name)
		{
			return await FindByCondition(x => x.Name.Equals(name)).AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
