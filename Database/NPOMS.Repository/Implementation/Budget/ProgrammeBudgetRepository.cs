using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Budget;
using NPOMS.Repository.Interfaces.Budget;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Budget
{
	public class ProgrammeBudgetRepository : BaseRepository<ProgrammeBudget>, IProgrammeBudgetRepository
	{
		#region Constructors

		public ProgrammeBudgetRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ProgrammeBudget>> GetProgrammeBudgetsByIds(int departmentId, int financialYearId)
		{
			return await FindByCondition(x => x.DepartmentId.Equals(departmentId) && x.FinancialYearId.Equals(financialYearId) && x.IsActive)
							.AsNoTracking().ToListAsync();
		}

        public async Task<IEnumerable<ProgrammeBudget>> GetProgrammeBudgetsByIds(int departmentId, string financialYearId)
        {
            return await FindByCondition(x => x.DepartmentId.Equals(departmentId) && x.FinancialYearId.Equals(financialYearId) && x.IsActive)
                            .AsNoTracking().ToListAsync();
        }

        public async Task<ProgrammeBudget> GetProgrammeBudgetByProgrammeId(int programmeId, int financialYearId)
		{
			return await FindByCondition(x => x.ProgrammeId.Equals(programmeId) && x.FinancialYearId.Equals(financialYearId) && x.IsActive)
							.AsNoTracking().FirstOrDefaultAsync();
		}

        public async Task<ProgrammeBudget> GetProgrammeBudgetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id) && x.IsActive)
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
