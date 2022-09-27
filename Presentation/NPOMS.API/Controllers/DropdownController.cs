using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
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

		#endregion

		#region Constructors

		public DropdownController(
			ILogger<DropdownController> logger,
			IDropdownService dropdownService
			)
		{
			_logger = logger;
			_dropdownService = dropdownService;
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
