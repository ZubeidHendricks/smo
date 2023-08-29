using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class FundingApplicationService : IFundingApplicationService
	{
		private IFundingApplicationRepository _fundingApplicationRepository;
		private IProgrammeRepository _programmeRepository;
		private IContactInformationRepository _contactInformationRepository;
		private IProjectManagerContactInformationRepository _projectManagerContactInformationRepository;
		private IBusinessInformationRepository _businessInformationRepository;
		private IApplicationInformationRepository _applicationInformationRepository;
		private IOrganisationalProfileRepository _organisationalProfileRepository;
		private IProjectDescriptionRepository _projectDescriptionRepository;
		private IProjectImpactRepository _projectImpactRepository;
		private IMonitoringAndEvaluationRepository _monitoringAndEvaluationRepository;
		//private IBudgetRepository _budgetRepository;
		private ICashflowRepository _cashflowRepository;
		private IImplementationTimelineRepository _implementationTimelineRepository;
		//private IApplicationInformationCommunicationTypeRepository _communicationTypeMappingRepository;
	//	private IProjectDescriptionSectorGroupingRepository _sectorGroupingMappingRepository;
		private IMemberDetailRepository _memberDetailRepository;
		private ISuccessStoryRepository _successStoryRepository;
		private IDeclarationRepository _declarationRepository;
		private IImplementationRiskRepository _implementationRiskRepository;
		private IMunicipalResourceContributionRepository _municipalResourceContributionRepository;
		private IMunicipalityInformationRepository _municipalityInformationRepository;
		private IBackgroundInformationRepository _backgroundInformationRepository;
		private IFundingDescriptionRepository _fundingDescriptionRepository;
		private IDocumentChecklistRepository _documentChecklistRepository;
		private IUserRepository _userRepository;
		private IBusinessesSupportedListRepository _businessesSupportedListRepository;
		private object _communicationTypeMappingRepository;
		private object _sectorGroupingMappingRepository;

		public FundingApplicationService(
			IFundingApplicationRepository fundingApplicationRepository,
			IProgrammeRepository programmeRepository,
			IContactInformationRepository contactInformationRepository,
			IProjectManagerContactInformationRepository projectManagerContactInformationRepository,
			IBusinessInformationRepository businessInformationRepository,
			IApplicationInformationRepository applicationInformationRepository,
			IOrganisationalProfileRepository organisationalProfileRepository,
			IProjectDescriptionRepository projectDescriptionRepository,
			IProjectImpactRepository projectImpactRepository,
			IMonitoringAndEvaluationRepository monitoringAndEvaluationRepository,
			//IBudgetRepository budgetRepository,
			ICashflowRepository cashflowRepository,
			IImplementationTimelineRepository implementationTimelineRepository,
			//IApplicationInformationCommunicationTypeRepository communicationTypeMappingRepository,
			//IProjectDescriptionSectorGroupingRepository sectorGroupingMappingRepository,
			IMemberDetailRepository memberDetailRepository,
			ISuccessStoryRepository successStoryRepository,
			IDeclarationRepository declarationRepository,
			IImplementationRiskRepository implementationRiskRepository,
			IMunicipalResourceContributionRepository municipalResourceContributionRepository,
			IMunicipalityInformationRepository municipalityInformationRepository,
			IBackgroundInformationRepository backgroundInformationRepository,
			IFundingDescriptionRepository fundingDescriptionRepository,
			IDocumentChecklistRepository documentChecklistRepository,
			IUserRepository userRepository,
			IBusinessesSupportedListRepository businessesSupportedListRepository)
		{
			_fundingApplicationRepository = fundingApplicationRepository;
			_programmeRepository = programmeRepository;
			_contactInformationRepository = contactInformationRepository;
			_projectManagerContactInformationRepository = projectManagerContactInformationRepository;
			_businessInformationRepository = businessInformationRepository;
			_applicationInformationRepository = applicationInformationRepository;
			_organisationalProfileRepository = organisationalProfileRepository;
			_projectDescriptionRepository = projectDescriptionRepository;
			_projectImpactRepository = projectImpactRepository;
			_monitoringAndEvaluationRepository = monitoringAndEvaluationRepository;
			//_budgetRepository = budgetRepository;
			_cashflowRepository = cashflowRepository;
			_implementationTimelineRepository = implementationTimelineRepository;
			//_communicationTypeMappingRepository = communicationTypeMappingRepository;
			//_sectorGroupingMappingRepository = sectorGroupingMappingRepository;
			_memberDetailRepository = memberDetailRepository;
			_successStoryRepository = successStoryRepository;
			_declarationRepository = declarationRepository;
			_implementationRiskRepository = implementationRiskRepository;
			_municipalResourceContributionRepository = municipalResourceContributionRepository;
			_municipalityInformationRepository = municipalityInformationRepository;
			_backgroundInformationRepository = backgroundInformationRepository;
			_fundingDescriptionRepository = fundingDescriptionRepository;
			_documentChecklistRepository = documentChecklistRepository;
			_userRepository = userRepository;
			_businessesSupportedListRepository = businessesSupportedListRepository;
		}

		public async Task<IEnumerable<FundingApplication>> GetAllFundingApplications(string userIdentifier)
		{
			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			return await _fundingApplicationRepository.GetAllFundingApplicationsAsync(currentUser.Id, currentUser.Roles[0].RoleId);
		}

		public async Task<IEnumerable<FundingApplication>> ExportAllFundingApplications()
		{
			return await _fundingApplicationRepository.ExportAllFundingApplicationsAsync();
		}

		public async Task<bool> CanCaptureFundingApplication(string userIdentifier, int programmeId, int applicationCategoryId)
		{
			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			var results = await _fundingApplicationRepository.FundingApplicationExist(programmeId, applicationCategoryId, currentUser.Id);

			if (results != null)
				return false;
			else
				return true;
		}

		public async Task CreateFundingApplication(FundingApplication model, string userIdentifier)
		{
			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			model.CreatedUserId = currentUser.Id;
			model.IsActive = true;

			await _fundingApplicationRepository.CreateFundingApplication(model);
		}

		public async Task<FundingApplication> GetFundingApplicationById(int id, bool returnAllDetails)
		{
			var result = await _fundingApplicationRepository.GetFundingApplicationByIdAsync(id);

			if (result != null && returnAllDetails)
			{
				result.Programme = await _programmeRepository.GetProgrammeByIdAsync(result.ProgrammeId);
				//result.FundingApplicationApplicationCategoryMappings = await _applicationCategoryRepository.GetByIdAsync(result.ApplicationCategoryId);					
				result.ContactInformation = await _contactInformationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.ProjectManagerContactInformation = await _projectManagerContactInformationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.BusinessInformation = await _businessInformationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.ApplicationInformation = await _applicationInformationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.OrganisationalProfile = await _organisationalProfileRepository.GetByFundingApplicationIdAsync(result.Id);
				result.ProjectDescription = await _projectDescriptionRepository.GetByFundingApplicationIdAsync(result.Id);
				result.ProjectImpact = await _projectImpactRepository.GetByFundingApplicationIdAsync(result.Id);
				result.MonitoringAndEvaluation = await _monitoringAndEvaluationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.Declaration = await _declarationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.MunicipalityInformation = await _municipalityInformationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.BackgroundInformation = await _backgroundInformationRepository.GetByFundingApplicationIdAsync(result.Id);
				result.FundingDescription = await _fundingDescriptionRepository.GetByFundingApplicationIdAsync(result.Id);

			//	var budgets = await _budgetRepository.GetByFundingApplicationIdAsync(result.Id);
				var cashflows = await _cashflowRepository.GetByFundingApplicationIdAsync(result.Id);
				var timelines = await _implementationTimelineRepository.GetByFundingApplicationIdAsync(result.Id);
				var implementationRisks = await _implementationRiskRepository.GetByFundingApplicationIdAsync(result.Id);
				var municipalResourceContributions = await _municipalResourceContributionRepository.GetByFundingApplicationIdAsync(result.Id);
				var documentChecklist = await _documentChecklistRepository.GetByFundingApplicationIdAsync(result.Id);

			//	result.Budgets = budgets.ToList();
				result.Cashflows = cashflows.ToList();
				result.ImplementationTimelines = timelines.ToList();
				result.ImplementationRisks = implementationRisks.ToList();
				result.MunicipalResourceContributions = municipalResourceContributions.ToList();
				result.DocumentChecklists = documentChecklist.ToList();
			}

			return result;
		}

		public async Task UpdateFundingApplication(FundingApplication model, string userIdentifier)
		{
			await UpdateMappings(model);

			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			model.UpdatedUserId = currentUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _fundingApplicationRepository.UpdateFundingApplication(model);
		}

		private async Task UpdateMappings(FundingApplication model)
		{
			//if (model.ApplicationInformation != null)
			//{
			//	var communicationTypeMappings = await _communicationTypeMappingRepository.GetMappingsByIdAsync(model.ApplicationInformation.Id);
			//	if (communicationTypeMappings.Count() > 0)
			//	{
			//		var existingIds = communicationTypeMappings.Select(x => x.CommunicationTypeId);
			//		var newIds = model.ApplicationInformation.CommunicationTypeMappings.Select(x => x.CommunicationTypeId);

			//		//foreach (var mappingId in existingIds)
			//		//{
			//		//	if (!newIds.Contains(mappingId))
			//		//		await _communicationTypeMappingRepository.DeleteMappingByIdAsync(model.ApplicationInformation.Id, Convert.ToInt32(mappingId));
			//		//}
			//	}
			//}

			if (model.ProjectDescription != null)
			{
				//var sectorGroupingMappings = await _sectorGroupingMappingRepository.GetMappingsByIdAsync(model.ProjectDescription.Id);
				//if (sectorGroupingMappings.Count() > 0)
				//{
				//	var existingIds = sectorGroupingMappings.Select(x => x.SectorGroupingId);
				//	var newIds = model.ProjectDescription.SectorGroupingMappings.Select(x => x.SectorGroupingId);

				//	//foreach (var mappingId in existingIds)
				//	//{
				//	//	if (!newIds.Contains(mappingId))
				//	//		await _sectorGroupingMappingRepository.DeleteMappingByIdAsync(model.ProjectDescription.Id, Convert.ToInt32(mappingId));
				//	//}
				//}

				var businessesSupported = await _businessesSupportedListRepository.GetByProjectDescriptionIdAsync(model.ProjectDescription.Id);
				if (businessesSupported.Count() > 0)
				{
					var existingIds = businessesSupported.Select(x => x.Id);
					var newIds = model.ProjectDescription.BusinessesSupportedList.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _businessesSupportedListRepository.DeleteBusinessesSupportedListByIdAsync(Convert.ToInt32(id));
					}
				}
			}

			//var budgets = await _budgetRepository.GetByFundingApplicationIdAsync(model.Id);
			//if (budgets.Count() > 0)
			//{
			//	var existingIds = budgets.Select(x => x.Id);
			//	var newIds = model.Budgets.Select(x => x.Id);

			//	//foreach (var id in existingIds)
			//	//{
			//	//	if (!newIds.Contains(id))
			//	//		await _budgetRepository.DeleteBudgetByIdAsync(Convert.ToInt32(id));
			//	//}
			//}

			var cashflows = await _cashflowRepository.GetByFundingApplicationIdAsync(model.Id);
			if (cashflows.Count() > 0)
			{
				var existingIds = cashflows.Select(x => x.Id);
				var newIds = model.Cashflows.Select(x => x.Id);

				foreach (var id in existingIds)
				{
					if (!newIds.Contains(id))
						await _cashflowRepository.DeleteCashflowByIdAsync(Convert.ToInt32(id));
				}
			}

			var timelines = await _implementationTimelineRepository.GetByFundingApplicationIdAsync(model.Id);
			if (timelines.Count() > 0)
			{
				var existingIds = timelines.Select(x => x.Id);
				var newIds = model.ImplementationTimelines.Select(x => x.Id);

				foreach (var id in existingIds)
				{
					if (!newIds.Contains(id))
						await _implementationTimelineRepository.DeleteImplementationTimelineByIdAsync(Convert.ToInt32(id));
				}
			}

			if (model.OrganisationalProfile != null)
			{
				var memberDetails = await _memberDetailRepository.GetMemberDetailsByIdAsync(model.OrganisationalProfile.Id);
				if (memberDetails.Count() > 0)
				{
					var existingIds = memberDetails.Select(x => x.Id);
					var newIds = model.OrganisationalProfile.MemberDetails.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _memberDetailRepository.DeleteMemberDetailByIdAsync(Convert.ToInt32(id));
					}
				}
			}

			if (model.ProjectImpact != null)
			{
				var successStories = await _successStoryRepository.GetSuccessStoriesByIdAsync(model.ProjectImpact.Id);
				if (successStories.Count() > 0)
				{
					var existingIds = successStories.Select(x => x.Id);
					var newIds = model.ProjectImpact.SuccessStories.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _successStoryRepository.DeleteSuccessStoryByIdAsync(Convert.ToInt32(id));
					}
				}
			}

			if (model.ImplementationRisks != null)
			{
				var implementationRisks = await _implementationRiskRepository.GetByFundingApplicationIdAsync(model.Id);
				if (implementationRisks.Count() > 0)
				{
					var existingIds = implementationRisks.Select(x => x.Id);
					var newIds = model.ImplementationRisks.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _implementationRiskRepository.DeleteImplementationRiskByIdAsync(Convert.ToInt32(id));
					}
				}
			}

			if (model.MunicipalResourceContributions != null)
			{
				var resourceContributions = await _municipalResourceContributionRepository.GetByFundingApplicationIdAsync(model.Id);
				if (resourceContributions.Count() > 0)
				{
					var existingIds = resourceContributions.Select(x => x.Id);
					var newIds = model.MunicipalResourceContributions.Select(x => x.Id);

					foreach (var id in existingIds)
					{
						if (!newIds.Contains(id))
							await _municipalResourceContributionRepository.DeleteMunicipalResourceContributionByIdAsync(Convert.ToInt32(id));
					}
				}
			}
		}

		public async Task UpdateFundingApplicationStatus(string userIdentifier, int fundingApplicationId, int statusId)
		{
			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			var fundingApplication = await _fundingApplicationRepository.GetFundingApplicationByIdAsync(fundingApplicationId);
			fundingApplication.StatusId = statusId;
			fundingApplication.UpdatedUserId = currentUser.Id;
			fundingApplication.UpdatedDateTime = DateTime.Now;

			fundingApplication.FundingApplicationApplicationCategoryMappings = null;
			fundingApplication.CreatedUser = null;
			fundingApplication.UpdatedUser = null;
			fundingApplication.VerifiedUser = null;
			fundingApplication.ApprovedUser = null;

			await _fundingApplicationRepository.UpdateAsync(fundingApplication);

		}

		public async Task UpdateStatus(string userIdentifier, int fundingApplicationId, int statusId, string comments, string section)
		{
			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			var fundingApplication = await _fundingApplicationRepository.GetFundingApplicationByIdAsync(fundingApplicationId);
			fundingApplication.StatusId = statusId;

			if (section == "verify")
			{
				fundingApplication.VerifiedStatusId = statusId;
				fundingApplication.VerifiedComments = comments;
				fundingApplication.VerifiedUserId = currentUser.Id;
				fundingApplication.VerifiedDateTime = DateTime.Now;
			}

			if (section == "approve")
			{
				fundingApplication.ApprovedStatusId = statusId;
				fundingApplication.ApprovedComments = comments;
				fundingApplication.ApprovedUserId = currentUser.Id;
				fundingApplication.ApprovedDateTime = DateTime.Now;
			}

			await _fundingApplicationRepository.UpdateFundingApplication(fundingApplication);
		}

		public async Task DeleteFundingApplication(string userIdentifier, int fundingApplicationId)
		{
			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			await _fundingApplicationRepository.DeleteFundingApplication(fundingApplicationId, currentUser.Id);
		}

		public async Task<ContactInformation> GetContactInformation(int fundingApplicationId)
		{
			return await _contactInformationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateContactInformation(ContactInformation model)
		{
			await _contactInformationRepository.CreateAsync(model);
		}

		public async Task UpdateContactInformation(ContactInformation model)
		{
			await _contactInformationRepository.UpdateAsync(model);
		}

		public async Task<ProjectManagerContactInformation> GetProjectManagerContactInformation(int fundingApplicationId)
		{
			return await _projectManagerContactInformationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateProjectManagerContactInformation(ProjectManagerContactInformation model)
		{
			await _projectManagerContactInformationRepository.CreateAsync(model);
		}

		public async Task UpdateProjectManagerContactInformation(ProjectManagerContactInformation model)
		{
			await _projectManagerContactInformationRepository.UpdateAsync(model);
		}

		public async Task<BusinessInformation> GetBusinessInformation(int fundingApplicationId)
		{
			return await _businessInformationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateBusinessInformation(BusinessInformation model)
		{
			await _businessInformationRepository.CreateAsync(model);
		}

		public async Task UpdateBusinessInformation(BusinessInformation model)
		{
			await _businessInformationRepository.UpdateAsync(model);
		}

		public async Task<ApplicationInformation> GetApplicationInformation(int fundingApplicationId)
		{
			return await _applicationInformationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateApplicationInformation(ApplicationInformation model)
		{
			await _applicationInformationRepository.CreateAsync(model);
		}

		public async Task UpdateApplicationInformation(ApplicationInformation model)
		{
			await _applicationInformationRepository.UpdateAsync(model);
		}

		//public async Task<IEnumerable<ApplicationInformationCommunicationType>> GetCommunicationTypeMapping(int applicationInformationId)
		//{
		//	return await _communicationTypeMappingRepository.GetMappingsByIdAsync(applicationInformationId);
		//}

		//public async Task CreateCommunicationTypeMapping(ApplicationInformationCommunicationType model)
		//{
		//	await _communicationTypeMappingRepository.CreateAsync(model);
		//}

		//public async Task DeleteMapping(int id, FundingApplicationSectionEnum fundingApplicationSection)
		//{
		//	switch (fundingApplicationSection)
		//	{
		//		case FundingApplicationSectionEnum.CommunicationTypeMapping:
		//			{
		//				var mappings = await _communicationTypeMappingRepository.GetMappingsByIdAsync(id);

		//				foreach (var mapping in mappings)
		//				{
		//					await _communicationTypeMappingRepository.DeleteAsync(mapping);
		//				}

		//				break;
		//			}
		//		case FundingApplicationSectionEnum.SectorGroupingMapping:
		//			{
		//				var mappings = await _sectorGroupingMappingRepository.GetMappingsByIdAsync(id);

		//				foreach (var mapping in mappings)
		//				{
		//					await _sectorGroupingMappingRepository.DeleteAsync(mapping);
		//				}

		//				break;
		//			}
		//	}
		//}

		public async Task<OrganisationalProfile> GetOrganisationalProfile(int fundingApplicationId)
		{
			return await _organisationalProfileRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateOrganisationalProfile(OrganisationalProfile model)
		{
			await _organisationalProfileRepository.CreateAsync(model);
		}

		public async Task UpdateOrganisationalProfile(OrganisationalProfile model)
		{
			await _organisationalProfileRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<MemberDetail>> GetMemberDetails(int organisationalProfileId)
		{
			return await _memberDetailRepository.GetMemberDetailsByIdAsync(organisationalProfileId);
		}

		public async Task CreateMemberDetail(MemberDetail model)
		{
			await _memberDetailRepository.CreateAsync(model);
		}

		public async Task UpdateMemberDetail(MemberDetail model)
		{
			await _memberDetailRepository.UpdateAsync(model);
		}

		public async Task<ProjectDescription> GetProjectDescription(int fundingApplicationId)
		{
			return await _projectDescriptionRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateProjectDescription(ProjectDescription model)
		{
			await _projectDescriptionRepository.CreateAsync(model);
		}

		public async Task UpdateProjectDescription(ProjectDescription model)
		{
			await _projectDescriptionRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<BusinessesSupportedList>> GetBusinessSupported(int projectDescriptionId)
		{
			return await _businessesSupportedListRepository.GetByProjectDescriptionIdAsync(projectDescriptionId);
		}

		public async Task CreateBusinessSupported(BusinessesSupportedList model)
		{
			await _businessesSupportedListRepository.CreateAsync(model);
		}

		public async Task UpdateBusinessSupported(BusinessesSupportedList model)
		{
			await _businessesSupportedListRepository.UpdateAsync(model);
		}

		//public async Task<IEnumerable<ProjectDescriptionSectorGrouping>> GetSectorGroupingMapping(int projectDescriptionId)
		//{
		//	return await _sectorGroupingMappingRepository.GetMappingsByIdAsync(projectDescriptionId);
		//}

		//public async Task CreateSectorGroupingMapping(ProjectDescriptionSectorGrouping model)
		//{
		//	await _sectorGroupingMappingRepository.CreateAsync(model);
		//}

		public async Task<ProjectImpact> GetProjectImpact(int fundingApplicationId)
		{
			return await _projectImpactRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateProjectImpact(ProjectImpact model)
		{
			await _projectImpactRepository.CreateAsync(model);
		}

		public async Task UpdateProjectImpact(ProjectImpact model)
		{
			await _projectImpactRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<SuccessStory>> GetSuccessStories(int projectImpactId)
		{
			return await _successStoryRepository.GetSuccessStoriesByIdAsync(projectImpactId);
		}

		public async Task CreateSuccessStory(SuccessStory model)
		{
			await _successStoryRepository.CreateAsync(model);
		}

		public async Task UpdateSuccessStory(SuccessStory model)
		{
			await _successStoryRepository.UpdateAsync(model);
		}

		public async Task<MonitoringAndEvaluation> GetMonitoringAndEvaluation(int fundingApplicationId)
		{
			return await _monitoringAndEvaluationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateMonitoringAndEvaluation(MonitoringAndEvaluation model)
		{
			await _monitoringAndEvaluationRepository.CreateAsync(model);
		}

		public async Task UpdateMonitoringAndEvaluation(MonitoringAndEvaluation model)
		{
			await _monitoringAndEvaluationRepository.UpdateAsync(model);
		}

		//public async Task<IEnumerable<Budget>> GetBudgets(int fundingApplicationId)
		//{
		//	return await _budgetRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		//}

		//public async Task CreateBudget(Budget model)
		//{
		//	model.CreatedDateTime = DateTime.Now;
		//	model.IsActive = true;
		//	await _budgetRepository.CreateAsync(model);
		//}

		//public async Task UpdateBudget(Budget model)
		//{
		//	await _budgetRepository.UpdateAsync(model);
		//}

		public async Task<IEnumerable<Cashflow>> GetCashflows(int fundingApplicationId)
		{
			return await _cashflowRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateCashflow(Cashflow model)
		{
			model.CreatedDateTime = DateTime.Now;
			model.IsActive = true;
			await _cashflowRepository.CreateAsync(model);
		}

		public async Task UpdateCashflow(Cashflow model)
		{
			await _cashflowRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<ImplementationTimeline>> GetImplementationTimelines(int fundingApplicationId)
		{
			return await _implementationTimelineRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateImplementationTimeline(ImplementationTimeline model)
		{
			model.CreatedDateTime = DateTime.Now;
			model.IsActive = true;
			await _implementationTimelineRepository.CreateAsync(model);
		}

		public async Task UpdateImplementationTimeline(ImplementationTimeline model)
		{
			await _implementationTimelineRepository.UpdateAsync(model);
		}

		public async Task<Declaration> GetDeclaration(int fundingApplicationId)
		{
			return await _declarationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateDeclaration(Declaration model)
		{
			await _declarationRepository.CreateAsync(model);
		}

		public async Task UpdateDeclaration(Declaration model)
		{
			await _declarationRepository.UpdateAsync(model);
		}

		public async Task<MunicipalityInformation> GetMunicipalityInformation(int fundingApplicationId)
		{
			return await _municipalityInformationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateMunicipalityInformation(MunicipalityInformation model)
		{
			await _municipalityInformationRepository.CreateAsync(model);
		}

		public async Task UpdateMunicipalityInformation(MunicipalityInformation model)
		{
			await _municipalityInformationRepository.UpdateAsync(model);
		}

		public async Task<BackgroundInformation> GetBackgroundInformation(int fundingApplicationId)
		{
			return await _backgroundInformationRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateBackgroundInformation(BackgroundInformation model)
		{
			await _backgroundInformationRepository.CreateAsync(model);
		}

		public async Task UpdateBackgroundInformation(BackgroundInformation model)
		{
			await _backgroundInformationRepository.UpdateAsync(model);
		}

		public async Task<FundingDescription> GetFundingDescription(int fundingApplicationId)
		{
			return await _fundingDescriptionRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateFundingDescription(FundingDescription model)
		{
			await _fundingDescriptionRepository.CreateAsync(model);
		}

		public async Task UpdateFundingDescription(FundingDescription model)
		{
			await _fundingDescriptionRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<MunicipalResourceContribution>> GetMunicipalResourceContributions(int fundingApplicationId)
		{
			return await _municipalResourceContributionRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateMunicipalResourceContribution(MunicipalResourceContribution model)
		{
			await _municipalResourceContributionRepository.CreateAsync(model);
		}

		public async Task UpdateMunicipalResourceContribution(MunicipalResourceContribution model)
		{
			await _municipalResourceContributionRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<ImplementationRisk>> GetImplementationRisks(int fundingApplicationId)
		{
			return await _implementationRiskRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateImplementationRisk(ImplementationRisk model)
		{
			await _implementationRiskRepository.CreateAsync(model);
		}

		public async Task UpdateImplementationRisk(ImplementationRisk model)
		{
			await _implementationRiskRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<DocumentChecklist>> GetDocumentChecklists(int fundingApplicationId)
		{
			return await _documentChecklistRepository.GetByFundingApplicationIdAsync(fundingApplicationId);
		}

		public async Task CreateDocumentChecklist(DocumentChecklist model)
		{
			model.DocumentChecklistType = null;
			await _documentChecklistRepository.CreateAsync(model);
		}

		public async Task UpdateDocumentChecklist(DocumentChecklist model)
		{
			model.DocumentChecklistType = null;
			await _documentChecklistRepository.UpdateAsync(model);
		}

		public Task CreateCommunicationTypeMapping(ApplicationInformationCommunicationType model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteMapping(int id, FundingApplicationSectionEnum fundingApplicationSection)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ProjectDescriptionSectorGrouping>> GetSectorGroupingMapping(int projectDescriptionId)
		{
			throw new NotImplementedException();
		}

		public Task CreateSectorGroupingMapping(ProjectDescriptionSectorGrouping model)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Budget>> GetBudgets(int fundingApplicationId)
		{
			throw new NotImplementedException();
		}

		public Task CreateBudget(Budget model)
		{
			throw new NotImplementedException();
		}

		public Task UpdateBudget(Budget model)
		{
			throw new NotImplementedException();
		}
	}
}
