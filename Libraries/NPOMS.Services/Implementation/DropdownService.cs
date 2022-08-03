using AutoMapper;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Lookup;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Lookup;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class DropdownService : IDropdownService
	{
		#region Fields

		private IMapper _mapper;
		private IRoleRepository _roleRepository;
		private IDepartmentRepository _departmentRepository;
		private IOrganisationTypeRepository _organisationTypeRepository;
		private ITitleRepository _titleRepository;
		private IPositionRepository _positionRepository;
		private IAccessStatusRepository _accessStatusRepository;
		private IProgrammeRepository _programmeRepository;
		private ISubProgrammeRepository _subProgrammeRepository;
		private IFinancialYearRepository _financialYearRepository;
		private IApplicationTypeRepository _applicationTypeRepository;
		private IRecipientTypeRepository _recipientTypeRepository;
		private IActivityTypeRepository _activityTypeRepository;
		private IResourceTypeRepository _resourceTypeRepository;
		private IServiceTypeRepository _serviceTypeRepository;
		private IAllocationTypeRepository _allocationTypeRepository;
		private IFacilityDistrictRepository _facilityDistrictRepository;
		private IFacilitySubDistrictRepository _facilitySubDistrictRepository;
		private IFacilityClassRepository _facilityClassRepository;
		private IFacilityListRepository _facilityListRepository;
		private IUserRepository _userRepository;
		private IDocumentTypeRepository _documentTypeRepository;
		private IFacilityTypeRepository _facilityTypeRepository;
		private IStatusRepository _statusRepository;
		private IActivityListRepository _activityListRepository;
		private IResourceListRepository _resourceListRepository;
		private IProvisionTypeRepository _provisionTypeRepository;
		private IUtilityRepository _utilityRepository;
		private ITrainingMaterialRepository _trainingMaterialRepository;

		#endregion

		#region Constructors

		public DropdownService(
			IMapper mapper,
			IRoleRepository roleRepository,
			IDepartmentRepository departmentRepository,
			IOrganisationTypeRepository organisationTypeRepository,
			ITitleRepository titleRepository,
			IPositionRepository positionRepository,
			IAccessStatusRepository accessStatusRepository,
			IProgrammeRepository programmeRepository,
			ISubProgrammeRepository subProgrammeRepository,
			IFinancialYearRepository financialYearRepository,
			IApplicationTypeRepository applicationTypeRepository,
			IRecipientTypeRepository recipientTypeRepository,
			IActivityTypeRepository activityTypeRepository,
			IResourceTypeRepository resourceTypeRepository,
			IServiceTypeRepository serviceTypeRepository,
			IAllocationTypeRepository allocationTypeRepository,
			IFacilityDistrictRepository facilityDistrictRepository,
			IFacilitySubDistrictRepository facilitySubDistrictRepository,
			IFacilityClassRepository facilityClassRepository,
			IFacilityListRepository facilityListRepository,
			IUserRepository userRepository,
			IDocumentTypeRepository documentTypeRepository,
			IFacilityTypeRepository facilityTypeRepository,
			IStatusRepository statusRepository,
			IActivityListRepository activityListRepository,
			IResourceListRepository resourceListRepository,
			IProvisionTypeRepository provisionTypeRepository,
			IUtilityRepository utilityRepository,
			ITrainingMaterialRepository trainingMaterialRepository)
		{
			_mapper = mapper;
			_roleRepository = roleRepository;
			_departmentRepository = departmentRepository;
			_organisationTypeRepository = organisationTypeRepository;
			_titleRepository = titleRepository;
			_positionRepository = positionRepository;
			_accessStatusRepository = accessStatusRepository;
			_programmeRepository = programmeRepository;
			_subProgrammeRepository = subProgrammeRepository;
			_financialYearRepository = financialYearRepository;
			_applicationTypeRepository = applicationTypeRepository;
			_recipientTypeRepository = recipientTypeRepository;
			_activityTypeRepository = activityTypeRepository;
			_resourceTypeRepository = resourceTypeRepository;
			_serviceTypeRepository = serviceTypeRepository;
			_allocationTypeRepository = allocationTypeRepository;
			_facilityDistrictRepository = facilityDistrictRepository;
			_facilitySubDistrictRepository = facilitySubDistrictRepository;
			_facilityClassRepository = facilityClassRepository;
			_facilityListRepository = facilityListRepository;
			_userRepository = userRepository;
			_documentTypeRepository = documentTypeRepository;
			_facilityTypeRepository = facilityTypeRepository;
			_statusRepository = statusRepository;
			_activityListRepository = activityListRepository;
			_resourceListRepository = resourceListRepository;
			_provisionTypeRepository = provisionTypeRepository;
			_utilityRepository = utilityRepository;
			_trainingMaterialRepository = trainingMaterialRepository;
		}

		#endregion

		#region Methods

		#region Role 

		public async Task<IEnumerable<Role>> GetRoles(bool returnInactive)
		{
			return await _roleRepository.GetEntities(returnInactive);
		}

		public async Task CreateRole(Role model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _roleRepository.CreateAsync(model);
		}

		public async Task UpdateRole(Role model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _roleRepository.UpdateAsync(model);
		}

		#endregion

		#region Department

		public async Task<IEnumerable<Department>> GetDepartments(bool returnInactive)
		{
			return await _departmentRepository.GetEntities(returnInactive);
		}

		public async Task CreateDepartment(Department model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _departmentRepository.CreateAsync(model);
		}

		public async Task UpdateDepartment(Department model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _departmentRepository.UpdateAsync(model);
		}

		#endregion

		#region Organisation Type

		public async Task<IEnumerable<OrganisationType>> GetOrganisationTypes(bool returnInactive)
		{
			return await _organisationTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateOrganisationType(OrganisationType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _organisationTypeRepository.CreateAsync(model);
		}

		public async Task UpdateOrganisationType(OrganisationType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _organisationTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Title

		public async Task<IEnumerable<Title>> GetTitles(bool returnInactive)
		{
			return await _titleRepository.GetEntities(returnInactive);
		}

		public async Task CreateTitle(Title model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _titleRepository.CreateAsync(model);
		}

		public async Task UpdateTitle(Title model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _titleRepository.UpdateAsync(model);
		}

		#endregion

		#region Position

		public async Task<IEnumerable<Position>> GetPositions(bool returnInactive)
		{
			return await _positionRepository.GetEntities(returnInactive);
		}

		public async Task CreatePosition(Position model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _positionRepository.CreateAsync(model);
		}

		public async Task UpdatePosition(Position model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _positionRepository.UpdateAsync(model);
		}

		#endregion

		#region Access Status

		public async Task<IEnumerable<AccessStatus>> GetAccessStatuses(bool returnInactive)
		{
			return await _accessStatusRepository.GetEntities(returnInactive);
		}

		public async Task CreateAccessStatus(AccessStatus model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _accessStatusRepository.CreateAsync(model);
		}

		public async Task UpdateAccessStatus(AccessStatus model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _accessStatusRepository.UpdateAsync(model);
		}

		#endregion

		#region Programme

		public async Task<IEnumerable<Programme>> GetProgrammes(bool returnInactive)
		{
			return await _programmeRepository.GetEntities(returnInactive);
		}

		public async Task CreateProgramme(Programme model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _programmeRepository.CreateAsync(model);
		}

		public async Task UpdateProgramme(Programme model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _programmeRepository.UpdateAsync(model);
		}

		#endregion

		#region Sub-Programme

		public async Task<IEnumerable<SubProgramme>> GetSubProgrammes(bool returnInactive)
		{
			return await _subProgrammeRepository.GetEntities(returnInactive);
		}

		public async Task CreateSubProgramme(SubProgramme model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _subProgrammeRepository.CreateAsync(model);
		}

		public async Task UpdateSubProgramme(SubProgramme model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _subProgrammeRepository.UpdateAsync(model);
		}

		#endregion

		#region Financial Year

		public async Task<IEnumerable<FinancialYear>> GetFinancialYears(bool returnInactive)
		{
			return await _financialYearRepository.GetEntities(returnInactive);
		}

		public async Task CreateFinancialYear(FinancialYear model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.StartDate = new DateTime(model.Year, 04, 01, 0, 0, 0);
			model.EndDate = new DateTime(model.Year, 03, 31, 23, 59, 59, 999).AddYears(1);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _financialYearRepository.CreateAsync(model);
		}

		public async Task UpdateFinancialYear(FinancialYear model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.StartDate = new DateTime(model.Year, 04, 01, 0, 0, 0);
			model.EndDate = new DateTime(model.Year, 03, 31, 23, 59, 59, 999).AddYears(1);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _financialYearRepository.UpdateAsync(model);
		}

		#endregion

		#region Application Type

		public async Task<IEnumerable<ApplicationType>> GetApplicationTypes(bool returnInactive)
		{
			return await _applicationTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateApplicationType(ApplicationType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationTypeRepository.CreateAsync(model);
		}

		public async Task UpdateApplicationType(ApplicationType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _applicationTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Recipient Type

		public async Task<IEnumerable<RecipientType>> GetRecipientTypes(bool returnInactive)
		{
			return await _recipientTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateRecipientType(RecipientType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _recipientTypeRepository.CreateAsync(model);
		}

		public async Task UpdateRecipientType(RecipientType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _recipientTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Activity Type

		public async Task<IEnumerable<ActivityType>> GetActivityTypes(bool returnInactive)
		{
			return await _activityTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateActivityType(ActivityType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _activityTypeRepository.CreateAsync(model);
		}

		public async Task UpdateActivityType(ActivityType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _activityTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Resource Type

		public async Task<IEnumerable<ResourceType>> GetResourceTypes(bool returnInactive)
		{
			return await _resourceTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateResourceType(ResourceType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _resourceTypeRepository.CreateAsync(model);
		}

		public async Task UpdateResourceType(ResourceType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _resourceTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Service Type

		public async Task<IEnumerable<ServiceType>> GetServiceTypes(bool returnInactive)
		{
			return await _serviceTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateServiceType(ServiceType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _serviceTypeRepository.CreateAsync(model);
		}

		public async Task UpdateServiceType(ServiceType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _serviceTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Allocation Type

		public async Task<IEnumerable<AllocationType>> GetAllocationTypes(bool returnInactive)
		{
			return await _allocationTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateAllocationType(AllocationType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _allocationTypeRepository.CreateAsync(model);
		}

		public async Task UpdateAllocationType(AllocationType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _allocationTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Facility District

		public async Task<IEnumerable<FacilityDistrict>> GetFacilityDistricts(bool returnInactive)
		{
			return await _facilityDistrictRepository.GetEntities(returnInactive);
		}

		public async Task CreateFacilityDistrict(FacilityDistrict model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _facilityDistrictRepository.CreateAsync(model);
		}

		public async Task UpdateFacilityDistrict(FacilityDistrict model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _facilityDistrictRepository.UpdateAsync(model);
		}

		#endregion

		#region Facility Sub-District

		public async Task<IEnumerable<FacilitySubDistrict>> GetFacilitySubDistricts(bool returnInactive)
		{
			return await _facilitySubDistrictRepository.GetEntities(returnInactive);
		}

		public async Task CreateFacilitySubDistrict(FacilitySubDistrict model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _facilitySubDistrictRepository.CreateAsync(model);
		}

		public async Task UpdateFacilitySubDistrict(FacilitySubDistrict model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _facilitySubDistrictRepository.UpdateAsync(model);
		}

		#endregion

		#region Facility Class

		public async Task<IEnumerable<FacilityClass>> GetFacilityClasses(bool returnInactive)
		{
			return await _facilityClassRepository.GetEntities(returnInactive);
		}

		public async Task CreateFacilityClass(FacilityClass model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _facilityClassRepository.CreateAsync(model);
		}

		public async Task UpdateFacilityClass(FacilityClass model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _facilityClassRepository.UpdateAsync(model);
		}

		#endregion

		#region Facility List

		public async Task<IEnumerable<FacilityList>> GetFacilityList(bool returnInactive)
		{
			return await _facilityListRepository.GetEntities(returnInactive);
		}

		public async Task<IEnumerable<FacilityList>> SearchFacilityByName(string name)
		{
			return await _facilityListRepository.SearchByName(name);
		}

		public async Task CreateFacility(FacilityList model, string userIdentifier)
		{
			var facility = await _facilityListRepository.GetByProperties(model);

			if (facility == null)
			{
				var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

				model.CreatedUserId = loggedInUser.Id;
				model.CreatedDateTime = DateTime.Now;

				await _facilityListRepository.CreateEntity(model);
			}
		}

		#endregion

		#region Document Type

		public async Task<IEnumerable<DocumentType>> GetDocumentTypes(bool returnInactive)
		{
			return await _documentTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateDocumentType(DocumentType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _documentTypeRepository.CreateAsync(model);
		}

		public async Task UpdateDocumentType(DocumentType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _documentTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Facility Type

		public async Task<IEnumerable<FacilityType>> GetFacilityTypes(bool returnInactive)
		{
			return await _facilityTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateFacilityType(FacilityType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _facilityTypeRepository.CreateAsync(model);
		}

		public async Task UpdateFacilityType(FacilityType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _facilityTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Status

		public async Task<IEnumerable<Status>> GetStatuses(bool returnInactive)
		{
			return await _statusRepository.GetEntities(returnInactive);
		}

		public async Task CreateStatus(Status model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _statusRepository.CreateAsync(model);
		}

		public async Task UpdateStatus(Status model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _statusRepository.UpdateAsync(model);
		}

		#endregion

		#region Activity List

		public async Task<IEnumerable<ActivityList>> GetActivityList(bool returnInactive)
		{
			return await _activityListRepository.GetEntities(returnInactive);
		}

		public async Task<IEnumerable<ActivityList>> SearchActivityByName(string name)
		{
			return await _activityListRepository.SearchByName(name);
		}

		public async Task<ActivityList> CreateActivityList(ActivityList model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var activity = await _activityListRepository.GetByName(model.Name);

			if (activity == null)
			{
				model.CreatedUserId = loggedInUser.Id;
				model.CreatedDateTime = DateTime.Now;

				await _activityListRepository.CreateEntity(model);
				activity = model;
			}
			else
			{
				activity.Name = model.Name;
				activity.Description = model.Description;
				activity.IsActive = model.IsActive;
				activity.UpdatedUserId = loggedInUser.Id;
				activity.UpdatedDateTime = DateTime.Now;

				await _activityListRepository.UpdateEntity(activity);
			}

			return activity;
		}

		#endregion

		#region Resource List

		public async Task<IEnumerable<ResourceList>> GetResourceList(bool returnInactive)
		{
			return await _resourceListRepository.GetEntities(returnInactive);
		}

		public async Task<ResourceList> CreateResourceList(ResourceList model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var resource = await _resourceListRepository.GetByName(model.Name);

			if (resource == null)
			{
				model.CreatedUserId = loggedInUser.Id;
				model.CreatedDateTime = DateTime.Now;

				await _resourceListRepository.CreateEntity(model);
				resource = model;
			}
			else
			{
				resource.Name = model.Name;
				resource.Description = model.Description;
				resource.IsActive = model.IsActive;
				resource.UpdatedUserId = loggedInUser.Id;
				resource.UpdatedDateTime = DateTime.Now;

				await _resourceListRepository.UpdateEntity(resource);
			}

			return resource;
		}

		#endregion

		#region Provision Type

		public async Task<IEnumerable<ProvisionType>> GetProvisionTypes(bool returnInactive)
		{
			return await _provisionTypeRepository.GetEntities(returnInactive);
		}

		public async Task CreateProvisionType(ProvisionType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _provisionTypeRepository.CreateAsync(model);
		}

		public async Task UpdateProvisionType(ProvisionType model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _provisionTypeRepository.UpdateAsync(model);
		}

		#endregion

		#region Utility Management

		public async Task<IEnumerable<Utility>> GetUtilities(bool returnInactive)
		{
			return await _utilityRepository.GetEntities(returnInactive);
		}

		public async Task CreateUtility(Utility model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _utilityRepository.CreateAsync(model);
		}

		public async Task UpdateUtility(Utility model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _utilityRepository.UpdateAsync(model);
		}

		#endregion

		#region Training Material

		public async Task<IEnumerable<TrainingMaterial>> GetAllTrainingMaterials(bool returnInactive)
		{
			return await _trainingMaterialRepository.GetEntities(returnInactive);
		}

		#endregion

		#endregion
	}
}
