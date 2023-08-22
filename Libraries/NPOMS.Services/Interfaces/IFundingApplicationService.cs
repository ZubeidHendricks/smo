using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IFundingApplicationService
	{
		Task<IEnumerable<FundingApplication>> GetAllFundingApplications(string userIdentifier);

		Task<IEnumerable<FundingApplication>> ExportAllFundingApplications();

		Task<bool> CanCaptureFundingApplication(string userIdentifier, int programmeId, int applicationCategoryId);

		Task CreateFundingApplication(FundingApplication model, string userIdentifier);

		Task<FundingApplication> GetFundingApplicationById(int id, bool returnAllDetails);

		Task UpdateFundingApplication(FundingApplication model, string userIdentifier);

		Task UpdateFundingApplicationStatus(string userIdentifier, int fundingApplicationId, int statusId);

		Task UpdateStatus(string userIdentifier, int fundingApplicationId, int statusId, string comments, string section);

		Task DeleteFundingApplication(string userIdentifier, int fundingApplicationId);

		Task<ContactInformation> GetContactInformation(int fundingApplicationId);

		Task CreateContactInformation(ContactInformation model);

		Task UpdateContactInformation(ContactInformation model);

		Task<ProjectManagerContactInformation> GetProjectManagerContactInformation(int fundingApplicationId);

		Task CreateProjectManagerContactInformation(ProjectManagerContactInformation model);

		Task UpdateProjectManagerContactInformation(ProjectManagerContactInformation model);

		Task<BusinessInformation> GetBusinessInformation(int fundingApplicationId);

		Task CreateBusinessInformation(BusinessInformation model);

		Task UpdateBusinessInformation(BusinessInformation model);

		Task<ApplicationInformation> GetApplicationInformation(int fundingApplicationId);

		Task CreateApplicationInformation(ApplicationInformation model);

		Task UpdateApplicationInformation(ApplicationInformation model);

		//Task<IEnumerable<ApplicationInformationCommunicationType>> GetCommunicationTypeMapping(int applicationInformationId);

		//Task CreateCommunicationTypeMapping(ApplicationInformationCommunicationType model);

		//Task DeleteMapping(int id, FundingApplicationSectionEnum fundingApplicationSection);

		Task<OrganisationalProfile> GetOrganisationalProfile(int fundingApplicationId);

		Task CreateOrganisationalProfile(OrganisationalProfile model);

		Task UpdateOrganisationalProfile(OrganisationalProfile model);

		Task<IEnumerable<MemberDetail>> GetMemberDetails(int fundingApplicationId);

		Task CreateMemberDetail(MemberDetail model);

		Task UpdateMemberDetail(MemberDetail model);

		Task<ProjectDescription> GetProjectDescription(int fundingApplicationId);

		Task CreateProjectDescription(ProjectDescription model);

		Task UpdateProjectDescription(ProjectDescription model);

		Task<IEnumerable<BusinessesSupportedList>> GetBusinessSupported(int fundingApplicationId);

		Task CreateBusinessSupported(BusinessesSupportedList model);

		Task UpdateBusinessSupported(BusinessesSupportedList model);

		//Task<IEnumerable<ProjectDescriptionSectorGrouping>> GetSectorGroupingMapping(int projectDescriptionId);

		//Task CreateSectorGroupingMapping(ProjectDescriptionSectorGrouping model);

		Task<ProjectImpact> GetProjectImpact(int fundingApplicationId);

		Task CreateProjectImpact(ProjectImpact model);

		Task UpdateProjectImpact(ProjectImpact model);

		Task<IEnumerable<SuccessStory>> GetSuccessStories(int projectImpactId);

		Task CreateSuccessStory(SuccessStory model);

		Task UpdateSuccessStory(SuccessStory model);

		Task<MonitoringAndEvaluation> GetMonitoringAndEvaluation(int fundingApplicationId);

		Task CreateMonitoringAndEvaluation(MonitoringAndEvaluation model);

		Task UpdateMonitoringAndEvaluation(MonitoringAndEvaluation model);

		Task<IEnumerable<Budget>> GetBudgets(int fundingApplicationId);

		Task CreateBudget(Budget model);

		Task UpdateBudget(Budget model);

		Task<IEnumerable<Cashflow>> GetCashflows(int fundingApplicationId);

		Task CreateCashflow(Cashflow model);

		Task UpdateCashflow(Cashflow model);

		Task<IEnumerable<ImplementationTimeline>> GetImplementationTimelines(int fundingApplicationId);

		Task CreateImplementationTimeline(ImplementationTimeline model);

		Task UpdateImplementationTimeline(ImplementationTimeline model);

		Task<Declaration> GetDeclaration(int fundingApplicationId);

		Task CreateDeclaration(Declaration model);

		Task UpdateDeclaration(Declaration model);

		Task<MunicipalityInformation> GetMunicipalityInformation(int fundingApplicationId);

		Task CreateMunicipalityInformation(MunicipalityInformation model);

		Task UpdateMunicipalityInformation(MunicipalityInformation model);

		Task<BackgroundInformation> GetBackgroundInformation(int fundingApplicationId);

		Task CreateBackgroundInformation(BackgroundInformation model);

		Task UpdateBackgroundInformation(BackgroundInformation model);

		Task<FundingDescription> GetFundingDescription(int fundingApplicationId);

		Task CreateFundingDescription(FundingDescription model);

		Task UpdateFundingDescription(FundingDescription model);

		Task<IEnumerable<MunicipalResourceContribution>> GetMunicipalResourceContributions(int fundingApplicationId);

		Task CreateMunicipalResourceContribution(MunicipalResourceContribution model);

		Task UpdateMunicipalResourceContribution(MunicipalResourceContribution model);

		Task<IEnumerable<ImplementationRisk>> GetImplementationRisks(int fundingApplicationId);

		Task CreateImplementationRisk(ImplementationRisk model);

		Task UpdateImplementationRisk(ImplementationRisk model);

		Task<IEnumerable<DocumentChecklist>> GetDocumentChecklists(int fundingApplicationId);

		Task CreateDocumentChecklist(DocumentChecklist model);

		Task UpdateDocumentChecklist(DocumentChecklist model);
	}
}
