using AutoMapper;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Lookup;
using NPOMS.Domain.Mapping;
using NPOMS.Repository;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class ApplicationService : IApplicationService
	{
		#region Fields

		private IApplicationRepository _applicationRepository;
		private IUserRepository _userRepository;
		private IObjectiveRepository _objectiveRepository;
		private IActivityRepository _activityRepository;
		private IResourceRepository _resourceRepository;
		private ISustainabilityPlanRepository _sustainabilityPlanRepository;
		private INpoProfileRepository _npoProfileRepository;
		private INpoProfileFacilityListRepository _npoProfileFacilityListRepository;
		private IObjectiveProgrammeRepository _objectiveProgrammeRepository;
		private IActivitySubProgrammeRepository _activitySubProgrammeRepository;
		private IApplicationCommentRepository _applicationCommentRepository;
		private IApplicationAuditRepository _applicationAuditRepository;
		private readonly IMapper _mapper;
		private IApplicationApprovalRepository _applicationApprovalRepository;
		private IActivityFacilityListRepository _activityFacilityListRepository;
		private IUserNpoRepository _userNpoRepository;
		private IApplicationReviewerSatisfactionRepository _applicationReviewerSatisfactionRepository;
        private IFundingApplicationDetailsRepository _fundingApplicationDetailsRepository;
		//private IFinancialDetailRepository _financialDetailRepository;
        private IProjectInformationRepository _projectInformationRepository;
        private IMonitoringEvaluationRepository _monitoringEvaluationRepository;
		private IProjectImplementationRepository _projectImplementationRepository;
        private IPlaceRepository _placeRepository;
        private ISubPlaceRepository _subPlaceRepository;
        private IFundAppSDADetailRepository _fundAppDetailRepository;



        private RepositoryContext _repositoryContext;

		#endregion

		#region Constructorrs

		public ApplicationService(
			IApplicationRepository applicationRepository,
			IUserRepository userRepository,
			IObjectiveRepository objectiveRepository,
			IActivityRepository activityRepository,
			IResourceRepository resourceRepository,
			ISustainabilityPlanRepository sustainabilityPlanRepository,
			INpoProfileRepository npoProfileRepository,
			INpoProfileFacilityListRepository npoProfileFacilityListRepository,
			IObjectiveProgrammeRepository objectiveProgrammeRepository,
			IActivitySubProgrammeRepository activitySubProgrammeRepository,
			IApplicationCommentRepository applicationCommentRepository,
			IApplicationAuditRepository applicationAuditRepository,
			IMapper mapper,
			IApplicationApprovalRepository applicationApprovalRepository,
			IActivityFacilityListRepository activityFacilityListRepository,
			IUserNpoRepository userNpoRepository,
			IApplicationReviewerSatisfactionRepository applicationReviewerSatisfactionRepository,
            IFundingApplicationDetailsRepository fundingApplicationDetailsRepository,
			//IFinancialDetailRepository financialDetailRepository,
			IProjectInformationRepository projectInformationRepository,
			IMonitoringEvaluationRepository monitoringEvaluationRepository,
			IProjectImplementationRepository projectImplementationRepository,
			IPlaceRepository placeRepository,
			ISubPlaceRepository subPlaceRepository,
			IFundAppSDADetailRepository fundAppDetailRepository,
            RepositoryContext repositoryContext
			)
		{
			_applicationRepository = applicationRepository;
			_userRepository = userRepository;
			_objectiveRepository = objectiveRepository;
			_activityRepository = activityRepository;
			_resourceRepository = resourceRepository;
			_sustainabilityPlanRepository = sustainabilityPlanRepository;
			_npoProfileRepository = npoProfileRepository;
			_npoProfileFacilityListRepository = npoProfileFacilityListRepository;
			_objectiveProgrammeRepository = objectiveProgrammeRepository;
			_activitySubProgrammeRepository = activitySubProgrammeRepository;
			_applicationCommentRepository = applicationCommentRepository;
			_applicationAuditRepository = applicationAuditRepository;
			_mapper = mapper;
			_applicationApprovalRepository = applicationApprovalRepository;
			_activityFacilityListRepository = activityFacilityListRepository;
			_userNpoRepository = userNpoRepository;
			_applicationReviewerSatisfactionRepository = applicationReviewerSatisfactionRepository;
            _fundingApplicationDetailsRepository = fundingApplicationDetailsRepository;
			//_financialDetailRepository= financialDetailRepository;
			_projectInformationRepository = projectInformationRepository;
			_monitoringEvaluationRepository = monitoringEvaluationRepository;
			_projectImplementationRepository = projectImplementationRepository;
			_placeRepository= placeRepository;
			_subPlaceRepository= subPlaceRepository;
			_fundAppDetailRepository= fundAppDetailRepository;
            _repositoryContext = repositoryContext;
		}

		#endregion

		#region Methods

		public async Task<IEnumerable<Application>> GetAllApplicationsAsync(string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var applications = await _applicationRepository.GetEntities();
			var results = applications.Where(x => !x.StatusId.Equals((int)StatusEnum.New));

			if (loggedInUser.Roles.Any(x => !x.RoleId.Equals((int)RoleEnum.Applicant)))
			{
				return results;
			}
			else
			{
				// Get assigned organisations
				var mappings = await _userNpoRepository.GetApprovedEntities(loggedInUser.Id);
				var NpoIds = mappings.Select(x => x.NpoId);
				var assignedOrganisations = results.Where(x => NpoIds.Contains(x.NpoId));
				return assignedOrganisations;
			}
		}

		public async Task<Application> GetApplicationById(int id)
		{
			return await _applicationRepository.GetById(id);
		}

		public async Task<Application> GetApplicationByNpoIdAndPeriodId(int NpoId, int applicationPeriodId)
		{
			return await _applicationRepository.GetByNpoIdAndPeriodId(NpoId, applicationPeriodId);
		}

		public async Task<IEnumerable<Application>> GetApplicationsByNpoId(int npoId)
		{
			return await _applicationRepository.GetByNpoId(npoId);
		}

		public async Task<Application> GetByIds(int npoId, int financialYearId, int applicationTypeId)
		{
			return await _applicationRepository.GetByIds(npoId, financialYearId, applicationTypeId);
		}

		public async Task CloneWorkplan(Application model, int financialYearId, string userIdentifier)
		{
			var existingApplication = await GetByIds(model.NpoId, financialYearId, (int)ApplicationTypeEnum.ServiceProvision);

			var objectives = await GetAllObjectivesAsync(existingApplication.NpoId, existingApplication.ApplicationPeriodId);
			var activities = await GetAllActivitiesAsync(existingApplication.NpoId, existingApplication.ApplicationPeriodId);
			var sustainabilityPlans = await GetAllSustainabilityPlansAsync(existingApplication.NpoId, existingApplication.ApplicationPeriodId);
			var resources = await GetAllResourcesAsync(existingApplication.NpoId, existingApplication.ApplicationPeriodId);

			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			foreach (var objective in objectives.Where(x => x.IsActive))
			{
				// Create objective...
				var newObjective = new Objective
				{
					ApplicationId = model.Id,
					Name = objective.Name,
					Description = objective.Description,
					FundingSource = objective.FundingSource,
					FundingPeriodStartDate = objective.FundingPeriodStartDate,
					FundingPeriodEndDate = objective.FundingPeriodEndDate,
					RecipientTypeId = objective.RecipientTypeId,
					Budget = objective.Budget,
					IsActive = objective.IsActive,
					CreatedUserId = loggedInUser.Id,
					CreatedDateTime = DateTime.Now,
					ChangesRequired = null,
					IsNew = null
				};
				_repositoryContext.Objectives.Add(newObjective);

				foreach (var objectiveProgramme in objective.ObjectiveProgrammes)
				{
					var newObjectiveProgramme = new ObjectiveProgramme
					{
						Objective = newObjective,
						ProgrammeId = objectiveProgramme.ProgrammeId,
						SubProgrammeId = objectiveProgramme.SubProgrammeId
					};
					_repositoryContext.ObjectiveProgrammes.Add(newObjectiveProgramme);
				}

				// Create activity linked to objective...
				foreach (var activity in activities.Where(x => x.ObjectiveId.Equals(objective.Id) && x.IsActive))
				{
					var newActivity = new Activity
					{
						ApplicationId = model.Id,
						Objective = newObjective,
						ActivityListId = activity.ActivityListId,
						ActivityTypeId = activity.ActivityTypeId,
						TimelineStartDate = activity.TimelineStartDate,
						TimelineEndDate = activity.TimelineEndDate,
						Target = activity.Target,
						SuccessIndicator = activity.SuccessIndicator,
						IsActive = activity.IsActive,
						CreatedUserId = loggedInUser.Id,
						CreatedDateTime = DateTime.Now,
						ChangesRequired = null,
						IsNew = null
					};
					_repositoryContext.Activities.Add(newActivity);

					foreach (var activitySubProgramme in activity.ActivitySubProgrammes.Where(x => x.IsActive))
					{
						var newActivitySubProgramme = new ActivitySubProgramme
						{
							Activity = newActivity,
							SubProgrammeId = activitySubProgramme.SubProgrammeId,
							IsActive = activitySubProgramme.IsActive
						};
						_repositoryContext.ActivitySubProgrammes.Add(newActivitySubProgramme);
					}

					foreach (var activityFacilityList in activity.ActivityFacilityLists.Where(x => x.IsActive))
					{
						var newActivityFacilityList = new ActivityFacilityList
						{
							Activity = newActivity,
							FacilityListId = activityFacilityList.FacilityListId,
							IsActive = activityFacilityList.IsActive
						};
						_repositoryContext.ActivityFacilityLists.Add(newActivityFacilityList);
					}

					// Create sustainability plan linked to activity...
					foreach (var plan in sustainabilityPlans.Where(x => x.ActivityId.Equals(activity.Id) && x.IsActive))
					{
						var newPlan = new SustainabilityPlan
						{
							ApplicationId = model.Id,
							Activity = newActivity,
							Description = plan.Description,
							Risk = plan.Risk,
							Mitigation = plan.Mitigation,
							IsActive = plan.IsActive,
							CreatedUserId = loggedInUser.Id,
							CreatedDateTime = DateTime.Now,
							ChangesRequired = null,
							IsNew = null
						};
						_repositoryContext.SustainabilityPlans.Add(newPlan);
					}

					// Create resource linked to activity...
					foreach (var resource in resources.Where(x => x.ActivityId.Equals(activity.Id) && x.IsActive))
					{
						var newResource = new Resource
						{
							ApplicationId = model.Id,
							Activity = newActivity,
							ResourceTypeId = resource.ResourceTypeId,
							ServiceTypeId = resource.ServiceTypeId,
							AllocationTypeId = resource.AllocationTypeId,
							Description = resource.Description,
							ProvisionTypeId = resource.ProvisionTypeId,
							ResourceListId = resource.ResourceListId,
							NumberOfResources = resource.NumberOfResources,
							IsActive = resource.IsActive,
							CreatedUserId = loggedInUser.Id,
							CreatedDateTime = DateTime.Now,
							ChangesRequired = null,
							IsNew = null
						};
						_repositoryContext.Resources.Add(newResource);
					}
				}
			}

			await _repositoryContext.SaveChangesAsync();
		}

		public async Task CreateApplication(Application model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.IsActive = true;
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationRepository.CreateEntity(model);
		}

		public async Task UpdateApplicationStatus(Application model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			await _applicationRepository.UpdateEntity(model, loggedInUser.Id);
		}

		public async Task UpdateApplication(Application model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _applicationRepository.UpdateEntity(model, loggedInUser.Id);
		}

		public async Task<IEnumerable<Objective>> GetAllObjectivesAsync(int NpoId, int applicationPeriodId)
		{
			var application = await _applicationRepository.GetByNpoIdAndPeriodId(NpoId, applicationPeriodId);

			if (application != null)
			{
				var objectives = await _objectiveRepository.GetEntities(application.Id);

				foreach (var item in objectives)
				{
					var mappings = await _objectiveProgrammeRepository.GetByObjectiveId(item.Id);
					item.ObjectiveProgrammes = mappings.ToList();
				}

				return objectives;
			}

			return null;
		}

        //public async Task<IEnumerable<FinancialDetail>> GetAllFinancialDetailsAsync(int NpoId, int applicationPeriodId)
        //{
        //    var application = await _applicationRepository.GetByNpoIdAndPeriodId(NpoId, applicationPeriodId);

        //    if (application != null)
        //    {
        //        var financialDetails = await _financialDetailRepository.GetEntities(application.Id);

        //        //foreach (var item in financialDetails)
        //        //{
        //        //    var mappings = await _objectiveProgrammeRepository.GetByObjectiveId(item.Id);
        //        //    item.ObjectiveProgrammes = mappings.ToList();
        //        //}

        //        return financialDetails;
        //    }

        //    return null;
        //}

        //public async Task CreateProjectImplementation(ProjectImplementation model, string userIdentifier)
        //{
        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //    model.CreatedUserId = loggedInUser.Id;
        //    model.CreatedDateTime = DateTime.Now;

        //    await _projectImplementationRepository.CreateEntity(model);
        //}


        public async Task CreateProjectInformation(ProjectInformation model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            //model.CreatedUserId = loggedInUser.Id;
            //model.CreatedDateTime = DateTime.Now;

            await _projectInformationRepository.CreateEntity(model);
        }

		public async Task CreateFundingApplicationDetails(FundingApplicationDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			//model.CreatedUserId = loggedInUser.Id;
			//model.CreatedDateTime = DateTime.Now;
	

			await _fundingApplicationDetailsRepository.CreateEntity(model);
		}

		//public async Task CreateFinancialDetail(FinancialDetail model, string userIdentifier)
  //      {
  //          var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

  //          model.CreatedUserId = loggedInUser.Id;
  //          model.CreatedDateTime = DateTime.Now;

  //          await _financialDetailRepository.CreateEntity(model);
  //      }

        public async Task CreateMonitoringEvaluation(MonitoringEvaluation model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _monitoringEvaluationRepository.CreateEntity(model);
        }

        public async Task CreateObjective(Objective model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _objectiveRepository.CreateEntity(model);
		}

		public async Task UpdateObjective(Objective model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			if (!model.IsActive)
				await DeleteActivities(model, loggedInUser);

			await _objectiveProgrammeRepository.DeleteEntity(model.Id);

			foreach (var mapping in model.ObjectiveProgrammes)
				await _objectiveProgrammeRepository.CreateAsync(mapping);

			var objective = _mapper.Map<Objective>(model);
			objective.UpdatedUserId = loggedInUser.Id;
			objective.UpdatedDateTime = DateTime.Now;

			var oldEntity = await this._repositoryContext.Objectives.FindAsync(model.Id);
			await _objectiveRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
		}

        //public async Task UpdateFundingApplicationDetails(FundingApplicationDetails model, string userIdentifier)
        //{
        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //    var fundAppDetails = _mapper.Map<FundingApplicationDetails>(model);
        //    fundAppDetails.UpdatedUserId = loggedInUser.Id;
        //    fundAppDetails.UpdatedDateTime = DateTime.Now;

        //    var oldEntity = await this._repositoryContext.FundingApplicationDetails.FindAsync(model.Id);
        //    await _fundingApplicationDetailsRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
        //}

        //public async Task UpdateProjectImplementation(ProjectImplementation model, string userIdentifier)
        //{
        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //    var projectImplementation = _mapper.Map<ProjectImplementation>(model);
        //    projectImplementation.UpdatedUserId = loggedInUser.Id;
        //    projectImplementation.UpdatedDateTime = DateTime.Now;

        //    var oldEntity = await this._repositoryContext.ProjectImplementations.FindAsync(model.Id);
        //    await _projectImplementationRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
        //}

        //public async Task UpdateProjectInformation(ProjectInformation model, string userIdentifier)
        //{
        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //    var projectInformation = _mapper.Map<ProjectInformation>(model);
        //    projectInformation.UpdatedUserId = loggedInUser.Id;
        //    projectInformation.UpdatedDateTime = DateTime.Now;

        //    var oldEntity = await this._repositoryContext.ProjectInformations.FindAsync(model.Id);
        //    await _projectInformationRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
        //}

        public async Task UpdateMonitoringEvaluation(MonitoringEvaluation model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            var objective = _mapper.Map<MonitoringEvaluation>(model);
            objective.UpdatedUserId = loggedInUser.Id;
            objective.UpdatedDateTime = DateTime.Now;

            var oldEntity = await this._repositoryContext.MonitoringEvaluations.FindAsync(model.Id);
            await _monitoringEvaluationRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
        }

        //public async Task UpdateFinancialDetail(FinancialDetail model, string userIdentifier)
        //{
        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

        //    var objective = _mapper.Map<FinancialDetail>(model);
        //    objective.UpdatedUserId = loggedInUser.Id;
        //    objective.UpdatedDateTime = DateTime.Now;

        //    var oldEntity = await this._repositoryContext.FinancialDetails.FindAsync(model.Id);
        //    await _financialDetailRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
        //}

        private async Task DeleteActivities(Objective model, User currentUser)
		{
			var activities = await _activityRepository.GetByObjectiveId(model.Id);

			foreach (var activity in activities)
			{
				activity.IsActive = false;
				activity.UpdatedUserId = currentUser.Id;
				activity.UpdatedDateTime = DateTime.Now;
				_activityRepository.Update(activity);

				await DeleteSustainabilityPlan(activity, currentUser);
				await DeleteResources(activity, currentUser);
			}
		}

		private async Task DeleteSustainabilityPlan(Activity model, User currentUser)
		{
			var sustainabilityPlans = await _sustainabilityPlanRepository.GetByActivityId(model.Id);

			foreach (var plan in sustainabilityPlans)
			{
				plan.IsActive = false;
				plan.UpdatedUserId = currentUser.Id;
				plan.UpdatedDateTime = DateTime.Now;
				_sustainabilityPlanRepository.Update(plan);
			}
		}

		private async Task DeleteResources(Activity model, User currentUser)
		{
			var resources = await _resourceRepository.GetByActivityId(model.Id);

			foreach (var resource in resources)
			{
				resource.IsActive = false;
				resource.UpdatedUserId = currentUser.Id;
				resource.UpdatedDateTime = DateTime.Now;
				_resourceRepository.Update(resource);
			}
		}

		public async Task<IEnumerable<Activity>> GetAllActivitiesAsync(int NpoId, int applicationPeriodId)
		{
			var application = await _applicationRepository.GetByNpoIdAndPeriodId(NpoId, applicationPeriodId);
			var activities = await _activityRepository.GetByApplicationId(application.Id);

			foreach (var item in activities)
			{
				var subProgrammeMappings = await _activitySubProgrammeRepository.GetByActivityId(item.Id, true);
				item.ActivitySubProgrammes = subProgrammeMappings.ToList();

				var facilityListMappings = await _activityFacilityListRepository.GetByActivityId(item.Id, true);
				item.ActivityFacilityLists = facilityListMappings.ToList();
			}

			return activities;
		}

		public async Task<Activity> GetActivityById(int id)
		{
			return await _activityRepository.GetById(id);
		}

		public async Task CreateActivity(Activity model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _activityRepository.CreateEntity(model);
		}

		public async Task UpdateActivity(Activity model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			if (!model.IsActive)
			{
				await DeleteSustainabilityPlan(model, loggedInUser);
				await DeleteResources(model, loggedInUser);
			}

			var activity = _mapper.Map<Activity>(model);
			activity.UpdatedUserId = loggedInUser.Id;
			activity.UpdatedDateTime = DateTime.Now;

			await UpdateActivitySubProgrammeMappings(activity, loggedInUser.Id);
			await UpdateActivityFacilityListMappings(activity, loggedInUser.Id);

			await _activityRepository.UpdateEntity(activity, loggedInUser.Id);
		}

		private async Task UpdateActivitySubProgrammeMappings(Activity model, int currentUserId)
		{
			var mappings = await _activitySubProgrammeRepository.GetByActivityId(model.Id, false);

			foreach (var mapping in mappings)
			{
				var alreadyExists = model.ActivitySubProgrammes.Any(x => x.ActivityId.Equals(mapping.ActivityId) && x.SubProgrammeId.Equals(mapping.SubProgrammeId));

				if (!alreadyExists)
					model.ActivitySubProgrammes.Add(new ActivitySubProgramme { ActivityId = mapping.ActivityId, SubProgrammeId = mapping.SubProgrammeId, IsActive = false });
			}

			foreach (var item in model.ActivitySubProgrammes)
			{
				var mapping = await _activitySubProgrammeRepository.GetByModel(item);

				if (mapping != null)
				{
					item.Id = mapping.Id;
					var oldEntity = await this._repositoryContext.ActivitySubProgrammes.FindAsync(mapping.Id);
					await _activitySubProgrammeRepository.UpdateAsync(oldEntity, item, true, currentUserId);
				}
				else
				{
					await _activitySubProgrammeRepository.CreateAsync(item);
				}
			}
		}

		private async Task UpdateActivityFacilityListMappings(Activity model, int currentUserId)
		{
			var mappings = await _activityFacilityListRepository.GetByActivityId(model.Id, false);

			foreach (var mapping in mappings)
			{
				var alreadyExists = model.ActivityFacilityLists.Any(x => x.ActivityId.Equals(mapping.ActivityId) && x.FacilityListId.Equals(mapping.FacilityListId));

				if (!alreadyExists)
					model.ActivityFacilityLists.Add(new ActivityFacilityList { ActivityId = mapping.ActivityId, FacilityListId = mapping.FacilityListId, IsActive = false });
			}

			foreach (var item in model.ActivityFacilityLists)
			{
				var mapping = await _activityFacilityListRepository.GetByModel(item);

				if (mapping != null)
				{
					item.Id = mapping.Id;
					var oldEntity = await this._repositoryContext.ActivityFacilityLists.FindAsync(mapping.Id);
					await _activityFacilityListRepository.UpdateAsync(oldEntity, item, true, currentUserId);
				}
				else
				{
					await _activityFacilityListRepository.CreateAsync(item);
				}
			}
		}

		public async Task<IEnumerable<Resource>> GetAllResourcesAsync(int NpoId, int applicationPeriodId)
		{
			var application = await _applicationRepository.GetByNpoIdAndPeriodId(NpoId, applicationPeriodId);
			var resources = await _resourceRepository.GetEntities(application.Id);

			return resources;
		}

		public async Task CreateResource(Resource model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _resourceRepository.CreateEntity(model);
		}

		public async Task UpdateResource(Resource model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var resource = _mapper.Map<Resource>(model);
			resource.ResourceType = null;
			resource.ServiceType = null;
			resource.AllocationType = null;
			resource.ProvisionType = null;
			resource.ResourceList = null;
			resource.UpdatedUserId = loggedInUser.Id;
			resource.UpdatedDateTime = DateTime.Now;
			await _resourceRepository.UpdateEntity(resource, loggedInUser.Id);
		}

		public async Task<IEnumerable<SustainabilityPlan>> GetAllSustainabilityPlansAsync(int NpoId, int applicationPeriodId)
		{
			var application = await _applicationRepository.GetByNpoIdAndPeriodId(NpoId, applicationPeriodId);
			return await _sustainabilityPlanRepository.GetEntities(application.Id);
		}

		public async Task CreateSustainabilityPlan(SustainabilityPlan model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _sustainabilityPlanRepository.CreateEntity(model);
		}

		public async Task UpdateSustainabilityPlan(SustainabilityPlan model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _sustainabilityPlanRepository.UpdateEntity(model, loggedInUser.Id);
		}

		public async Task<IEnumerable<FacilityList>> GetAssignedFacilitiesByNpoId(int NpoId)
		{
			var npoProfile = await _npoProfileRepository.GetByNpoId(NpoId);
			var mappings = await _npoProfileFacilityListRepository.GetByNpoProfileId(npoProfile.Id);
			return mappings.Select(x => x.FacilityList);
		}

		public async Task<IEnumerable<ApplicationComment>> GetAllApplicationComments(int applicationId)
		{
			return await _applicationCommentRepository.GetByApplicationId(applicationId);
		}

		public async Task<IEnumerable<ApplicationComment>> GetApplicationComments(int applicationId, int serviceProvisionStepId, int entityId)
		{
			return await _applicationCommentRepository.GetByIds(applicationId, serviceProvisionStepId, entityId);
		}

		public async Task CreateApplicationComment(ApplicationComment model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationCommentRepository.CreateEntity(model);
		}

		public async Task UpdateChangesRequired(ApplicationComment model, bool changesRequired, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			ServiceProvisionStepsEnum step = (ServiceProvisionStepsEnum)model.ServiceProvisionStepId;

			switch (step)
			{
				case ServiceProvisionStepsEnum.Objectives:
					var objective = await _objectiveRepository.GetById(model.EntityId);
					objective.ChangesRequired = changesRequired;

					var oldObjective = await this._repositoryContext.Objectives.FindAsync(model.EntityId);
					await _objectiveRepository.UpdateAsync(oldObjective, objective, true, loggedInUser.Id);
					break;
				case ServiceProvisionStepsEnum.Activities:
					var activity = await _activityRepository.GetById(model.EntityId);
					activity.ChangesRequired = changesRequired;

					var oldActivity = await this._repositoryContext.Activities.FindAsync(model.EntityId);
					await _activityRepository.UpdateAsync(oldActivity, activity, true, loggedInUser.Id);
					break;
				case ServiceProvisionStepsEnum.Sustainability:
					var sustainability = await _sustainabilityPlanRepository.GetById(model.EntityId);
					sustainability.ChangesRequired = changesRequired;

					var oldSustainability = await this._repositoryContext.SustainabilityPlans.FindAsync(model.EntityId);
					await _sustainabilityPlanRepository.UpdateAsync(oldSustainability, sustainability, true, loggedInUser.Id);
					break;
				case ServiceProvisionStepsEnum.Resourcing:
					var resource = await _resourceRepository.GetById(model.EntityId);
					resource.ChangesRequired = changesRequired;

					var oldResource = await this._repositoryContext.Resources.FindAsync(model.EntityId);
					await _resourceRepository.UpdateAsync(oldResource, resource, true, loggedInUser.Id);
					break;
			}
		}

        public async Task CreateApplicationAudit(ApplicationAudit model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationAuditRepository.CreateEntity(model);
		}

		public async Task<IEnumerable<ApplicationAudit>> GetApplicationAudits(int applicationId)
		{
			return await _applicationAuditRepository.GetByApplicationId(applicationId);
		}

		public async Task<IEnumerable<ApplicationApproval>> GetApplicationApprovals(int applicationId)
		{
			return await _applicationApprovalRepository.GetByApplicationId(applicationId);
		}

		public async Task CreateApplicationApproval(ApplicationApproval model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationApprovalRepository.CreateEntity(model);
		}

		public async Task UpdateApplicationApproval(ApplicationApproval model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.isActive = false;
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationApprovalRepository.UpdateEntity(model, loggedInUser.Id);
		}

		public async Task<IEnumerable<ApplicationReviewerSatisfaction>> GetApplicationReviewerSatisfactions(int applicationId, int serviceProvisionStepId, int entityId)
		{
			return await _applicationReviewerSatisfactionRepository.GetByIds(applicationId, serviceProvisionStepId, entityId);
		}

		public async Task CreateApplicationReviewerSatisfaction(ApplicationReviewerSatisfaction model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationReviewerSatisfactionRepository.CreateEntity(model);
		}

        #endregion

        #region Place-SubPlace
        public IEnumerable<SubPlace> GetSubplaces(List<int> placeIds)
        {
            var sublaces = _subPlaceRepository.FindAll().ToList();
            var filteredSuPlace = new List<SubPlace>();

            foreach (var SbPlace in sublaces)
            {
                foreach (var i in placeIds)
                {
                    if (SbPlace.PlaceId == i)
                    {
                        filteredSuPlace.Add(SbPlace);
                    }
                }
            }
            return filteredSuPlace;
        }


        public IEnumerable<Place> GetPlaces(List<int> sdaIds)
        {
            var filteredPlace = new List<Place>();
            var places = _placeRepository.FindAll().ToList();
            foreach (var place in places)
            {
                foreach (var i in sdaIds)
                {
                    if (place.ServiceDeliveryAreaId == i)
                    {
                        filteredPlace.Add(place);
                    }
                }
            }
            return filteredPlace;
        }

        #endregion
    }
}
