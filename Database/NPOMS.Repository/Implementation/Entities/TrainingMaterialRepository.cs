﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class TrainingMaterialRepository : BaseRepository<TrainingMaterial>, ITrainingMaterialRepository
	{
		#region Constructors

		public TrainingMaterialRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<TrainingMaterial>> GetEntities(bool returnInactive)
		{
			if (returnInactive)
			{
				return await FindAll().AsNoTracking().OrderBy(x => x.Name).ToListAsync();
			}
			else
			{
				return await FindAll().Where(x => x.IsActive).AsNoTracking().OrderBy(x => x.Name).ToListAsync();
			}
		}

		#endregion
	}
}
