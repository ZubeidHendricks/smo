using AutoMapper;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Lookup;
using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Lookup;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IProgrammeRepository = NPOMS.Repository.Interfaces.Dropdown.IProgrammeRepository;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Domain.Mapping;

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
        private IFrequencyRepository _frequencyRepository;
        private IFrequencyPeriodRepository _frequencyPeriodRepository;
        private ISubProgrammeTypeRepository _subProgrammeTypeRepository;
        private IDirectorateRepository _directorateRepository;
        private IBankRepository _bankRepository;
        private IBranchRepository _branchRepository;
        private IAccountTypeRepository _accountTypeRepository;
        private ICompliantCycleRuleRepository _compliantCycleRuleRepository;
        private IDistrictCouncilRepository _districtCouncilRepository;
        private ILocalMunicipalityRepository _localMunicipalityRepository;
        private IRegionRepository _regionRepository;
        private IServiceDeliveryAreaRepository _serviceDeliveryAreaRepository;
        private IPropertyTypeRepository _propertyTypeRepository;
        private IPropertySubTypeRepository _propertySubTypeRepository;
        private IPlaceRepository _placeRepository;
        private ISubPlaceRepository _subPlaceRepository;
        private IRaceRepository _raceRepository;
        private IGenderRepository _genderRepository;
        private ILanguageRepository _languageRepository;
        private IRegistrationStatusRepository _registrationStatusRepository;
        private IStaffCategoryRepository _staffCategoryRepository;
        private IQuestionRepository _questionRepository;
        private IQuestionSectionRepository _questionSectionRepository;
        private IQuestionCategoryRepository _questionCategoryRepository;
        private IResponseOptionRepository _responseOptionRepository;
        private IResponseTypeRepository _responseTypeRepository;
        private IWorkflowAssessmentRepository _workflowAssessmentRepository;
        private IFundingTemplateTypeRepository _fundingTemplateTypeRepository;
        private IQuarterlyPeriodRepository _quarterlyPeriodRepository;
        private IDepartmentRoleRepository _departmentRoleRepository;
        private ISegmentCodeRepository _segmentCodeRepository;
        #endregion

        #region Constructors

        public DropdownService(
            IMapper mapper,
            IDepartmentRoleRepository departmentRoleRepository,
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
            ITrainingMaterialRepository trainingMaterialRepository,
            IFrequencyRepository frequencyRepository,
            IFrequencyPeriodRepository frequencyPeriodRepository,
            ISubProgrammeTypeRepository subProgrammeTypeRepository,
            IDirectorateRepository directorateRepository,
            IBankRepository bankRepository,
            IBranchRepository branchRepository,
            IAccountTypeRepository accountTypeRepository,
            ICompliantCycleRuleRepository compliantCycleRuleRepository,
            IDistrictCouncilRepository districtCouncilRepository,
            ILocalMunicipalityRepository localMunicipalityRepository,
            IRegionRepository regionRepository,
            IServiceDeliveryAreaRepository serviceDeliveryAreaRepository,
            IPropertyTypeRepository propertyTypeRepository,
            IPropertySubTypeRepository propertySubTypeRepository,
            IPlaceRepository placeRepository,
            ISubPlaceRepository subPlaceRepository,
            IRaceRepository raceRepository,
            IGenderRepository genderRepository,
            ILanguageRepository languageRepository,
            IRegistrationStatusRepository registrationStatusRepository,
            IStaffCategoryRepository staffCategoryRepository,
            IQuestionRepository questionRepository,
            IQuestionSectionRepository questionSectionRepository,
            IQuestionCategoryRepository questionCategoryRepository,
            IResponseOptionRepository responseOptionRepository,
            IResponseTypeRepository responseTypeRepository,
            IWorkflowAssessmentRepository workflowAssessmentRepository,
            IFundingTemplateTypeRepository fundingTemplateTypeRepository,
            IQuarterlyPeriodRepository quarterlyPeriodRepository,
            ISegmentCodeRepository segmentCodeRepository)
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
            _frequencyRepository = frequencyRepository;
            _frequencyPeriodRepository = frequencyPeriodRepository;
            _subProgrammeTypeRepository = subProgrammeTypeRepository;
            _directorateRepository = directorateRepository;
            _bankRepository = bankRepository;
            _branchRepository = branchRepository;
            _accountTypeRepository = accountTypeRepository;
            _compliantCycleRuleRepository = compliantCycleRuleRepository;
            _districtCouncilRepository = districtCouncilRepository;
            _localMunicipalityRepository = localMunicipalityRepository;
            _regionRepository = regionRepository;
            _serviceDeliveryAreaRepository = serviceDeliveryAreaRepository;
            _propertyTypeRepository = propertyTypeRepository;
            _propertySubTypeRepository = propertySubTypeRepository;
            _placeRepository = placeRepository;
            _subPlaceRepository = subPlaceRepository;
            _raceRepository = raceRepository;
            _genderRepository = genderRepository;
            _languageRepository = languageRepository;
            _registrationStatusRepository = registrationStatusRepository;
            _staffCategoryRepository = staffCategoryRepository;
            _questionRepository = questionRepository;
            _questionSectionRepository = questionSectionRepository;
            _questionCategoryRepository = questionCategoryRepository;
            _responseOptionRepository = responseOptionRepository;
            _responseTypeRepository = responseTypeRepository;
            _workflowAssessmentRepository = workflowAssessmentRepository;
            _fundingTemplateTypeRepository = fundingTemplateTypeRepository;
            _quarterlyPeriodRepository = quarterlyPeriodRepository;
            _departmentRoleRepository = departmentRoleRepository;
            _segmentCodeRepository = segmentCodeRepository;
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

            await _roleRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _departmentRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _organisationTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _titleRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _positionRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Race

        public async Task<IEnumerable<Race>> GetRaces(bool returnInactive)
        {
            return await _raceRepository.GetEntities(returnInactive);
        }

        public async Task CreateRace(Race model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _raceRepository.CreateAsync(model);
        }

        public async Task UpdateRace(Race model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _raceRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Gender

        public async Task<IEnumerable<Gender>> GetGenders(bool returnInactive)
        {
            return await _genderRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<Language>> GetLanguages(bool returnInactive)
        {
            return await _languageRepository.GetEntities(returnInactive);
        }

        public async Task CreateGender(Gender model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _genderRepository.CreateAsync(model);
        }

        public async Task UpdateGender(Gender model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _genderRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _accessStatusRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _programmeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            var programme = await _programmeRepository.GetById(model.ProgrammeId);

            // If Department is DOH, create sub-programme type with same details as sub-programme
            if (programme.DepartmentId == (int)DepartmentEnum.DOH)
            {
                await _subProgrammeTypeRepository.CreateAsync(new SubProgrammeType
                {
                    Name = model.Name,
                    Description = model.Description,
                    SubProgrammeId = model.Id,
                    IsActive = true,
                    CreatedUserId = model.CreatedUserId,
                    CreatedDateTime = model.CreatedDateTime
                });
            }
        }

        public async Task UpdateSubProgramme(SubProgramme model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _subProgrammeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        public async Task<IEnumerable<SubProgramme>> GetSubProgrammesByProgrammeId(int programmeId)
        {
            return await _subProgrammeRepository.GetByProgrammeId(programmeId);
        }

        #endregion

        #region Financial Year

        public async Task<IEnumerable<FinancialYear>> GetFinancialYears(bool returnInactive)
        {
            return await _financialYearRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<QuarterlyPeriod>> GetQuarterlyPeriod(bool returnInactive)
        {
            return await _quarterlyPeriodRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<SegmentCode>> GetSegmentCode(bool returnInactive)
        {
            return await _segmentCodeRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<FinancialYear>> GetFromCurrentFinancialYear()
        {
            return await _financialYearRepository.GetFromCurrentFinancialYear();
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

            await _financialYearRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _applicationTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _recipientTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _activityTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _resourceTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _serviceTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _allocationTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _facilityDistrictRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _facilitySubDistrictRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region FA-FinancialDetails- PropertyTypes

        public async Task<IEnumerable<PropertyType>> GetPropertyTypes(bool returnInactive)
        {
            return await _propertyTypeRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<PropertySubType>> GetPropertySubTypes(bool returnInactive)
        {
            return await _propertySubTypeRepository.GetEntities(returnInactive);
        }
        #endregion

        #region FA-DistrictCouncil-Municipalaities-Region-ServiceDeliveryAreas-Place-SubPlace
        public async Task<IEnumerable<DistrictCouncil>> GetDistrictCouncils(bool returnInactive)
        {
            return await _districtCouncilRepository.GetEntities(returnInactive);
        }


        public async Task<IEnumerable<LocalMunicipality>> GetLocalMunicipalities(bool returnInactive)
        {
            return await _localMunicipalityRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<Region>> GetRegions(bool returnInactive)
        {
            return await _regionRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<ServiceDeliveryArea>> GetServiceDeliveryAreas(bool returnInactive)
        {
            return await _serviceDeliveryAreaRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<Place>> GetPlaces(bool returnInactive)
        {
            return await _placeRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<SubPlace>> GetSubPlaces(bool returnInactive)
        {
            return await _subPlaceRepository.GetEntities(returnInactive);
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

            await _facilityClassRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Facility List

        public async Task<IEnumerable<FacilityList>> GetFacilityList(bool returnInactive)
        {
            return await _facilityListRepository.GetEntities(returnInactive);
        }

        public async Task<FacilityList> GetFacilityListByModel(FacilityList model)
        {
            return await _facilityListRepository.GetByProperties(model);
        }

        public async Task<IEnumerable<FacilityList>> SearchFacilityByName(string name)
        {
            return await _facilityListRepository.SearchByName(name);
        }

        public async Task CreateFacility(FacilityList model, string userIdentifier)
        {
            model.FacilityType = null;
            model.FacilitySubDistrict = null;
            model.FacilityClass = null;

            var facility = await _facilityListRepository.GetByProperties(model);

            if (facility == null)
            {
                var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

                model.CreatedUserId = loggedInUser.Id;
                model.CreatedDateTime = DateTime.Now;

                await _facilityListRepository.CreateEntity(model);
            }
        }

        public async Task UpdateFacility(FacilityList model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _facilityListRepository.UpdateEntity(model, loggedInUser.Id);
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

            await _documentTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _facilityTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _statusRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

                await _activityListRepository.UpdateEntity(activity, loggedInUser.Id);
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

                await _resourceListRepository.UpdateEntity(resource, loggedInUser.Id);
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

            await _provisionTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
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

            await _utilityRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Training Material

        public async Task<IEnumerable<TrainingMaterial>> GetAllTrainingMaterials(bool returnInactive)
        {
            return await _trainingMaterialRepository.GetEntities(returnInactive);
        }

        #endregion

        #region Frequency

        public async Task<IEnumerable<Frequency>> GetFrequencies(bool returnInactive)
        {
            return await _frequencyRepository.GetEntities(returnInactive);
        }

        public async Task CreateFrequency(Frequency model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _frequencyRepository.CreateAsync(model);
        }

        public async Task UpdateFrequency(Frequency model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _frequencyRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Frequency Period

        public async Task<IEnumerable<FrequencyPeriod>> GetFrequencyPeriods(bool returnInactive)
        {
            return await _frequencyPeriodRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<FrequencyPeriod>> GetFrequencyPeriodsByFrequencyId(int frequencyId)
        {
            return await _frequencyPeriodRepository.GetByFrequencyId(frequencyId);
        }

        public async Task CreateFrequencyPeriod(FrequencyPeriod model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _frequencyPeriodRepository.CreateAsync(model);
        }

        public async Task UpdateFrequencyPeriod(FrequencyPeriod model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _frequencyPeriodRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Sub-Programme Type

        public async Task<IEnumerable<SubProgrammeType>> GetSubProgrammeTypes(bool returnInactive)
        {
            return await _subProgrammeTypeRepository.GetEntities(returnInactive);
        }

        public async Task CreateSubProgrammeType(SubProgrammeType model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _subProgrammeTypeRepository.CreateAsync(model);
        }

        public async Task UpdateSubProgrammeType(SubProgrammeType model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _subProgrammeTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        public async Task<IEnumerable<SubProgrammeType>> GetSubProgrammeTypesBySubProgrammeId(int subProgrammeId)
        {
            return await _subProgrammeTypeRepository.GetBySubProgrammeId(subProgrammeId);
        }

        #endregion

        #region Directorate

        public async Task<IEnumerable<Directorate>> GetDirectorates(bool returnInactive)
        {
            return await _directorateRepository.GetEntities(returnInactive);
        }

        public async Task CreateDirectorate(Directorate model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _directorateRepository.CreateAsync(model);
        }

        public async Task UpdateDirectorate(Directorate model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _directorateRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Bank

        public async Task<IEnumerable<Bank>> GetBanks(bool returnInactive)
        {
            return await _bankRepository.GetEntities(returnInactive);
        }

        public async Task CreateBank(Bank model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _bankRepository.CreateAsync(model);
        }

        public async Task UpdateBank(Bank model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _bankRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Branch

        public async Task<IEnumerable<Branch>> GetBranches(bool returnInactive)
        {
            return await _branchRepository.GetEntities(returnInactive);
        }

        public async Task<IEnumerable<Branch>> GetBranchesByBankId(int bankId)
        {
            return await _branchRepository.GetByBankId(bankId);
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await _branchRepository.GetById(id);
        }

        public async Task CreateBranch(Branch model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _branchRepository.CreateAsync(model);
        }

        public async Task UpdateBranch(Branch model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _branchRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Account Type

        public async Task<IEnumerable<AccountType>> GetAccountTypes(bool returnInactive)
        {
            return await _accountTypeRepository.GetEntities(returnInactive);
        }

        public async Task<AccountType> GetAccountTypeById(int id)
        {
            return await _accountTypeRepository.GetById(id);
        }

        public async Task CreateAccountType(AccountType model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _accountTypeRepository.CreateAsync(model);
        }

        public async Task UpdateAccountType(AccountType model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _accountTypeRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Compliant Cycle Rule

        public async Task<IEnumerable<CompliantCycleRule>> GetCompliantCycleRules(bool returnInactive)
        {
            return await _compliantCycleRuleRepository.GetEntities(returnInactive);
        }

        public async Task<CompliantCycleRule> GetCompliantCycleRuleById(int id)
        {
            return await _compliantCycleRuleRepository.GetById(id);
        }

        public async Task CreateCompliantCycleRule(CompliantCycleRule model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _compliantCycleRuleRepository.CreateAsync(model);
        }

        public async Task UpdateCompliantCycleRule(CompliantCycleRule model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _compliantCycleRuleRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Registration Status

        public async Task<IEnumerable<RegistrationStatus>> GetRegistrationStatuses(bool returnInactive)
        {
            return await _registrationStatusRepository.GetEntities(returnInactive);
        }

        public async Task CreateRegistrationStatus(RegistrationStatus model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _registrationStatusRepository.CreateAsync(model);
        }

        public async Task UpdateRegistrationStatus(RegistrationStatus model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _registrationStatusRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Staff Category

        public async Task<IEnumerable<StaffCategory>> GetStaffCategories(bool returnInactive)
        {
            return await _staffCategoryRepository.GetEntities(returnInactive);
        }

        public async Task CreateStaffCategory(StaffCategory model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _staffCategoryRepository.CreateAsync(model);
        }

        public async Task UpdateStaffCategory(StaffCategory model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _staffCategoryRepository.UpdateAsync(null, model, false, loggedInUser.Id);
        }

        #endregion

        #region Question Category

        public async Task<IEnumerable<QuestionCategory>> GetQuestionCategories(bool returnInactive)
        {
            return await _questionCategoryRepository.GetAllAsync(returnInactive);
        }

        public async Task CreateQuestionCategory(QuestionCategory model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.CreatedUserId = currentUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _questionCategoryRepository.CreateAsync(model);
        }

        public async Task UpdateQuestionCategory(QuestionCategory model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.UpdatedUserId = currentUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _questionCategoryRepository.UpdateAsync(model);
        }

        #endregion

        #region Question Section

        public async Task<IEnumerable<FundingTemplateType>> GetAllFundingTemplateTypes(bool returnInactive)
        {
            return await _fundingTemplateTypeRepository.GetAllAsync(returnInactive);
        }

        public async Task<IEnumerable<QuestionSection>> GetQuestionSections(bool returnInactive)
        {
            return await _questionSectionRepository.GetAllAsync(returnInactive);
        }

        public async Task CreateQuestionSection(QuestionSection model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.CreatedUserId = currentUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _questionSectionRepository.CreateAsync(model);
        }

        public async Task UpdateQuestionSection(QuestionSection model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.UpdatedUserId = currentUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _questionSectionRepository.UpdateAsync(model);
        }

        #endregion

        #region Question

        public async Task<IEnumerable<Question>> GetQuestions(bool returnInactive)
        {
            return await _questionRepository.GetAllAsync(returnInactive);
        }

        public async Task CreateQuestion(Question model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.CreatedUserId = currentUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _questionRepository.CreateAsync(model);
        }

        public async Task UpdateQuestion(Question model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.UpdatedUserId = currentUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _questionRepository.UpdateAsync(model);
        }

        #endregion

        #region Response Type

        public async Task<IEnumerable<ResponseType>> GetResponseTypes(bool returnInactive)
        {
            return await _responseTypeRepository.GetAllAsync(returnInactive);
        }

        public async Task CreateResponseType(ResponseType model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.CreatedUserId = currentUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _responseTypeRepository.CreateAsync(model);
        }

        public async Task UpdateResponseType(ResponseType model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.UpdatedUserId = currentUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _responseTypeRepository.UpdateAsync(model);
        }

        #endregion

        #region Response Option

        public async Task<IEnumerable<ResponseOption>> GetResponseOptions(bool returnInactive)
        {
            return await _responseOptionRepository.GetAllAsync(returnInactive);
        }

        public async Task CreateResponseOption(ResponseOption model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.CreatedUserId = currentUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _responseOptionRepository.CreateAsync(model);
        }

        public async Task UpdateResponseOption(ResponseOption model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.UpdatedUserId = currentUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _responseOptionRepository.UpdateAsync(model);
        }

        #endregion

        #region Workflow Assessment

        public async Task<IEnumerable<WorkflowAssessment>> GetWorkflowAssessments(bool returnInactive)
        {
            return await _workflowAssessmentRepository.GetAllAsync(returnInactive);
        }

        public async Task CreateWorkflowAssessment(WorkflowAssessment model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.CreatedUserId = currentUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _workflowAssessmentRepository.CreateAsync(model);
        }

        public async Task UpdateWorkflowAssessment(WorkflowAssessment model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.UpdatedUserId = currentUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            await _workflowAssessmentRepository.UpdateAsync(model);
        }

        public async Task DeleteWorkflowAssessment(int id, string userIdentifier)
        {
            await _workflowAssessmentRepository.DeleteById(id);
        }

        public async Task DeleteResponseOption(int id, string userIdentifier)
        {
            await _responseOptionRepository.DeleteById(id);
        }
        public async Task DeleteResponseType(int id, string userIdentifier)
        {
            await _responseTypeRepository.DeleteById(id);
        }

        public async Task DeleteQuestion(int id, string userIdentifier)
        {
            await _questionRepository.DeleteById(id);
        }

        public async Task DeleteQuestionCategory(int id, string userIdentifier)
        {
            await _questionCategoryRepository.DeleteById(id);
        }

        public async Task DeleteQuestionSection(int id, string userIdentifier)
        {
            await _questionSectionRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Programme>> GetProgramsByDepartment(int id)
        {
            var department = await _departmentRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
         
            return await _programmeRepository.GetProgramsByDepartment(department.Name,id);
        }

        public async Task<IEnumerable<Role>> GetRolesByDepartment(int id)
        {
            var department = await _departmentRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            List<int> rolesIds = await _departmentRoleRepository.ReturnRoleIds(id);

            return await _roleRepository.GetRolesByDepartment(department.Name, rolesIds);
        }

        public async Task<Programme> GetProgramme(int id)
        {
            return await _programmeRepository.GetById(id);
        }

        public async Task<Department> GetDepartment(int depId)
        {
            return await _departmentRepository.GetDepartmentById(depId);
        }

        #endregion

        #endregion
    }
}
