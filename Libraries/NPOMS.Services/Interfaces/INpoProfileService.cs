using NPOMS.Domain.Entities;
using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface INpoProfileService
    {
        Task<IEnumerable<NpoProfile>> Get(string userIdentifier);

        Task<NpoProfile> GetById(int id);

        Task Create(NpoProfile profile, string userIdentifier);

        Task Update(NpoProfile profile, string userIdentifier);

        Task<NpoProfile> GetByNpoId(int NpoId);

        Task<IEnumerable<NpoProfileFacilityList>> GetFacilitiesByNpoProfileId(int npoProfileId);

        Task Create(NpoProfileFacilityList model, string userIdentifier);

        Task Update(NpoProfileFacilityList model, string userIdentifier);

        Task<IEnumerable<ServicesRendered>> GetServicesRenderedByNpoProfileId(string source, int npoProfileId);

        Task Create(ServicesRendered model, string userIdentifier);

        Task Update(ServicesRendered model, string userIdentifier);

        Task<IEnumerable<BankDetail>> GetBankDetailsByNpoProfileId(int npoProfileId);

        Task<IEnumerable<ProjectImplementation>> GetProjImplByNpoProfileId(int npoProfileId);

        Task<IEnumerable<ProjectImplementation>> GetProjImplByAppDetailId(int appDetailId);

        Task Create(BankDetail model, string userIdentifier);

        Task Update(BankDetail model, string userIdentifier);

        Task Update(ProjectImplementation model, string userIdentifier);


        Task<IEnumerable<PreviousYearFinance>> GetByNpoProfileIdAsync(int npoProfileId);

        Task CreatePreviousYearFinance(int fundingApplicationId, string userIdentifier);
        Task DeleteById(int id, string userIdentifier);
        Task DeleteBankDetailById(int id, string userIdentifier);

        Task<ProjectImplementation> DeleteProjectImplementationById(int id);

        Task Update(PreviousYearFinance model, string userIdentifier, string npoProfileId);

        Task UpdateIncome(FinancialMattersIncome model, string userIdentifier, string npoProfileId);

        Task UpdateExpenditure(FinancialMattersExpenditure model, string userIdentifier, string npoProfileId);

        Task UpdateOthers(FinancialMattersOthers model, string userIdentifier, string npoProfileId);
        Task<IEnumerable<FinancialMattersIncome>> GetIncomeByNpoProfileIdAsync(int npoProfileId);
        Task<IEnumerable<FinancialMattersExpenditure>> GetExpenditureByNpoProfileIdAsync(int npoProfileId);
        Task<IEnumerable<FinancialMattersOthers>> GetOthersByNpoProfileIdAsync(int npoProfileId);

        Task DeleteExpenditureById(int id, string userIdentifier);
        Task DeleteIncomeById(int id, string userIdentifier);
        Task DeleteOthersById(int id, string userIdentifier);

        Task CreateFinancialMattersIncome(int fundingApplicationId, string userIdentifier);

        Task CreateFinancialMattersExpenditure(int fundingApplicationId, string userIdentifier);

        Task CreateFinancialMattersOther(int fundingApplicationId, string userIdentifier);

        Task Update(AffiliatedOrganisationInformation model, string userIdentifier, string npoProfileId);
        Task Update(SourceOfInformation model, string userIdentifier, string npoProfileId);
        Task<IEnumerable<AffiliatedOrganisationInformation>> GetAffiliatedOrganisationById(int npoProfileId);
        Task<IEnumerable<SourceOfInformation>> GetSourceOfInformationById(int npoProfileId);

        Task<IEnumerable<AuditorOrAffiliation>> GetAuditorOrAffiliations(int entityId);

        Task CreateAuditorOrAffiliation(AuditorOrAffiliation model, string userIdentifier);

        Task UpdateAuditorOrAffiliation(AuditorOrAffiliation model, string userIdentifier);

        Task<IEnumerable<StaffMemberProfile>> GetStaffMemberProfiles(int npoProfileId);

        Task CreateStaffMemberProfile(StaffMemberProfile model, string userIdentifier);

        Task UpdateStaffMemberProfile(StaffMemberProfile model, string userIdentifier);
        Task ApproveNpoProfile(int npoProfileId, string userIdentifier);
        Task RejectNpoProfile(int npoProfileId, string userIdentifier);
        Task SubmitProfileNpoProfile(int npoProfileId, string userIdentifier);
    }
}
