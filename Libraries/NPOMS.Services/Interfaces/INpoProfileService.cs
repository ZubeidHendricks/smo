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

		Task<IEnumerable<ServicesRendered>> GetServicesRenderedByNpoProfileId(int npoProfileId);

		Task Create(ServicesRendered model, string userIdentifier);

		Task Update(ServicesRendered model, string userIdentifier);

		Task<IEnumerable<BankDetail>> GetBankDetailsByNpoProfileId(int npoProfileId);

		Task Create(BankDetail model, string userIdentifier);

		Task Update(BankDetail model, string userIdentifier);

        Task<IEnumerable<PreviousYearFinance>> GetByNpoProfileIdAsync(int npoProfileId);
        Task<PreviousYearFinance> DeleteById(int id);
        Task<BankDetail> DeleteBankDetailById(int id);

        Task Update(List<PreviousYearFinance> model, string userIdentifier, string npoProfileId);

        Task UpdateIncome(List<FinancialMattersIncome> model, string userIdentifier, string npoProfileId);

        Task UpdateExpenditure(List<FinancialMattersExpenditure> model, string userIdentifier, string npoProfileId);

        Task UpdateOthers(List<FinancialMattersOthers> model, string userIdentifier, string npoProfileId);
        Task<IEnumerable<FinancialMattersIncome>> GetIncomeByNpoProfileIdAsync(int npoProfileId);
        Task<IEnumerable<FinancialMattersExpenditure>> GetExpenditureByNpoProfileIdAsync(int npoProfileId);		
        Task<IEnumerable<FinancialMattersOthers>> GetOthersByNpoProfileIdAsync(int npoProfileId);

        Task<FinancialMattersExpenditure> DeleteExpenditureById(int id);
        Task<FinancialMattersIncome> DeleteIncomeById(int id);
        Task<FinancialMattersOthers> DeleteOthersById(int id);




        Task Update(List<AffiliatedOrganisationInformation> model, string userIdentifier, string npoProfileId);
        Task Update(SourceOfInformation model, string userIdentifier, string npoProfileId);
        Task<IEnumerable<AffiliatedOrganisationInformation>> GetAffiliatedOrganisationById(int npoProfileId);
        Task<IEnumerable<SourceOfInformation>> GetSourceOfInformationById(int npoProfileId);
    }
}
