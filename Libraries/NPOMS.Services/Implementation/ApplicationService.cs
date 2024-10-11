using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Lookup;
using NPOMS.Domain.Mapping;
using NPOMS.Repository;
using NPOMS.Repository.Implementation.Dropdown;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Implementation.Mapping;
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

        private IDepartmentRepository _departmentRepository;
        private Repository.Interfaces.Dropdown.IProgrammeRepository _programmeRepository;
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
		private IBankDetailRepository _bankDetailRepository;
		private IMyContentLinkRepository _myContentLinkRepository;
		private readonly IFundAppRegionRepository _bidRegionRepository;
		private readonly IFundAppServiceDeliveryAreaRepository _BidServiceDeliveryAreaRepository;
		private IApplicationPeriodRepository _applicationPeriodRepository;
		private ISubRecipientRepository _subRecipientRepository;
		private ISubSubRecipientRepository _subSubRecipientRepository;
		private IActivityRecipientRepository _activityRecipientRepository;
        private IActivityDistrictRepository _activityDistrictRepository;
        private IActivityManicipalityRepository _activityManicipalityRepository;
        private IActivitySubDistrictRepository _activitySubDistrictRepository;
        private IActivitySubStructureRepository _activitySubStructureRepository;
        private IProjectImplementationPlaceRepository _implementationPlaceRepository;
        private IProjectImplementationSubPlaceRepository _implementationSubPlaceRepository;
		private IActivityAreaRepository _areaRepository;
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
			IBankDetailRepository bankDetailRepository,
			RepositoryContext repositoryContext,
			IMyContentLinkRepository myContentLinkRepository,
			IFundAppRegionRepository bidRegionRepository,
			IFundAppServiceDeliveryAreaRepository bidServiceDeliveryAreaRepository,
			IApplicationPeriodRepository applicationPeriodRepository,
			ISubRecipientRepository subRecipientRepository,
			ISubSubRecipientRepository subSubRecipientRepository,
			IActivityRecipientRepository activityRecipientRepository,
            IDepartmentRepository departmentRepository,
            Repository.Interfaces.Dropdown.IProgrammeRepository programmeRepository,
            IActivityDistrictRepository activityDistrictRepository,
            IActivityManicipalityRepository activityManicipalityRepository,
            IActivitySubDistrictRepository activitySubDistrictRepository,
            IActivitySubStructureRepository activitySubStructureRepository,
            IProjectImplementationSubPlaceRepository implementationSubPlaceRepository, 
			IProjectImplementationPlaceRepository implementationPlaceRepository,
            IActivityAreaRepository areaRepository
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
			_placeRepository = placeRepository;
			_subPlaceRepository = subPlaceRepository;
			_fundAppDetailRepository = fundAppDetailRepository;
			_bankDetailRepository = bankDetailRepository;
			_repositoryContext = repositoryContext;
			_myContentLinkRepository = myContentLinkRepository;
			_bidRegionRepository = bidRegionRepository;
			_BidServiceDeliveryAreaRepository = bidServiceDeliveryAreaRepository;
			_applicationPeriodRepository = applicationPeriodRepository;
			_subRecipientRepository = subRecipientRepository;
			_subSubRecipientRepository = subSubRecipientRepository;
			_activityRecipientRepository = activityRecipientRepository;
            _departmentRepository = departmentRepository;
            _programmeRepository = programmeRepository;
            _activityDistrictRepository = activityDistrictRepository;
			_activityManicipalityRepository = activityManicipalityRepository;
			_activitySubDistrictRepository = activitySubDistrictRepository;
			_activitySubStructureRepository = activitySubStructureRepository;
            _implementationSubPlaceRepository = implementationSubPlaceRepository;
            _implementationPlaceRepository = implementationPlaceRepository;
            _areaRepository = areaRepository;
        }

		#endregion

		#region Methods

		public async Task<IEnumerable<Application>> GetAllApplicationsAsync(string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var applications = await _applicationRepository.GetEntities();
            
			var appIdsDOH = applications.Where(x => x.ApplicationPeriod.DepartmentId == (int)DepartmentEnum.DOH && x.StatusId.Equals((int)StatusEnum.New)).Select(x => x.Id);
            var results = applications.Where(x => !appIdsDOH.Contains(x.Id));

            var departmentIds = await _departmentRepository.GetDepartmentIdOfLogggedInUserAsync(loggedInUser.Id);

            var programmesIds = await _programmeRepository.GetProgrammesIdOfLoggenInUserAsync(loggedInUser.Id);

            if (loggedInUser.Roles.Any(x => x.IsActive && x.RoleId.Equals((int)RoleEnum.SystemAdmin)))
            {
                return results;
            }
            if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.Admin))))
            {
				results = results.Where(x => departmentIds.Contains(x.ApplicationPeriod.DepartmentId));
						
                return results;
            }
            else if(loggedInUser.Roles.Any(x => x.IsActive && !x.RoleId.Equals((int)RoleEnum.Applicant)))
            {
                if (loggedInUser.Departments.Any(x => x.DepartmentId == 11))
				{
                    results = results.Where(x => departmentIds.Contains(x.ApplicationPeriod.DepartmentId));
                }
				else
				{
                    results = results.Where(x => departmentIds.Contains(x.ApplicationPeriod.DepartmentId)
                                             && programmesIds.Contains(x.ApplicationPeriod.ProgrammeId));
                }
                   
                return results;
            }
			else if(loggedInUser.Roles.Any(x => x.IsActive && x.RoleId.Equals((int)RoleEnum.Applicant)))
			{
                var mappings = await _userNpoRepository.GetApprovedEntities(loggedInUser.Id);
                var NpoIds = mappings.Select(x => x.NpoId);
                var assignedOrganisations = results.Where(x => NpoIds.Contains(x.NpoId));

                if (assignedOrganisations.Any())
                {
                    return assignedOrganisations;
                }
                else
                {
                    results = results.Where(x => x.CreatedUserId == loggedInUser.Id);
                    return results;
                }
            }
			else
			{
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

        public async Task<Application> GetApplicationByNpoIdAndPeriodIdAndYear(int NpoId, int applicationPeriodId, string year)
        {
            return await _applicationRepository.GetByNpoIdAndPeriodIdAndYear(NpoId, applicationPeriodId, year);
        }


        public async Task<IEnumerable<Application>> GetApplicationsByNpoId(int npoId)
		{
			return await _applicationRepository.GetByNpoId(npoId);
		}

		public async Task<Application> GetByIds(int npoId, int financialYearId, int applicationTypeId)
		{
			return await _applicationRepository.GetByIds(npoId, financialYearId, applicationTypeId);
		}

		public async Task<Application> GetById(int applicationId)
		{
			return await _applicationRepository.GetById(applicationId);
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

				foreach (var subRecipient in objective.SubRecipients)
				{
					var newSubRecipient = new SubRecipient
					{
						Objective = newObjective,
						OrganisationName = subRecipient.OrganisationName,
						FundingPeriodStartDate = subRecipient.FundingPeriodStartDate,
						FundingPeriodEndDate = subRecipient.FundingPeriodEndDate,
						Budget = subRecipient.Budget,
						RecipientTypeId = subRecipient.RecipientTypeId,
						IsActive = subRecipient.IsActive,
						CreatedUserId = loggedInUser.Id,
						CreatedDateTime = DateTime.Now
					};
					_repositoryContext.SubRecipients.Add(newSubRecipient);

					foreach (var subSubRecipient in subRecipient.SubSubRecipients)
					{
						var newSubSubRecipient = new SubSubRecipient
						{
							SubRecipient = newSubRecipient,
							OrganisationName = subSubRecipient.OrganisationName,
							FundingPeriodStartDate = subSubRecipient.FundingPeriodStartDate,
							FundingPeriodEndDate = subSubRecipient.FundingPeriodEndDate,
							Budget = subSubRecipient.Budget,
							RecipientTypeId = subSubRecipient.RecipientTypeId,
							IsActive = subSubRecipient.IsActive,
							CreatedUserId = loggedInUser.Id,
							CreatedDateTime = DateTime.Now
						};
						_repositoryContext.SubSubRecipients.Add(newSubSubRecipient);
					}
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

		public async Task CreateActivityRecipients(Application model, int financialYearId)
		{
			var existingApplication = await GetByIds(model.NpoId, financialYearId, (int)ApplicationTypeEnum.ServiceProvision);
			var existingObjectives = await GetAllObjectivesAsync(existingApplication.NpoId, existingApplication.ApplicationPeriodId);
			var existingActivities = await GetAllActivitiesAsync(existingApplication.NpoId, existingApplication.ApplicationPeriodId);

			var objectives = await GetAllObjectivesAsync(model.NpoId, model.ApplicationPeriodId);
			var activities = await GetAllActivitiesAsync(model.NpoId, model.ApplicationPeriodId);

			foreach (var existingActivity in existingActivities)
			{
				foreach (var existingActivityRecipient in existingActivity.ActivityRecipients)
				{
					var activity = activities.Where(x => x.ActivityListId.Equals(existingActivity.ActivityListId) && x.ActivityTypeId.Equals(existingActivity.ActivityTypeId) && x.TimelineStartDate.Equals(existingActivity.TimelineStartDate) && x.TimelineEndDate.Equals(existingActivity.TimelineEndDate) && x.Target.Equals(existingActivity.Target) && x.SuccessIndicator.Equals(existingActivity.SuccessIndicator)).FirstOrDefault();
					var objective = objectives.Where(x => x.Id.Equals(activity.ObjectiveId)).FirstOrDefault();

					var existingSR = new SubRecipient();

					var entityId = 0;
					RecipientTypeEnum recipientType = (RecipientTypeEnum)existingActivityRecipient.RecipientTypeId;

					switch (recipientType)
					{
						case RecipientTypeEnum.Primary:
							entityId = activity.ObjectiveId;
							break;
						case RecipientTypeEnum.SubRecipient:
							existingSR = await _subRecipientRepository.GetById(existingActivityRecipient.EntityId);
							var sr = objective.SubRecipients.Where(x => x.OrganisationName.Equals(existingSR.OrganisationName) && x.FundingPeriodStartDate.Equals(existingSR.FundingPeriodStartDate) && x.FundingPeriodEndDate.Equals(existingSR.FundingPeriodEndDate) && x.Budget.Equals(existingSR.Budget) && x.RecipientTypeId.Equals(existingSR.RecipientTypeId)).FirstOrDefault();

							entityId = sr.Id;
							break;
						case RecipientTypeEnum.SubSubRecipient:
							var existingSSR = await _subSubRecipientRepository.GetById(existingActivityRecipient.EntityId);

							existingSR = await _subRecipientRepository.GetById(existingSSR.SubRecipientId);
							var subRecipient = objective.SubRecipients.Where(x => x.OrganisationName.Equals(existingSR.OrganisationName) && x.FundingPeriodStartDate.Equals(existingSR.FundingPeriodStartDate) && x.FundingPeriodEndDate.Equals(existingSR.FundingPeriodEndDate) && x.Budget.Equals(existingSR.Budget) && x.RecipientTypeId.Equals(existingSR.RecipientTypeId)).FirstOrDefault();

							var ssr = subRecipient.SubSubRecipients.Where(x => x.OrganisationName.Equals(existingSSR.OrganisationName) && x.FundingPeriodStartDate.Equals(existingSSR.FundingPeriodStartDate) && x.FundingPeriodEndDate.Equals(existingSSR.FundingPeriodEndDate) && x.Budget.Equals(existingSSR.Budget) && x.RecipientTypeId.Equals(existingSSR.RecipientTypeId)).FirstOrDefault();
							entityId = ssr.Id;
							break;
					}

					var newActivityRecipient = new ActivityRecipient
					{
						ActivityId = activity.Id,
						RecipientTypeId = existingActivityRecipient.RecipientTypeId,
						EntityId = entityId,
						Entity = existingActivityRecipient.Entity,
						RecipientName = existingActivityRecipient.RecipientName
					};
					_repositoryContext.ActivityRecipients.Add(newActivityRecipient);
				}
			}

			await _repositoryContext.SaveChangesAsync();
		}

		public async Task CreateApplication(Application model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			model.ApplicationPeriod = null;
			model.IsActive = true;
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationRepository.CreateEntity(model);
		}

		public async Task UpdateFundingApplicationStatus(string userIdentifier, int fundingApplicationId, int statusId, int step)
		{
			var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
			var fundingApplication = await _applicationRepository.GetById(fundingApplicationId);
			fundingApplication.StatusId = statusId;
			fundingApplication.Step = step;
			fundingApplication.UpdatedUserId = currentUser.Id;
			fundingApplication.UpdatedDateTime = DateTime.Now;

			await _applicationRepository.UpdateAsync(fundingApplication);

		}

		public async Task UpdateFundedApplicationScorecardCount(string userIdentifier, int fundingApplicationId)
		{
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
            var fundingApplication = await _applicationRepository.GetById(fundingApplicationId);
            fundingApplication.ScorecardCount = fundingApplication.ScorecardCount + 1;
            fundingApplication.UpdatedUserId = currentUser.Id;
            fundingApplication.UpdatedDateTime = DateTime.Now;
            await _applicationRepository.UpdateAsync(fundingApplication);
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

		public async Task DeleteApplicationById(int id, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			var model = await _applicationRepository.GetById(id);
			model.IsActive = false;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;
			model.ApplicationPeriod = null;

			await _applicationRepository.UpdateEntity(model, loggedInUser.Id);
		}

        public async Task UpdateInitiateScorecardValue(int id, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            var model = await _applicationRepository.GetById(id);
            model.InitiateScorecard = 1;
            model.CloseScorecard = 1;
            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _applicationRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public async Task UpdateCloseScorecardValue(int id, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            var model = await _applicationRepository.GetById(id);
            model.InitiateScorecard = 0;
			model.CloseScorecard = 0;
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

					var subRecipients = await _subRecipientRepository.GetByObjectiveId(item.Id);

					foreach (var subRecipient in subRecipients)
					{
						var subSubRecipients = await _subSubRecipientRepository.GetBySubRecipientId(subRecipient.Id);
						subRecipient.SubSubRecipients = subSubRecipients.ToList();
					}

					item.SubRecipients = subRecipients.ToList();
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

		public async Task<FundingApplicationDetail> GetFundingApplicationDetailsByApplicationId(int applicationId)
		{
			var results = await _fundingApplicationDetailsRepository.GetByApplicationId(applicationId);
			return results;
		}

		public async Task CreateFundingApplicationDetails(FundingApplicationDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			//model.CreatedUserId = loggedInUser.Id;
			//model.CreatedDateTime = DateTime.Now;

			model.ApplicationDetails.FundAppSDADetail.DistrictCouncilId = model.ApplicationDetails.FundAppSDADetail.DistrictCouncil.Id;
			model.ApplicationDetails.FundAppSDADetail.LocalMunicipalityId = model.ApplicationDetails.FundAppSDADetail.LocalMunicipality.Id;

			model.ApplicationDetails.FundAppSDADetail.DistrictCouncil = null;
			model.ApplicationDetails.FundAppSDADetail.LocalMunicipality = null;

			foreach (var item in model.ApplicationDetails.FundAppSDADetail.Regions)
			{
				item.RegionId = item.Id;
				item.Id = 0;
			}

			foreach (var item in model.ApplicationDetails.FundAppSDADetail.ServiceDeliveryAreas)
			{
				item.ServiceDeliveryAreaId = item.Id;
				item.Id = 0;
			}

			await _fundingApplicationDetailsRepository.CreateEntity(model);
		}

		public async Task UpdateFundingApplicationDetails(FundingApplicationDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.ApplicationDetails.FundAppSDADetail.DistrictCouncilId = model.ApplicationDetails.FundAppSDADetail.DistrictCouncil.Id;
			model.ApplicationDetails.FundAppSDADetail.LocalMunicipalityId = model.ApplicationDetails.FundAppSDADetail.LocalMunicipality.Id;

			model.ApplicationDetails.FundAppSDADetail.DistrictCouncil = null;
			model.ApplicationDetails.FundAppSDADetail.LocalMunicipality = null;

			var bidRegions = await _bidRegionRepository.GetBidRegionByGeographicalDetailId(model.ApplicationDetails.FundAppSDADetail.Id);
			var bidSDAs = await _BidServiceDeliveryAreaRepository.GetBidServiceDeliveryAreaByGeographicalDetailId(model.ApplicationDetails.FundAppSDADetail.Id);

			await UpdateGeoDetails(model.ApplicationDetails.FundAppSDADetail, new FundAppSDADetail { Regions = bidRegions.ToList(), ServiceDeliveryAreas = bidSDAs.ToList() });
			model.ApplicationDetails = null;
			var oldEntity = await this._repositoryContext.FundingApplicationDetails.FindAsync(model.Id);
			await _fundingApplicationDetailsRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
		}

		//public async Task AddProjectImplementation(ProjectImplementationViewModel model, string userIdentifier)
		//{
  //          var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

  //          var imp = _mapper.Map<ProjectImplementation>(model);
  //          foreach (var placeDTO in model.Places)
  //          {
  //              var impPlace = new ProjectImplementationPlace
  //              {

  //                  ImplementationId = model.ID,
  //                  IsActive = true,
  //                  PlaceId = placeDTO.Id
  //              };

  //              imp.ImplementationPlaces.Add(impPlace);
  //          }

  //          foreach (var subPlaceDTO in model.SubPlaces)
  //          {
  //              var impSubPlace = new ProjectImplementationSubPlace
  //              {
  //                  SubPlace = await _subPlaceRepository.GetById(subPlaceDTO.Id),
  //                  SubPlaceId = subPlaceDTO.Id,
  //                  ImplementationId = model.ID,
  //                  IsActive = true
  //              };

  //              imp.ImplementationSubPlaces.Add(impSubPlace);
  //          }
  //          await _projectImplementationRepository.CreateEntity(imp);

  //      }

  //      public async Task UpdateProjectImplementation(ProjectImplementationViewModel model, string userIdentifier)
  //      {
  //          var subPlace = await _implementationSubPlaceRepository.GetAllImplementationSubPlaceByImplementationId(model.ID);
  //          var place = await _implementationPlaceRepository.GetAllImplementationPlaceByImplementationId(model.ID);


  //          var implementation = model;
  //          _mapper.Map(model, implementation);

  //         // implementation.SubPlaces = subPlace.ToList();

  //         // implementation.Places = place.ToList();

  //          // Create new mappings
  //          //foreach (var plac in model.Places)
  //          //{
  //          //    if (plac != null)
  //          //    {

  //          //        var mapping = await _implementationPlaceRepository.GetById(plac.Id, model.ID);
  //          //        if (mapping == null)

  //          //            implementation.Places(new ProjectImplementationPlace
  //          //            {
  //          //                Place = null,
  //          //                PlaceId = plac.Id,
  //          //                ImplementationId = model.ID,
  //          //            });
  //          //    }
  //          //}

  //          //// Update is active state
  //          //var newIds = model.Places.Select(x => x.Id);

  //          //foreach (var mapping in implementation.Places)
  //          //{
  //          //    mapping.Place = null;

  //          //    mapping.IsActive = newIds.Contains(mapping.PlaceId) ? true : false;
  //          //}

  //          //// sub place mapping
  //          //foreach (var sub in imple.SubPlaces)
  //          //{

  //          //    var map = await _implementationSubPlaceRepository.GetById(sub.Id, imple.ID);
  //          //    if (map == null)
  //          //        implementation.ImplementationSubPlaces.Add(new ProjectImplementationSubPlace
  //          //        {

  //          //            SubPlaceId = sub.Id,
  //          //            ImplementationId = imple.ID,
  //          //            IsActive = true,
  //          //            SubPlace = null

  //          //        });
  //          //}

  //          //// Update is active state
  //          //var frontEndIds = imple.SubPlaces.Select(x => x.Id);

  //          //foreach (var mapping in implementation.ImplementationSubPlaces)
  //          //{
  //          //    mapping.SubPlace = null;
  //          //    mapping.IsActive = frontEndIds.Contains(mapping.SubPlaceId) ? true : false;

  //          //}

  //          //var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
  //          //model.UpdatedUserId = loggedInUser.Id;
  //          //model.UpdatedDateTime = DateTime.Now;

  //          //await _projectImplementationRepository.UpdateAsync(model);
  //      }

        private async Task UpdateGeoDetails(FundAppSDADetail model, FundAppSDADetail existingRegionsAndSdas)
		{
			// Create new mappings
			foreach (var region in model.Regions)
			{
				var mapping = await _bidRegionRepository.GetById(region.Id, model.Id);

				if (mapping == null)
				{
					existingRegionsAndSdas.Regions.Add(new FundAppSDADetail_Region
					{
						FundAppSDADetailId = existingRegionsAndSdas.Id,
						IsActive = true,
						RegionId = region.Id,
					});

				}
			}

			// Update is active state
			var newIds = model.Regions.Select(x => x.Id);

			foreach (var mapping in existingRegionsAndSdas.Regions)
			{
				mapping.IsActive = newIds.Contains(mapping.RegionId) ? true : false;
				await _bidRegionRepository.UpdateAsync(mapping);

			}

			// service delivery area
			foreach (var item in model.ServiceDeliveryAreas)
			{
				var mapping = await _BidServiceDeliveryAreaRepository.GetById(item.Id, model.Id);

				if (mapping == null)
				{
					existingRegionsAndSdas.ServiceDeliveryAreas.Add(new FundAppServiceDeliveryArea
					{
						FundAppSDADetailId = model.Id,
						IsActive = true,
						ServiceDeliveryAreaId = item.Id,
					});
				}
			}

			// Update is active state
			var Ids = model.ServiceDeliveryAreas.Select(x => x.Id);

			foreach (var mapping in existingRegionsAndSdas.ServiceDeliveryAreas)
			{
				mapping.IsActive = Ids.Contains(mapping.ServiceDeliveryAreaId) ? true : false;
				await _BidServiceDeliveryAreaRepository.UpdateAsync(mapping);
			}
		}

		public async Task<IEnumerable<Region>> GetRegions(int fundAppSDADetailId)
		{
			var bidRegions = await _bidRegionRepository.GetBidRegionByGeographicalDetailId(fundAppSDADetailId);
			return bidRegions.Select(i => i.Region).ToList();
		}

		public async Task<IEnumerable<ServiceDeliveryArea>> GetServiceDeliveryAreas(int fundAppSDADetailId)
		{
			var serviceDeliveryAreas = await _BidServiceDeliveryAreaRepository.GetBidServiceDeliveryAreaByGeographicalDetailId(fundAppSDADetailId);
			return serviceDeliveryAreas.Select(i => i.ServiceDeliveryArea).ToList();
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

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await UpdateRecipientDetails(model, loggedInUser.Id);

			var oldEntity = await this._repositoryContext.Objectives.FindAsync(model.Id);
			await _objectiveRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
		}

		private async Task UpdateRecipientDetails(Objective model, int currentUserId)
		{
			foreach (var subRecipient in model.SubRecipients)
			{
				var oldEntitySR = await this._repositoryContext.SubRecipients.FindAsync(subRecipient.Id);

				if (oldEntitySR != null)
					await _subRecipientRepository.UpdateAsync(oldEntitySR, subRecipient, true, currentUserId);
				else
				{
					subRecipient.ObjectiveId = model.Id;
					await _subRecipientRepository.CreateAsync(subRecipient);
				}

				foreach (var subSubRecipient in subRecipient.SubSubRecipients)
				{
					var oldEntitySSR = await this._repositoryContext.SubSubRecipients.FindAsync(subSubRecipient.Id);

					if (oldEntitySSR != null)
						await _subSubRecipientRepository.UpdateAsync(oldEntitySSR, subSubRecipient, true, currentUserId);
					else
					{
						subSubRecipient.SubRecipientId = subRecipient.Id;
						await _subSubRecipientRepository.CreateAsync(subSubRecipient);
					}
				}
			}
		}

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

				var recipients = await _activityRecipientRepository.GetByActivityId(item.Id);
				item.ActivityRecipients = recipients.ToList();
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

            await UpdateActivityDistrictMappings(activity, loggedInUser.Id);

			await UpdateActivitySubDistrictMappings(activity, loggedInUser.Id);

			await UpdateActivitySubStructureMappings(activity, loggedInUser.Id);

			await UpdateActivityManicipalityMappings(activity, loggedInUser.Id);

			await UpdateActivityAreaMappings(activity, loggedInUser.Id);

			await _activityRecipientRepository.DeleteEntity(model.Id);

			foreach (var mapping in model.ActivityRecipients)
				await _activityRecipientRepository.CreateAsync(mapping);

			await _activityRepository.UpdateEntity(activity, loggedInUser.Id);
		}


        private async Task UpdateActivityDistrictMappings(Activity model, int currentUserId)
        {

            // Fetch existing mappings for the activity
            var mappings = await _activityDistrictRepository.GetByActivityId(model.Id, false);

            // Deactivate mappings that no longer exist in the current model and handle creating new ones
            foreach (var mapping in mappings)
            {
                var alreadyExists = model.ActivityDistrict.Any(x =>
                    x.ActivityId.Equals(mapping.ActivityId) &&
                    x.Name.Equals(mapping.Name));

                if (!alreadyExists)
                {
                    // Deactivate the mapping if it no longer exists in the current model
                    mapping.IsActive = false;
                    await _activityDistrictRepository.UpdateAsync(mapping);
                }
            }

            // Update or create mappings based on the current model
            foreach (var item in model.ActivityDistrict)
            {
                var existingMapping = await _activityDistrictRepository.GetByModel(item);
               // var existingMapping = await _activityDistrictRepository.GetByActivityAndDistrictName(item.ActivityId, item.Name);

                if (existingMapping == null)
                {
                    // Create new mapping if it does not exist
                    await _activityDistrictRepository.CreateAsync(item);
                }
                else
                {
                    // Ensure that the existing mapping is active if it exists
                    existingMapping.IsActive = true;
                    await _activityDistrictRepository.UpdateAsync(existingMapping);
                }
            }
        }

        private async Task UpdateActivityManicipalityMappings(Activity model, int currentUserId)
        {
            // Fetch existing mappings for the activity
            var mappings = await _activityManicipalityRepository.GetByActivityId(model.Id, false);

            // Deactivate mappings that no longer exist in the current model
            foreach (var mapping in mappings)
            {
                var alreadyExists = model.ActivityManicipality.Any(x =>
                    x.ActivityId.Equals(mapping.ActivityId) &&
                    x.Name.Equals(mapping.Name));

                if (!alreadyExists)
                {
					// Deactivate the mapping if it no longer exists in the current model
					mapping.IsActive = false;
                    await _activityManicipalityRepository.UpdateAsync(mapping);
                }
            }

            // Update or create mappings based on the current model
            foreach (var item in model.ActivityManicipality)
            {
                var existingMapping = await _activityManicipalityRepository.GetByModel(item);

                if (existingMapping == null)
                {
                    // Create new mapping if it does not exist
                    await _activityManicipalityRepository.CreateAsync(item);
                }
                else
                {
                    // Ensure that the existing mapping is active if it exists
                    existingMapping.IsActive = true;

                    await _activityManicipalityRepository.UpdateAsync(existingMapping);
                }
            }
        }

        private async Task UpdateActivitySubStructureMappings(Activity model, int currentUserId)
        {
            // Fetch existing mappings for the activity
            var mappings = await _activitySubStructureRepository.GetByActivityId(model.Id, false);

            // Deactivate mappings that no longer exist in the current model
            foreach (var mapping in mappings)
            {
                var alreadyExists = model.ActivitySubStructure.Any(x =>
                    x.ActivityId.Equals(mapping.ActivityId) &&
                    x.Name.Equals(mapping.Name));

                if (!alreadyExists)
                {
                    // Deactivate the mapping if it no longer exists in the current model
                    mapping.IsActive = false;
                    await _activitySubStructureRepository.UpdateAsync(mapping);
                }
            }

            // Update or create mappings based on the current model
            foreach (var item in model.ActivitySubStructure)
            {
                var existingMapping = await _activitySubStructureRepository.GetByModel(item);

                if (existingMapping == null)
                {
                    // Create new mapping if it does not exist
                    await _activitySubStructureRepository.CreateAsync(item);
                }
                else
                {
                    // Ensure that the existing mapping is active if it exists
                    existingMapping.IsActive = true;

                    await _activitySubStructureRepository.UpdateAsync(existingMapping);
                }
            }
        }

        private async Task UpdateActivitySubDistrictMappings(Activity model, int currentUserId)
        {
            // Fetch existing mappings for the activity
            var mappings = await _activitySubDistrictRepository.GetByActivityId(model.Id, false);

            // Deactivate mappings that no longer exist in the current model
            foreach (var mapping in mappings)
            {
                var alreadyExists = model.ActivitySubDistrict.Any(x =>
                    x.ActivityId.Equals(mapping.ActivityId) &&
                    x.Name.Equals(mapping.Name));

                if (!alreadyExists)
                {
                    // Deactivate the mapping if it no longer exists in the current model
                    mapping.IsActive = false;
                    await _activitySubDistrictRepository.UpdateAsync(mapping);
                }
            }

            // Update or create mappings based on the current model
            foreach (var item in model.ActivitySubDistrict)
            {
                var existingMapping = await _activitySubDistrictRepository.GetByModel(item);
                if (existingMapping == null)
                {
                    // Create new mapping if it does not exist
                    await _activitySubDistrictRepository.CreateAsync(item);
                }
                else
                {
                    // Ensure that the existing mapping is active if it exists
                    existingMapping.IsActive = true;

                    await _activitySubDistrictRepository.UpdateAsync(existingMapping);
                }
            }
        }
        private async Task UpdateActivityAreaMappings(Activity model, int currentUserId)
        {
            // Fetch existing mappings for the activity
            var mappings = await _areaRepository.GetByActivityId(model.Id, false);

            // Deactivate mappings that no longer exist in the current model
            foreach (var mapping in mappings)
            {
                var alreadyExists = model.ActivityArea.Any(x =>
                    x.ActivityId.Equals(mapping.ActivityId) && x.Name.Equals(mapping.Name));

                if (!alreadyExists)
                {
                    // Deactivate the mapping if it no longer exists in the current model
                    mapping.IsActive = false;
                    await _areaRepository.UpdateAsync(mapping);
                }
            }

            // Update or create mappings based on the current model
            foreach (var item in model.ActivityArea)
            {
                var existingMapping = await _areaRepository.GetByModel(item);

                if (existingMapping == null)
                {
                    // Create new mapping if it does not exist
                    await _areaRepository.CreateAsync(item);
                }
                else
                {
                    // Ensure that the existing mapping is active if it exists
                    existingMapping.IsActive = true;

                    await _areaRepository.UpdateAsync(existingMapping);
                }
            }
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

		public async Task<IEnumerable<ApplicationReviewerSatisfaction>> GetReviewerSatisfactionByApplicationId(int applicationId)
		{
			return await _applicationReviewerSatisfactionRepository.GetByApplicationId(applicationId);
		}

		public async Task CreateApplicationReviewerSatisfaction(ApplicationReviewerSatisfaction model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationReviewerSatisfactionRepository.CreateEntity(model);
		}

		public async Task<IEnumerable<MyContentLink>> GetMyContentLinks(int applicationId)
		{
			return await _myContentLinkRepository.GetByApplicationId(applicationId);
		}

		public async Task CreateMyContentLink(MyContentLink model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUser = null;
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _myContentLinkRepository.CreateAsync(model);
		}

		public async Task UpdateMyContentLink(MyContentLink model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUser = null;
			model.IsActive = false;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _myContentLinkRepository.UpdateAsync(model);
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

		public Task GetByIds(int fundingApplicationId, bool v)
		{
			throw new NotImplementedException();
		}

		public async Task<ApplicationPeriod> GetApplicationPeriodById(int id)
		{
			return await _applicationPeriodRepository.GetById(id);
		}

        public async  Task<IEnumerable<Activity>> AllActivitiesAsync()
        {
            var activities = await _activityRepository.GetByAll();

            foreach (var item in activities)
            {
                var subProgrammeMappings = await _activitySubProgrammeRepository.GetByActivityId(item.Id, true);
                item.ActivitySubProgrammes = subProgrammeMappings.ToList();

                var facilityListMappings = await _activityFacilityListRepository.GetByActivityId(item.Id, true);
                item.ActivityFacilityLists = facilityListMappings.ToList();

                var recipients = await _activityRecipientRepository.GetByActivityId(item.Id);
                item.ActivityRecipients = recipients.ToList();
            }

            return activities;
        }

        #endregion
    }
}
