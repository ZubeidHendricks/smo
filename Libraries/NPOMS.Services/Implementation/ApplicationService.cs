using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Lookup;
using NPOMS.Services.Interfaces;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Core;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;

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
			IApplicationReviewerSatisfactionRepository applicationReviewerSatisfactionRepository
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

		public async Task CreateApplication(Application model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.IsActive = true;
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationRepository.CreateEntity(model);
		}

		public async Task UpdateApplicationStatus(Application model)
		{
			await _applicationRepository.UpdateEntity(model);
		}

		public async Task UpdateApplication(Application model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _applicationRepository.UpdateEntity(model);
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

			await _objectiveRepository.UpdateAsync(objective);
		}

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

			if (model.ActivitySubProgrammes.Count() > 0)
				await UpdateActivitySubProgrammeMappings(activity);

			if (model.ActivityFacilityLists.Count() > 0)
				await UpdateActivityFacilityListMappings(activity);

			await _activityRepository.UpdateEntity(activity);
		}

		private async Task UpdateActivitySubProgrammeMappings(Activity model)
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
					item.Id = mapping.Id;
			}
		}

		private async Task UpdateActivityFacilityListMappings(Activity model)
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
					item.Id = mapping.Id;
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
			await _resourceRepository.UpdateEntity(resource);
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

			await _sustainabilityPlanRepository.UpdateEntity(model);
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

		public async Task UpdateChangesRequired(ApplicationComment model, bool changesRequired)
		{
			ServiceProvisionStepsEnum step = (ServiceProvisionStepsEnum)model.ServiceProvisionStepId;

			switch (step)
			{
				case ServiceProvisionStepsEnum.Objectives:
					var objective = await _objectiveRepository.GetById(model.EntityId);
					objective.ChangesRequired = changesRequired;

					await _objectiveRepository.UpdateAsync(objective);
					break;
				case ServiceProvisionStepsEnum.Activities:
					var activity = await _activityRepository.GetById(model.EntityId);
					activity.ChangesRequired = changesRequired;

					await _activityRepository.UpdateAsync(activity);
					break;
				case ServiceProvisionStepsEnum.Sustainability:
					var sustainability = await _sustainabilityPlanRepository.GetById(model.EntityId);
					sustainability.ChangesRequired = changesRequired;

					await _sustainabilityPlanRepository.UpdateAsync(sustainability);
					break;
				case ServiceProvisionStepsEnum.Resourcing:
					var resource = await _resourceRepository.GetById(model.EntityId);
					resource.ChangesRequired = changesRequired;

					await _resourceRepository.UpdateAsync(resource);
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

			await _applicationApprovalRepository.UpdateEntity(model);
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
	}
}
