﻿using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IFinancialYearRepository : IBaseRepository<FinancialYear>
	{
		Task<IEnumerable<FinancialYear>> GetEntities(bool returnInactive);

		Task<IEnumerable<FinancialYear>> GetFromCurrentFinancialYear();

		Task<FinancialYear> GetById(int id);
	}
}
