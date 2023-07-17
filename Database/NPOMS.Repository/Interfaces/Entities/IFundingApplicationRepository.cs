using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IFundingApplicationRepository : IBaseRepository<FundingApplication>
	{
		Task<IEnumerable<FundingApplication>> GetAllFundingApplicationsAsync(int currentUserId, int roleId);

		Task<IEnumerable<FundingApplication>> ExportAllFundingApplicationsAsync();

		Task<FundingApplication> FundingApplicationExist(int programmeId, int applicationCategoryId, int currentUserId);

		Task CreateFundingApplication(FundingApplication model);

		Task<FundingApplication> GetFundingApplicationByIdAsync(int id);

		Task UpdateFundingApplication(FundingApplication model);

		Task DeleteFundingApplication(int fundingApplicationId, int currentUserId);
	}
}
