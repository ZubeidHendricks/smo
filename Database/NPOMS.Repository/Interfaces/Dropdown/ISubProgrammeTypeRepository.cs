﻿using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface ISubProgrammeTypeRepository : IBaseRepository<SubProgrammeType>
	{
		Task<IEnumerable<SubProgrammeType>> GetEntities(bool returnInactive);

		Task<IEnumerable<SubProgrammeType>> GetBySubProgrammeId(int subProgrammeId);
        Task<List<SubProgrammeType>> GetById(int id);
    }
}
