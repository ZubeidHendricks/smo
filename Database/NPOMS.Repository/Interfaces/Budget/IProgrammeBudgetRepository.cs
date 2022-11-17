﻿using NPOMS.Domain.Budget;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Budget
{
	public interface IProgrammeBudgetRepository : IBaseRepository<ProgrammeBudget>
	{
		Task<IEnumerable<ProgrammeBudget>> GetProgrammeBudgetsByIds(int departmentId, int financialYearId);

		Task<ProgrammeBudget> GetProgrammeBudgetByProgrammeId(int programmeId, int financialYearId);
	}
}