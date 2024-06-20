using NPOMS.Domain.Budget;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Models;
using System.Threading.Tasks;

namespace NPOMS.Services.DenodoAPI.Interfaces
{
	public interface IDenodoService
	{
		Task<FacilityAPIWrapperModel> Get(DenodoFacilityResourceParameters denodoFacilityResourceParameters, string userIdentifier);

        Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear, string userIdentifier);
        Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear, string responsibilitylowestlevelcode, string objectivelowestlevelcode, string userIdentifier);
        Task<BudgetAdjustment> Create(string responsibilityCode, string objectiveCode, decimal amount);
        Task<BudgetAdjustment> ImportBudget(string responsibilityCode, string objectiveCode, string userIdentifier);
    }
}
