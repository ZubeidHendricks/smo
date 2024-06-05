using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Models;
using System.Threading.Tasks;

namespace NPOMS.Services.DenodoAPI.Interfaces
{
	public interface IDenodoService
	{
		Task<FacilityAPIWrapperModel> Get(DenodoFacilityResourceParameters denodoFacilityResourceParameters);

        Task<BudgetAPIWrapperModel> GetBudgets(string department, string financialYear);
    }
}
