using NPOMS.Domain.Budget;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace NPOMS.Services.DenodoAPI.Interfaces
{
	public interface IDenodoService
	{
		Task<FacilityAPIWrapperModel> Get(DenodoFacilityResourceParameters denodoFacilityResourceParameters, string userIdentifier);

        Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear, string userIdentifier);
        Task<IEnumerable<ProgrammeBudget>> GetFilteredBudgets(int department, string financialYear);
        Task<BudgetAdjustment> Create(string responsibilityCode, string objectiveCode, decimal amount);
        Task<IEnumerable<ImportBudget>> ImportBudget(string responsibilityCode, string objectiveCode, string userIdentifier);
        Task <ProgrammeBudget> Update(string amount, int id,  string userIdentifier);
    }
}
