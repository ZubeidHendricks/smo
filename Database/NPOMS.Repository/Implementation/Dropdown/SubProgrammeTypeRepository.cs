﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
	public class SubProgrammeTypeRepository : BaseRepository<SubProgrammeType>, ISubProgrammeTypeRepository
	{
		#region Constructors

		public SubProgrammeTypeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<SubProgrammeType>> GetEntities(bool returnInactive)
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

		public async Task<IEnumerable<SubProgrammeType>> GetBySubProgrammeId(int subProgrammeId)
		{
			return await FindByCondition(x => x.SubProgrammeId.Equals(subProgrammeId) && x.IsActive).AsNoTracking().ToListAsync();
		}

        public async Task<List<SubProgrammeType>> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id) && x.IsActive).AsNoTracking().ToListAsync();
        }

        #endregion
    }
}
