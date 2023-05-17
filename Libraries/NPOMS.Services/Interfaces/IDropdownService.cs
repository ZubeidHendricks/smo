using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IDropdownService
	{
		Task<IEnumerable<Role>> GetRoles(bool returnInactive);

		Task CreateRole(Role model, string userIdentifier);

		Task UpdateRole(Role model, string userIdentifier);

		Task<IEnumerable<Department>> GetDepartments(bool returnInactive);

		Task CreateDepartment(Department model, string userIdentifier);

		Task UpdateDepartment(Department model, string userIdentifier);

		Task<IEnumerable<OrganisationType>> GetOrganisationTypes(bool returnInactive);

		Task CreateOrganisationType(OrganisationType model, string userIdentifier);

		Task UpdateOrganisationType(OrganisationType model, string userIdentifier);

		Task<IEnumerable<Title>> GetTitles(bool returnInactive);

		Task CreateTitle(Title model, string userIdentifier);

		Task UpdateTitle(Title model, string userIdentifier);

		Task<IEnumerable<Position>> GetPositions(bool returnInactive);

		Task CreatePosition(Position model, string userIdentifier);

		Task UpdatePosition(Position model, string userIdentifier);

		Task<IEnumerable<AccessStatus>> GetAccessStatuses(bool returnInactive);

		Task CreateAccessStatus(AccessStatus model, string userIdentifier);

		Task UpdateAccessStatus(AccessStatus model, string userIdentifier);

		Task<IEnumerable<Programme>> GetProgrammes(bool returnInactive);

		Task CreateProgramme(Programme model, string userIdentifier);

		Task UpdateProgramme(Programme model, string userIdentifier);

		Task<IEnumerable<SubProgramme>> GetSubProgrammes(bool returnInactive);

		Task CreateSubProgramme(SubProgramme model, string userIdentifier);

		Task UpdateSubProgramme(SubProgramme model, string userIdentifier);

		Task<IEnumerable<FinancialYear>> GetFinancialYears(bool returnInactive);

		Task<IEnumerable<FinancialYear>> GetFromCurrentFinancialYear();

		Task CreateFinancialYear(FinancialYear model, string userIdentifier);

		Task UpdateFinancialYear(FinancialYear model, string userIdentifier);

		Task<IEnumerable<ApplicationType>> GetApplicationTypes(bool returnInactive);

		Task CreateApplicationType(ApplicationType model, string userIdentifier);

		Task UpdateApplicationType(ApplicationType model, string userIdentifier);

		Task<IEnumerable<RecipientType>> GetRecipientTypes(bool returnInactive);

		Task CreateRecipientType(RecipientType model, string userIdentifier);

		Task UpdateRecipientType(RecipientType model, string userIdentifier);

		Task<IEnumerable<ActivityType>> GetActivityTypes(bool returnInactive);

		Task CreateActivityType(ActivityType model, string userIdentifier);

		Task UpdateActivityType(ActivityType model, string userIdentifier);

		Task<IEnumerable<ResourceType>> GetResourceTypes(bool returnInactive);

		Task CreateResourceType(ResourceType model, string userIdentifier);

		Task UpdateResourceType(ResourceType model, string userIdentifier);

		Task<IEnumerable<ServiceType>> GetServiceTypes(bool returnInactive);

		Task CreateServiceType(ServiceType model, string userIdentifier);

		Task UpdateServiceType(ServiceType model, string userIdentifier);

		Task<IEnumerable<AllocationType>> GetAllocationTypes(bool returnInactive);

		Task CreateAllocationType(AllocationType model, string userIdentifier);

		Task UpdateAllocationType(AllocationType model, string userIdentifier);

		Task<IEnumerable<FacilityDistrict>> GetFacilityDistricts(bool returnInactive);

		Task CreateFacilityDistrict(FacilityDistrict model, string userIdentifier);

		Task UpdateFacilityDistrict(FacilityDistrict model, string userIdentifier);

		Task<IEnumerable<FacilitySubDistrict>> GetFacilitySubDistricts(bool returnInactive);

		Task CreateFacilitySubDistrict(FacilitySubDistrict model, string userIdentifier);

		Task UpdateFacilitySubDistrict(FacilitySubDistrict model, string userIdentifier);

		Task<IEnumerable<FacilityClass>> GetFacilityClasses(bool returnInactive);

		Task CreateFacilityClass(FacilityClass model, string userIdentifier);

		Task UpdateFacilityClass(FacilityClass model, string userIdentifier);

		Task<IEnumerable<FacilityList>> GetFacilityList(bool returnInactive);

		Task<FacilityList> GetFacilityListByModel(FacilityList model);

		Task<IEnumerable<FacilityList>> SearchFacilityByName(string name);

		Task CreateFacility(FacilityList model, string userIdentifier);

		Task UpdateFacility(FacilityList model, string userIdentifier);

		Task<IEnumerable<DocumentType>> GetDocumentTypes(bool returnInactive);

		Task CreateDocumentType(DocumentType model, string userIdentifier);

		Task UpdateDocumentType(DocumentType model, string userIdentifier);

		Task<IEnumerable<FacilityType>> GetFacilityTypes(bool returnInactive);

		Task CreateFacilityType(FacilityType model, string userIdentifier);

		Task UpdateFacilityType(FacilityType model, string userIdentifier);

		Task<IEnumerable<Status>> GetStatuses(bool returnInactive);

		Task CreateStatus(Status model, string userIdentifier);

		Task UpdateStatus(Status model, string userIdentifier);

		Task<IEnumerable<ActivityList>> GetActivityList(bool returnInactive);

		Task<IEnumerable<ActivityList>> SearchActivityByName(string name);

		Task<ActivityList> CreateActivityList(ActivityList model, string userIdentifier);

		Task<IEnumerable<ResourceList>> GetResourceList(bool returnInactive);

		Task<ResourceList> CreateResourceList(ResourceList model, string userIdentifier);

		Task<IEnumerable<ProvisionType>> GetProvisionTypes(bool returnInactive);

		Task CreateProvisionType(ProvisionType model, string userIdentifier);

		Task UpdateProvisionType(ProvisionType model, string userIdentifier);

		Task<IEnumerable<Utility>> GetUtilities(bool returnInactive);

		Task CreateUtility(Utility model, string userIdentifier);

		Task UpdateUtility(Utility model, string userIdentifier);

		Task<IEnumerable<TrainingMaterial>> GetAllTrainingMaterials(bool returnInactive);

		Task<IEnumerable<Frequency>> GetFrequencies(bool returnInactive);

		Task CreateFrequency(Frequency model, string userIdentifier);

		Task UpdateFrequency(Frequency model, string userIdentifier);

		Task<IEnumerable<FrequencyPeriod>> GetFrequencyPeriods(bool returnInactive);

		Task<IEnumerable<FrequencyPeriod>> GetFrequencyPeriodsByFrequencyId(int frequencyId);

		Task CreateFrequencyPeriod(FrequencyPeriod model, string userIdentifier);

		Task UpdateFrequencyPeriod(FrequencyPeriod model, string userIdentifier);

		Task<IEnumerable<SubProgrammeType>> GetSubProgrammeTypes(bool returnInactive);

		Task CreateSubProgrammeType(SubProgrammeType model, string userIdentifier);

		Task UpdateSubProgrammeType(SubProgrammeType model, string userIdentifier);

		Task<IEnumerable<Directorate>> GetDirectorates(bool returnInactive);

		Task CreateDirectorate(Directorate model, string userIdentifier);

		Task UpdateDirectorate(Directorate model, string userIdentifier);

		Task<IEnumerable<SubProgramme>> GetSubProgrammesByProgrammeId(int programmeId);

		Task<IEnumerable<SubProgrammeType>> GetSubProgrammeTypesBySubProgrammeId(int subProgrammeId);

		Task<IEnumerable<Bank>> GetBanks(bool returnInactive);

		Task CreateBank(Bank model, string userIdentifier);

		Task UpdateBank(Bank model, string userIdentifier);

		Task<IEnumerable<Branch>> GetBranches(bool returnInactive);

		Task<IEnumerable<Branch>> GetBranchesByBankId(int bankId);

		Task<Branch> GetBranchById(int id);

		Task CreateBranch(Branch model, string userIdentifier);

		Task UpdateBranch(Branch model, string userIdentifier);

		Task<IEnumerable<AccountType>> GetAccountTypes(bool returnInactive);

		Task<AccountType> GetAccountTypeById(int id);

		Task CreateAccountType(AccountType model, string userIdentifier);

		Task UpdateAccountType(AccountType model, string userIdentifier);

		Task<IEnumerable<CompliantCycleRule>> GetCompliantCycleRules(bool returnInactive);

		Task<CompliantCycleRule> GetCompliantCycleRuleById(int id);

		Task CreateCompliantCycleRule(CompliantCycleRule model, string userIdentifier);

		Task UpdateCompliantCycleRule(CompliantCycleRule model, string userIdentifier);

        Task<IEnumerable<DistrictCouncil>> GetDistrictCouncils(bool returnInactive);

        Task<IEnumerable<LocalMunicipality>> GetLocalMunicipalities(bool returnInactive);

        Task<IEnumerable<Region>> GetRegions(bool returnInactive);

        Task<IEnumerable<ServiceDeliveryArea>> GetServiceDeliveryAreas(bool returnInactive);

		Task<IEnumerable<PropertyType>> GetPropertyTypes(bool returnInactive);

		Task<IEnumerable<PropertySubType>> GetPropertySubTypes(bool returnInactive);


    }
}
