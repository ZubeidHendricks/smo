﻿using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface ILanguageRepository : IBaseRepository<Language>
	{
		Task<IEnumerable<Language>> GetEntities(bool returnInactive);
	}
}
