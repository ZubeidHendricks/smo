using NPOMS.Domain.Budget;

namespace NPOMS.Repository.Interfaces.Budget
{
    public interface IProgrammeBudgetRepository : IBaseRepository<ProgrammeBudget>
	{
		Task<IEnumerable<ProgrammeBudget>> GetProgrammeBudgetsByIds(int departmentId, int financialYearId);
        Task<IEnumerable<ProgrammeBudget>> GetProgrammeBudgetsByIds(int departmentId, string financialYearId);
        Task<ProgrammeBudget> GetProgrammeBudgetByProgrammeId(int programmeId, int financialYearId); 
        Task<ProgrammeBudget> GetProgrammeBudgetById(int id);
        Task<ProgrammeBudget> GetByIds(int departmentId, string financialYear, int programmeId, int subProgrammeId, int subProgrammeTypeId);
    }
}
