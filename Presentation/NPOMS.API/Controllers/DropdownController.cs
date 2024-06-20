using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Evaluation;
using NPOMS.Domain.Lookup;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
    [Route("api/dropdown")]
    [ApiController]
    public class DropdownController : ExternalBaseController
    {
        #region Fields

        private ILogger<DropdownController> _logger;
        private IDropdownService _dropdownService;
        private IDocumentStoreService _documentStoreService;
        private IApplicationService _applicationService;

        #endregion

        #region Constructors

        public DropdownController(
            ILogger<DropdownController> logger,
            IDropdownService dropdownService,
            IDocumentStoreService documentStoreService,
            IApplicationService applicationService)
        {
            _logger = logger;
            _dropdownService = dropdownService;
            _documentStoreService = documentStoreService;
            _applicationService = applicationService;
        }

        #endregion

        #region Methods

        [HttpGet("dropdownTypeEnum/{dropdownType}/returnInactive/{returnInactive}", Name = "GetEntities")]
        public async Task<IActionResult> GetEntities(DropdownTypeEnum dropdownType, bool returnInactive)
        {
            try
            {
                switch (dropdownType)
                {
                    case DropdownTypeEnum.Roles:
                        var roles = await _dropdownService.GetRoles(returnInactive);
                        return Ok(roles);
                    case DropdownTypeEnum.Departments:
                        var departments = await _dropdownService.GetDepartments(returnInactive);
                        return Ok(departments);
                    case DropdownTypeEnum.OrganisationTypes:
                        var organisationTypes = await _dropdownService.GetOrganisationTypes(returnInactive);
                        return Ok(organisationTypes);
                    case DropdownTypeEnum.Titles:
                        var titles = await _dropdownService.GetTitles(returnInactive);
                        return Ok(titles);
                    case DropdownTypeEnum.Positions:
                        var positions = await _dropdownService.GetPositions(returnInactive);
                        return Ok(positions);
                    case DropdownTypeEnum.AccessStatuses:
                        var accessStatuses = await _dropdownService.GetAccessStatuses(returnInactive);
                        return Ok(accessStatuses);
                    case DropdownTypeEnum.Programmes:
                        var programmes = await _dropdownService.GetProgrammes(returnInactive);
                        return Ok(programmes);
                    case DropdownTypeEnum.SubProgramme:
                        var subProgrammes = await _dropdownService.GetSubProgrammes(returnInactive);
                        return Ok(subProgrammes);
                    case DropdownTypeEnum.FinancialYears:
                        var financialYears = await _dropdownService.GetFinancialYears(returnInactive);
                        return Ok(financialYears);
                    case DropdownTypeEnum.ApplicationTypes:
                        var applicationTypes = await _dropdownService.GetApplicationTypes(returnInactive);
                        return Ok(applicationTypes);
                    case DropdownTypeEnum.RecipientTypes:
                        var recipientTypes = await _dropdownService.GetRecipientTypes(returnInactive);
                        return Ok(recipientTypes);
                    case DropdownTypeEnum.ActivityTypes:
                        var activityTypes = await _dropdownService.GetActivityTypes(returnInactive);
                        return Ok(activityTypes);
                    case DropdownTypeEnum.ResourceTypes:
                        var resourceTypes = await _dropdownService.GetResourceTypes(returnInactive);
                        return Ok(resourceTypes);
                    case DropdownTypeEnum.ServiceTypes:
                        var serviceTypes = await _dropdownService.GetServiceTypes(returnInactive);
                        return Ok(serviceTypes);
                    case DropdownTypeEnum.AllocationTypes:
                        var allocationTypes = await _dropdownService.GetAllocationTypes(returnInactive);
                        return Ok(allocationTypes);
                    case DropdownTypeEnum.FacilityDistricts:
                        var facilityDistricts = await _dropdownService.GetFacilityDistricts(returnInactive);
                        return Ok(facilityDistricts);
                    case DropdownTypeEnum.FacilitySubDistricts:
                        var facilitySubDistricts = await _dropdownService.GetFacilitySubDistricts(returnInactive);
                        return Ok(facilitySubDistricts);
                    case DropdownTypeEnum.FacilityClasses:
                        var facilityClasses = await _dropdownService.GetFacilityClasses(returnInactive);
                        return Ok(facilityClasses);
                    case DropdownTypeEnum.FacilityList:
                        var facilityList = await _dropdownService.GetFacilityList(returnInactive);
                        return Ok(facilityList);
                    case DropdownTypeEnum.DocumentTypes:
                        var documentTypes = await _dropdownService.GetDocumentTypes(returnInactive);
                        var documents = await _documentStoreService.GetAllDocuments();
                        foreach (var type in documentTypes)
                        {
                            foreach (var doc in documents)
                            {
                                if (doc.DocumentTypeId != null)
                                {
                                    if (doc.DocumentTypeId == type.Id)
                                    {
                                        type.DocumentName = doc.Name;
                                    }
                                }
                            }
                        }
                        return Ok(documentTypes);
                    case DropdownTypeEnum.FacilityTypes:
                        var facilityTypes = await _dropdownService.GetFacilityTypes(returnInactive);
                        return Ok(facilityTypes);
                    case DropdownTypeEnum.Statuses:
                        var statuses = await _dropdownService.GetStatuses(returnInactive);
                        return Ok(statuses);
                    case DropdownTypeEnum.ActivityList:
                        var activityList = await _dropdownService.GetActivityList(returnInactive);
                        return Ok(activityList);
                    case DropdownTypeEnum.ResourceList:
                        var resourceList = await _dropdownService.GetResourceList(returnInactive);
                        return Ok(resourceList);
                    case DropdownTypeEnum.ProvisionTypes:
                        var provisionTypes = await _dropdownService.GetProvisionTypes(returnInactive);
                        return Ok(provisionTypes);
                    case DropdownTypeEnum.Utilities:
                        var utilities = await _dropdownService.GetUtilities(returnInactive);
                        return Ok(utilities);
                    case DropdownTypeEnum.TrainingMaterial:
                        var trainingMaterials = await _dropdownService.GetAllTrainingMaterials(returnInactive);
                        return Ok(trainingMaterials);
                    case DropdownTypeEnum.Frequencies:
                        var frequencies = await _dropdownService.GetFrequencies(returnInactive);
                        return Ok(frequencies);
                    case DropdownTypeEnum.FrequencyPeriods:
                        var frequencyPeriods = await _dropdownService.GetFrequencyPeriods(returnInactive);
                        return Ok(frequencyPeriods);
                    case DropdownTypeEnum.SubProgrammeTypes:
                        var subProgrammeTypes = await _dropdownService.GetSubProgrammeTypes(returnInactive);
                        return Ok(subProgrammeTypes);
                    case DropdownTypeEnum.Directorates:
                        var directorates = await _dropdownService.GetDirectorates(returnInactive);
                        return Ok(directorates);
                    case DropdownTypeEnum.Banks:
                        var banks = await _dropdownService.GetBanks(returnInactive);
                        return Ok(banks);
                    case DropdownTypeEnum.Branches:
                        var branches = await _dropdownService.GetBranches(returnInactive);
                        return Ok(branches);
                    case DropdownTypeEnum.AccountTypes:
                        var accountTypes = await _dropdownService.GetAccountTypes(returnInactive);
                        return Ok(accountTypes);
                    case DropdownTypeEnum.CompliantCycleRules:
                        var compliantCycleRules = await _dropdownService.GetCompliantCycleRules(returnInactive);
                        return Ok(compliantCycleRules);
                    case DropdownTypeEnum.DistrictCouncil:
                        var districtCouncils = await _dropdownService.GetDistrictCouncils(returnInactive);
                        return Ok(districtCouncils);
                    case DropdownTypeEnum.LocalMunicipality:
                        var localMunicipalities = await _dropdownService.GetLocalMunicipalities(returnInactive);
                        return Ok(localMunicipalities);
                    case DropdownTypeEnum.Region:
                        var regions = await _dropdownService.GetRegions(returnInactive);
                        return Ok(regions);
                    case DropdownTypeEnum.ServiceDeliveryArea:
                        var serviceDeliveryAreas = await _dropdownService.GetServiceDeliveryAreas(returnInactive);
                        return Ok(serviceDeliveryAreas);
                    case DropdownTypeEnum.PropertyType:
                        var propertyType = await _dropdownService.GetPropertyTypes(returnInactive);
                        return Ok(propertyType);
                    case DropdownTypeEnum.PropertySubType:
                        var propertySubType = await _dropdownService.GetPropertySubTypes(returnInactive);
                        return Ok(propertySubType);
                    case DropdownTypeEnum.Place:
                        var place = await _dropdownService.GetPlaces(returnInactive);
                        return Ok(place);
                    case DropdownTypeEnum.SubPlace:
                        var subPlace = await _dropdownService.GetSubPlaces(returnInactive);
                        return Ok(subPlace);
                    case DropdownTypeEnum.Race:
                        var races = await _dropdownService.GetRaces(returnInactive);
                        return Ok(races);
                    case DropdownTypeEnum.Gender:
                        var gender = await _dropdownService.GetGenders(returnInactive);
                        return Ok(gender);
                    case DropdownTypeEnum.Languages:
                        var language = await _dropdownService.GetLanguages(returnInactive);
                        return Ok(language);
                    case DropdownTypeEnum.RegistrationStatus:
                        var registrationStatuses = await _dropdownService.GetRegistrationStatuses(returnInactive);
                        return Ok(registrationStatuses);
                    case DropdownTypeEnum.StaffCategory:
                        var staffCategories = await _dropdownService.GetStaffCategories(returnInactive);
                        return Ok(staffCategories);
                    case DropdownTypeEnum.FundingTemplateType:
                        var fundingTemplateTypes = await _dropdownService.GetAllFundingTemplateTypes(returnInactive);
                        return Ok(fundingTemplateTypes);
                    case DropdownTypeEnum.QuestionCategory:
                        var categories = await _dropdownService.GetQuestionCategories(returnInactive);
                        return Ok(categories);
                    case DropdownTypeEnum.QuestionSection:
                        var sections = await _dropdownService.GetQuestionSections(returnInactive);
                        return Ok(sections);
                    case DropdownTypeEnum.Question:
                        var questions = await _dropdownService.GetQuestions(returnInactive);
                        return Ok(questions);
                    case DropdownTypeEnum.ResponseType:
                        var responseTypes = await _dropdownService.GetResponseTypes(returnInactive);
                        return Ok(responseTypes);
                    case DropdownTypeEnum.ResponseOption:
                        var responseOptions = await _dropdownService.GetResponseOptions(returnInactive);
                        return Ok(responseOptions);
                    case DropdownTypeEnum.WorkflowAssessment:
                        var assessments = await _dropdownService.GetWorkflowAssessments(returnInactive);
                        return Ok(assessments);
                    case DropdownTypeEnum.QuarterlyPeriod:
                        var quarterlyPeriod = await _dropdownService.GetQuarterlyPeriod(returnInactive);
                        return Ok(quarterlyPeriod);
                    case DropdownTypeEnum.SegmentCode:
                        var segmentCode = await _dropdownService.GetSegmentCode(returnInactive);
                        return Ok(segmentCode);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEntities-{dropdownType} action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("dropdownTypeEnum/{dropdownType}/id/{id}/programmes", Name = "GetProgramsByDepartment")]
        public async Task<IActionResult> GetProgramsByDepartment(DropdownTypeEnum dropdownType, int id )
        {
            try
            {
                switch (dropdownType)
                {
                    case DropdownTypeEnum.FilteredProgrammesByDepartment:

                        var filteredProgrammes = await _dropdownService.GetProgramsByDepartment(id);
               
                        return Ok(filteredProgrammes);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProgramsByDepartment-{dropdownType} action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("dropdownTypeEnum/{dropdownType}/id/{id}/roles", Name = "GetRolesByDepartment")]
        public async Task<IActionResult> GetRolesByDepartment(DropdownTypeEnum dropdownType, int id)
        {
            try
            {
                switch (dropdownType)
                {
                    case DropdownTypeEnum.FilteredRolesByDepartment:

                        var filteredRoles = await _dropdownService.GetRolesByDepartment(id);

                        return Ok(filteredRoles);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProgramsByDepartment-{dropdownType} action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("dropdownTypeEnum/{dropdownType}/id/{id}/returnInactive/{returnInactive}", Name = "GetEntitiesForDoc")]
        public async Task<IActionResult> GetEntitiesForDoc(DropdownTypeEnum dropdownType, int id, bool returnInactive)
        {
            try
            {
                switch (dropdownType)
                {
                    case DropdownTypeEnum.DocumentTypes:
                        var refNo = await _applicationService.GetApplicationById(id);
                        var documentTypes = await _dropdownService.GetDocumentTypes(returnInactive);
                        //var documents = await _documentStoreService.GetAllDocuments();
                        if (refNo != null)
                        {
                            var docByRefNo = await _documentStoreService.GetDocumnetByRefNo(refNo.RefNo);
                            foreach (var type in documentTypes)
                            {
                                foreach (var doc in docByRefNo)
                                {
                                    if (doc.DocumentTypeId != null)
                                    {
                                        if (doc.DocumentTypeId == type.Id)
                                        {
                                            type.DocumentName = doc.Name;
                                        }
                                    }
                                }
                            }
                        }
                        return Ok(documentTypes);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEntities-{dropdownType} action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("dropdownTypeEnum/{dropdownType}", Name = "CreateEntity")]
        public async Task<IActionResult> CreateEntity(object entity, DropdownTypeEnum dropdownType)
        {
            try
            {
                switch (dropdownType)
                {
                    case DropdownTypeEnum.Roles:
                        var role = JsonConvert.DeserializeObject<Role>(Convert.ToString(entity));
                        await _dropdownService.CreateRole(role, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Departments:
                        var department = JsonConvert.DeserializeObject<Department>(Convert.ToString(entity));
                        await _dropdownService.CreateDepartment(department, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.OrganisationTypes:
                        var organisationType = JsonConvert.DeserializeObject<OrganisationType>(Convert.ToString(entity));
                        await _dropdownService.CreateOrganisationType(organisationType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Titles:
                        var title = JsonConvert.DeserializeObject<Title>(Convert.ToString(entity));
                        await _dropdownService.CreateTitle(title, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Positions:
                        var position = JsonConvert.DeserializeObject<Position>(Convert.ToString(entity));
                        await _dropdownService.CreatePosition(position, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.AccessStatuses:
                        var accessStatus = JsonConvert.DeserializeObject<AccessStatus>(Convert.ToString(entity));
                        await _dropdownService.CreateAccessStatus(accessStatus, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Programmes:
                        var programme = JsonConvert.DeserializeObject<Programme>(Convert.ToString(entity));
                        await _dropdownService.CreateProgramme(programme, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.SubProgramme:
                        var subProgramme = JsonConvert.DeserializeObject<SubProgramme>(Convert.ToString(entity));
                        await _dropdownService.CreateSubProgramme(subProgramme, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FinancialYears:
                        var financialYear = JsonConvert.DeserializeObject<FinancialYear>(Convert.ToString(entity));
                        await _dropdownService.CreateFinancialYear(financialYear, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ApplicationTypes:
                        var applicationType = JsonConvert.DeserializeObject<ApplicationType>(Convert.ToString(entity));
                        await _dropdownService.CreateApplicationType(applicationType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.RecipientTypes:
                        var recipientType = JsonConvert.DeserializeObject<RecipientType>(Convert.ToString(entity));
                        await _dropdownService.CreateRecipientType(recipientType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ActivityTypes:
                        var activityType = JsonConvert.DeserializeObject<ActivityType>(Convert.ToString(entity));
                        await _dropdownService.CreateActivityType(activityType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResourceTypes:
                        var resourceType = JsonConvert.DeserializeObject<ResourceType>(Convert.ToString(entity));
                        await _dropdownService.CreateResourceType(resourceType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ServiceTypes:
                        var serviceType = JsonConvert.DeserializeObject<ServiceType>(Convert.ToString(entity));
                        await _dropdownService.CreateServiceType(serviceType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.AllocationTypes:
                        var allocationType = JsonConvert.DeserializeObject<AllocationType>(Convert.ToString(entity));
                        await _dropdownService.CreateAllocationType(allocationType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilityDistricts:
                        var facilityDistrict = JsonConvert.DeserializeObject<FacilityDistrict>(Convert.ToString(entity));
                        await _dropdownService.CreateFacilityDistrict(facilityDistrict, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilitySubDistricts:
                        var facilitySubDistrict = JsonConvert.DeserializeObject<FacilitySubDistrict>(Convert.ToString(entity));
                        await _dropdownService.CreateFacilitySubDistrict(facilitySubDistrict, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilityClasses:
                        var facilityClass = JsonConvert.DeserializeObject<FacilityClass>(Convert.ToString(entity));
                        await _dropdownService.CreateFacilityClass(facilityClass, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.DocumentTypes:
                        var documentType = JsonConvert.DeserializeObject<DocumentType>(Convert.ToString(entity));
                        await _dropdownService.CreateDocumentType(documentType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilityTypes:
                        var facilityType = JsonConvert.DeserializeObject<FacilityType>(Convert.ToString(entity));
                        await _dropdownService.CreateFacilityType(facilityType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Statuses:
                        var status = JsonConvert.DeserializeObject<Status>(Convert.ToString(entity));
                        await _dropdownService.CreateStatus(status, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ProvisionTypes:
                        var provisionType = JsonConvert.DeserializeObject<ProvisionType>(Convert.ToString(entity));
                        await _dropdownService.CreateProvisionType(provisionType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Utilities:
                        var utility = JsonConvert.DeserializeObject<Utility>(Convert.ToString(entity));
                        await _dropdownService.CreateUtility(utility, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Frequencies:
                        var frequency = JsonConvert.DeserializeObject<Frequency>(Convert.ToString(entity));
                        await _dropdownService.CreateFrequency(frequency, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FrequencyPeriods:
                        var frequencyPeriod = JsonConvert.DeserializeObject<FrequencyPeriod>(Convert.ToString(entity));
                        await _dropdownService.CreateFrequencyPeriod(frequencyPeriod, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.SubProgrammeTypes:
                        var subProgrammeType = JsonConvert.DeserializeObject<SubProgrammeType>(Convert.ToString(entity));
                        await _dropdownService.CreateSubProgrammeType(subProgrammeType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Directorates:
                        var directorate = JsonConvert.DeserializeObject<Directorate>(Convert.ToString(entity));
                        await _dropdownService.CreateDirectorate(directorate, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Banks:
                        var bank = JsonConvert.DeserializeObject<Bank>(Convert.ToString(entity));
                        await _dropdownService.CreateBank(bank, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Branches:
                        var branch = JsonConvert.DeserializeObject<Branch>(Convert.ToString(entity));
                        await _dropdownService.CreateBranch(branch, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.AccountTypes:
                        var accountType = JsonConvert.DeserializeObject<AccountType>(Convert.ToString(entity));
                        await _dropdownService.CreateAccountType(accountType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.CompliantCycleRules:
                        var rule = JsonConvert.DeserializeObject<CompliantCycleRule>(Convert.ToString(entity));
                        await _dropdownService.CreateCompliantCycleRule(rule, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Race:
                        var race = JsonConvert.DeserializeObject<Race>(Convert.ToString(entity));
                        await _dropdownService.CreateRace(race, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Gender:
                        var gender = JsonConvert.DeserializeObject<Gender>(Convert.ToString(entity));
                        await _dropdownService.CreateGender(gender, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.RegistrationStatus:
                        var registrationStatus = JsonConvert.DeserializeObject<RegistrationStatus>(Convert.ToString(entity));
                        await _dropdownService.CreateRegistrationStatus(registrationStatus, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.StaffCategory:
                        var staffCategory = JsonConvert.DeserializeObject<StaffCategory>(Convert.ToString(entity));
                        await _dropdownService.CreateStaffCategory(staffCategory, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.QuestionCategory:
                        var category = JsonConvert.DeserializeObject<QuestionCategory>(Convert.ToString(entity));
                        await _dropdownService.CreateQuestionCategory(category, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.QuestionSection:
                        var section = JsonConvert.DeserializeObject<QuestionSection>(Convert.ToString(entity));
                        await _dropdownService.CreateQuestionSection(section, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Question:
                        var question = JsonConvert.DeserializeObject<Question>(Convert.ToString(entity));
                        await _dropdownService.CreateQuestion(question, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResponseType:
                        var responseType = JsonConvert.DeserializeObject<ResponseType>(Convert.ToString(entity));
                        await _dropdownService.CreateResponseType(responseType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResponseOption:
                        var responseOption = JsonConvert.DeserializeObject<ResponseOption>(Convert.ToString(entity));
                        await _dropdownService.CreateResponseOption(responseOption, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.WorkflowAssessment:
                        var assessment = JsonConvert.DeserializeObject<WorkflowAssessment>(Convert.ToString(entity));
                        await _dropdownService.CreateWorkflowAssessment(assessment, base.GetUserIdentifier());
                        break;
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEntity action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("dropdownTypeEnum/{dropdownType}", Name = "UpdateEntity")]
        public async Task<IActionResult> UpdateEntity(object entity, DropdownTypeEnum dropdownType)
        {
            try
            {
                switch (dropdownType)
                {
                    case DropdownTypeEnum.Roles:
                        var role = JsonConvert.DeserializeObject<Role>(Convert.ToString(entity));
                        await _dropdownService.UpdateRole(role, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Departments:
                        var department = JsonConvert.DeserializeObject<Department>(Convert.ToString(entity));
                        await _dropdownService.UpdateDepartment(department, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.OrganisationTypes:
                        var organisationType = JsonConvert.DeserializeObject<OrganisationType>(Convert.ToString(entity));
                        await _dropdownService.UpdateOrganisationType(organisationType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Titles:
                        var title = JsonConvert.DeserializeObject<Title>(Convert.ToString(entity));
                        await _dropdownService.UpdateTitle(title, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Positions:
                        var position = JsonConvert.DeserializeObject<Position>(Convert.ToString(entity));
                        await _dropdownService.UpdatePosition(position, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.AccessStatuses:
                        var accessStatus = JsonConvert.DeserializeObject<AccessStatus>(Convert.ToString(entity));
                        await _dropdownService.UpdateAccessStatus(accessStatus, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Programmes:
                        var programme = JsonConvert.DeserializeObject<Programme>(Convert.ToString(entity));
                        await _dropdownService.UpdateProgramme(programme, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.SubProgramme:
                        var subProgramme = JsonConvert.DeserializeObject<SubProgramme>(Convert.ToString(entity));
                        await _dropdownService.UpdateSubProgramme(subProgramme, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FinancialYears:
                        var financialYear = JsonConvert.DeserializeObject<FinancialYear>(Convert.ToString(entity));
                        await _dropdownService.UpdateFinancialYear(financialYear, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ApplicationTypes:
                        var applicationType = JsonConvert.DeserializeObject<ApplicationType>(Convert.ToString(entity));
                        await _dropdownService.UpdateApplicationType(applicationType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.RecipientTypes:
                        var recipientType = JsonConvert.DeserializeObject<RecipientType>(Convert.ToString(entity));
                        await _dropdownService.UpdateRecipientType(recipientType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ActivityTypes:
                        var activityType = JsonConvert.DeserializeObject<ActivityType>(Convert.ToString(entity));
                        await _dropdownService.UpdateActivityType(activityType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResourceTypes:
                        var resourceType = JsonConvert.DeserializeObject<ResourceType>(Convert.ToString(entity));
                        await _dropdownService.UpdateResourceType(resourceType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ServiceTypes:
                        var serviceType = JsonConvert.DeserializeObject<ServiceType>(Convert.ToString(entity));
                        await _dropdownService.UpdateServiceType(serviceType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.AllocationTypes:
                        var allocationType = JsonConvert.DeserializeObject<AllocationType>(Convert.ToString(entity));
                        await _dropdownService.UpdateAllocationType(allocationType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilityDistricts:
                        var facilityDistrict = JsonConvert.DeserializeObject<FacilityDistrict>(Convert.ToString(entity));
                        await _dropdownService.UpdateFacilityDistrict(facilityDistrict, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilitySubDistricts:
                        var facilitySubDistrict = JsonConvert.DeserializeObject<FacilitySubDistrict>(Convert.ToString(entity));
                        await _dropdownService.UpdateFacilitySubDistrict(facilitySubDistrict, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilityClasses:
                        var facilityClass = JsonConvert.DeserializeObject<FacilityClass>(Convert.ToString(entity));
                        await _dropdownService.UpdateFacilityClass(facilityClass, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.DocumentTypes:
                        var documentType = JsonConvert.DeserializeObject<DocumentType>(Convert.ToString(entity));
                        await _dropdownService.UpdateDocumentType(documentType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FacilityTypes:
                        var facilityType = JsonConvert.DeserializeObject<FacilityType>(Convert.ToString(entity));
                        await _dropdownService.UpdateFacilityType(facilityType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Statuses:
                        var status = JsonConvert.DeserializeObject<Status>(Convert.ToString(entity));
                        await _dropdownService.UpdateStatus(status, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ProvisionTypes:
                        var provisionType = JsonConvert.DeserializeObject<ProvisionType>(Convert.ToString(entity));
                        await _dropdownService.UpdateProvisionType(provisionType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Utilities:
                        var utility = JsonConvert.DeserializeObject<Utility>(Convert.ToString(entity));
                        await _dropdownService.UpdateUtility(utility, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Frequencies:
                        var frequency = JsonConvert.DeserializeObject<Frequency>(Convert.ToString(entity));
                        await _dropdownService.UpdateFrequency(frequency, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.FrequencyPeriods:
                        var frequencyPeriod = JsonConvert.DeserializeObject<FrequencyPeriod>(Convert.ToString(entity));
                        await _dropdownService.UpdateFrequencyPeriod(frequencyPeriod, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.SubProgrammeTypes:
                        var subProgrammeType = JsonConvert.DeserializeObject<SubProgrammeType>(Convert.ToString(entity));
                        await _dropdownService.UpdateSubProgrammeType(subProgrammeType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Directorates:
                        var directorate = JsonConvert.DeserializeObject<Directorate>(Convert.ToString(entity));
                        await _dropdownService.UpdateDirectorate(directorate, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Banks:
                        var bank = JsonConvert.DeserializeObject<Bank>(Convert.ToString(entity));
                        await _dropdownService.UpdateBank(bank, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Branches:
                        var branch = JsonConvert.DeserializeObject<Branch>(Convert.ToString(entity));
                        await _dropdownService.UpdateBranch(branch, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.AccountTypes:
                        var accountType = JsonConvert.DeserializeObject<AccountType>(Convert.ToString(entity));
                        await _dropdownService.UpdateAccountType(accountType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.CompliantCycleRules:
                        var rule = JsonConvert.DeserializeObject<CompliantCycleRule>(Convert.ToString(entity));
                        await _dropdownService.UpdateCompliantCycleRule(rule, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Race:
                        var race = JsonConvert.DeserializeObject<Race>(Convert.ToString(entity));
                        await _dropdownService.UpdateRace(race, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Gender:
                        var gender = JsonConvert.DeserializeObject<Gender>(Convert.ToString(entity));
                        await _dropdownService.UpdateGender(gender, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.RegistrationStatus:
                        var registrationStatus = JsonConvert.DeserializeObject<RegistrationStatus>(Convert.ToString(entity));
                        await _dropdownService.UpdateRegistrationStatus(registrationStatus, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.StaffCategory:
                        var staffCategory = JsonConvert.DeserializeObject<StaffCategory>(Convert.ToString(entity));
                        await _dropdownService.UpdateStaffCategory(staffCategory, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.QuestionCategory:
                        var category = JsonConvert.DeserializeObject<QuestionCategory>(Convert.ToString(entity));
                        await _dropdownService.UpdateQuestionCategory(category, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.QuestionSection:
                        var section = JsonConvert.DeserializeObject<QuestionSection>(Convert.ToString(entity));
                        await _dropdownService.UpdateQuestionSection(section, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Question:
                        var question = JsonConvert.DeserializeObject<Question>(Convert.ToString(entity));
                        await _dropdownService.UpdateQuestion(question, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResponseType:
                        var responseType = JsonConvert.DeserializeObject<ResponseType>(Convert.ToString(entity));
                        await _dropdownService.UpdateResponseType(responseType, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResponseOption:
                        var responseOption = JsonConvert.DeserializeObject<ResponseOption>(Convert.ToString(entity));
                        await _dropdownService.UpdateResponseOption(responseOption, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.WorkflowAssessment:
                        var assessment = JsonConvert.DeserializeObject<WorkflowAssessment>(Convert.ToString(entity));
                        await _dropdownService.UpdateWorkflowAssessment(assessment, base.GetUserIdentifier());
                        break;
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEntity action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("dropdownTypeEnum/{dropdownType}/id/{id}", Name = "delete")]
        public async Task<IActionResult> Delete(int id, DropdownTypeEnum dropdownType)
        {
            try
            {
                switch (dropdownType)
                {
                   case DropdownTypeEnum.QuestionCategory:
                       // var category = JsonConvert.DeserializeObject<QuestionCategory>(Convert.ToString(entity));
                        await _dropdownService.DeleteQuestionCategory(id, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.QuestionSection:
                       // var section = JsonConvert.DeserializeObject<QuestionSection>(Convert.ToString(entity));
                        await _dropdownService.DeleteQuestionSection(id, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.Question:
                       // var question = JsonConvert.DeserializeObject<Question>(Convert.ToString(entity));
                        await _dropdownService.DeleteQuestion(id, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResponseType:
                      //  var responseType = JsonConvert.DeserializeObject<ResponseType>(Convert.ToString(entity));
                        await _dropdownService.DeleteResponseType(id, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.ResponseOption:
                      //  var responseOption = JsonConvert.DeserializeObject<ResponseOption>(Convert.ToString(entity));
                        await _dropdownService.DeleteResponseOption(id, base.GetUserIdentifier());
                        break;
                    case DropdownTypeEnum.WorkflowAssessment:
                       // var assessment = JsonConvert.DeserializeObject<WorkflowAssessment>(Convert.ToString(entity));
                        await _dropdownService.DeleteWorkflowAssessment(id, base.GetUserIdentifier());
                        break;
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEntity action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("activity/name/{name}", Name = "GetActivityByName")]
        public async Task<IActionResult> GetActivityByName(string name)
        {
            try
            {
                var results = await _dropdownService.SearchActivityByName(name);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetActivityByName action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("facility/facilityTypeId/{facilityTypeId}/facilitySubDistrictId/{facilitySubDistrictId}/facilityClassId/{facilityClassId}/name/{name}", Name = "GetFacilityListByModel")]
        public async Task<IActionResult> GetFacilityListByModel(int facilityTypeId, int facilitySubDistrictId, int facilityClassId, string name)
        {
            try
            {
                var results = await _dropdownService.GetFacilityListByModel(new FacilityList { FacilityTypeId = facilityTypeId, FacilitySubDistrictId = facilitySubDistrictId, FacilityClassId = facilityClassId, Name = name });
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFacilityListByModel action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("facility", Name = "CreateFacilityList")]
        public async Task<IActionResult> Create([FromBody] FacilityList model)
        {
            try
            {
                await _dropdownService.CreateFacility(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateFacilityList action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("facility", Name = "UpdateFacilityList")]
        public async Task<IActionResult> UpdateFacilityList([FromBody] FacilityList model)
        {
            try
            {
                await _dropdownService.UpdateFacility(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateFacilityList action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("activity", Name = "CreateActivityList")]
        public async Task<IActionResult> Create([FromBody] ActivityList model)
        {
            try
            {
                model = await _dropdownService.CreateActivityList(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateActivityList action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("resource", Name = "CreateResourceList")]
        public async Task<IActionResult> Create([FromBody] ResourceList model)
        {
            try
            {
                model = await _dropdownService.CreateResourceList(model, base.GetUserIdentifier());
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateResourceList action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("financial-year", Name = "GetFromCurrentFinancialYear")]
        public async Task<IActionResult> GetFromCurrentFinancialYear()
        {
            try
            {
                var results = await _dropdownService.GetFromCurrentFinancialYear();
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFromCurrentFinancialYear action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get dropdown entities by another dropdown's id
        /// </summary>
        /// <param name="dropdownType"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpGet("dropdownTypeEnum/{dropdownType}/entityId/{entityId}", Name = "GetEntitiesByEntityId")]
        public async Task<IActionResult> GetEntitiesByEntityId(DropdownTypeEnum dropdownType, int entityId)
        {
            try
            {
                switch (dropdownType)
                {
                    case DropdownTypeEnum.SubProgramme:
                        var subProgrammes = await _dropdownService.GetSubProgrammesByProgrammeId(entityId);
                        return Ok(subProgrammes);
                    case DropdownTypeEnum.SubProgrammeTypes:
                        var subProgrammeTypes = await _dropdownService.GetSubProgrammeTypesBySubProgrammeId(entityId);
                        return Ok(subProgrammeTypes);
                    case DropdownTypeEnum.Branches:
                        var branches = await _dropdownService.GetBranchesByBankId(entityId);
                        return Ok(branches);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEntitiesByEntityId action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("branch/branchId/{branchId}", Name = "GetBranchById")]
        public async Task<IActionResult> GetBranchById(int branchId)
        {
            try
            {
                var results = await _dropdownService.GetBranchById(branchId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBranchById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("account-type/accountTypeId/{accountTypeId}", Name = "GetAccountTypeById")]
        public async Task<IActionResult> GetAccountTypeById(int accountTypeId)
        {
            try
            {
                var results = await _dropdownService.GetAccountTypeById(accountTypeId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAccountTypeById action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion
    }
}
