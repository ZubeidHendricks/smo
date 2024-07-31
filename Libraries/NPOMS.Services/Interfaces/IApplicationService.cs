using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Lookup;
using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IApplicationService
	{
		Task<IEnumerable<Application>> GetAllApplicationsAsync(string userIdentifier);

		Task<Application> GetApplicationById(int id);

		Task<Application> GetApplicationByNpoIdAndPeriodId(int NpoId, int applicationPeriodId);

		Task<IEnumerable<Application>> GetApplicationsByNpoId(int npoId);

        Task<Application> GetById(int ApplicationId);


        Task<Application> GetByIds(int npoId, int financialYearId, int applicationTypeId);

        Task UpdateFundingApplicationStatus(string userIdentifier, int fundingApplicationId, int statusId, int step);

        Task UpdateFundedApplicationScorecardCount(string userIdentifier, int fundingApplicationId);

        //Task<FundingApplication> GetFundingApplicationById(int id, bool returnAllDetails);

        Task CloneWorkplan(Application model, int financialYearId, string userIdentifier);

		Task CreateActivityRecipients(Application model, int financialYearId);

		Task CreateApplication(Application model, string userIdentifier);

		Task UpdateApplicationStatus(Application model, string userIdentifier);

		Task UpdateApplication(Application model, string userIdentifier);

		Task DeleteApplicationById(int id, string userIdentifier);
        Task UpdateInitiateScorecardValue(int id, string userIdentifier);
        Task UpdateCloseScorecardValue(int id, string userIdentifier);

        Task<IEnumerable<Objective>> GetAllObjectivesAsync(int NpoId, int applicationPeriodId);

		Task CreateObjective(Objective model, string userIdentifier);

		Task UpdateObjective(Objective model, string userIdentifier);


		//Task CreateProjectInformation(ProjectInformation model, string userIdentifier);

		//Task UpdateProjectInformation(ProjectInformation model, string userIdentifier);


		//Task CreateProjectImplementation(ProjectImplementation model, string userIdentifier);

		//Task UpdateProjectImplementation(ProjectImplementation model, string userIdentifier);

		Task<FundingApplicationDetail> GetFundingApplicationDetailsByApplicationId(int applicationId);

		Task CreateFundingApplicationDetails(FundingApplicationDetail model, string userIdentifier);

		Task UpdateFundingApplicationDetails(FundingApplicationDetail model, string userIdentifier);
		//Task AddProjectImplementation(ProjectImplementationViewModel model, string userIdentifier);

  //      Task UpdateProjectImplementation(ProjectImplementationViewModel model, string userIdentifier);

        Task<IEnumerable<Region>> GetRegions(int fundAppSDADetailId);

		Task<IEnumerable<ServiceDeliveryArea>> GetServiceDeliveryAreas(int fundAppSDADetailId);

		//Task<IEnumerable<FinancialDetail>> GetAllFinancialDetailsAsync(int NpoId, int applicationPeriodId);

		//      Task CreateFinancialDetail(FinancialDetail model, string userIdentifier);

		//      Task UpdateFinancialDetail(FinancialDetail model, string userIdentifier);

		Task CreateMonitoringEvaluation(MonitoringEvaluation model, string userIdentifier);

        Task UpdateMonitoringEvaluation(MonitoringEvaluation model, string userIdentifier);

        Task<IEnumerable<Activity>> GetAllActivitiesAsync(int NpoId, int applicationPeriodId);

		Task<Activity> GetActivityById(int id);

		Task CreateActivity(Activity model, string userIdentifier);

		Task UpdateActivity(Activity model, string userIdentifier);

		Task<IEnumerable<Resource>> GetAllResourcesAsync(int NpoId, int applicationPeriodId);

		Task CreateResource(Resource model, string userIdentifier);

		Task UpdateResource(Resource model, string userIdentifier);

		Task<IEnumerable<SustainabilityPlan>> GetAllSustainabilityPlansAsync(int NpoId, int applicationPeriodId);

		Task CreateSustainabilityPlan(SustainabilityPlan model, string userIdentifier);

		Task UpdateSustainabilityPlan(SustainabilityPlan model, string userIdentifier);

		Task<IEnumerable<FacilityList>> GetAssignedFacilitiesByNpoId(int NpoId);

		Task<IEnumerable<ApplicationComment>> GetAllApplicationComments(int applicationId);

		Task<IEnumerable<ApplicationComment>> GetApplicationComments(int applicationId, int serviceProvisionStepId, int entityId);

		Task CreateApplicationComment(ApplicationComment model, string userIdentifier);

		Task UpdateChangesRequired(ApplicationComment model, bool changesRequired, string userIdentifier);

        Task CreateApplicationAudit(ApplicationAudit model, string userIdentifier);

		Task<IEnumerable<ApplicationAudit>> GetApplicationAudits(int applicationId);

		Task<IEnumerable<ApplicationApproval>> GetApplicationApprovals(int applicationId);

		Task CreateApplicationApproval(ApplicationApproval model, string userIdentifier);

		Task UpdateApplicationApproval(ApplicationApproval model, string userIdentifier);

		Task<IEnumerable<ApplicationReviewerSatisfaction>> GetApplicationReviewerSatisfactions(int applicationId, int serviceProvisionStepId, int entityId);

		Task<IEnumerable<ApplicationReviewerSatisfaction>> GetReviewerSatisfactionByApplicationId(int applicationId);

		Task CreateApplicationReviewerSatisfaction(ApplicationReviewerSatisfaction model, string userIdentifier);
		Task GetByIds(int fundingApplicationId, bool v);

		//Task<IEnumerable<Place>> GetPlaces(List<int> sdaIds);

		//Task<IEnumerable<SubPlace>> GetSubplaces(List<int> placeIds);

		//Task<FundAppDetailViewModel> GetApplicationIDAsync(int bidId);

		Task<IEnumerable<MyContentLink>> GetMyContentLinks(int applicationId);

		Task CreateMyContentLink(MyContentLink model, string userIdentifier);

		Task UpdateMyContentLink(MyContentLink model, string userIdentifier);

		Task<ApplicationPeriod> GetApplicationPeriodById(int id);
	}
}
