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

		Task Create(NpoProfileFacilityList model);

		Task Update(NpoProfileFacilityList model);

		Task<IEnumerable<ServicesRendered>> GetServicesRenderedByNpoProfileId(int npoProfileId);

		Task Create(ServicesRendered model, string userIdentifier);

		Task Update(ServicesRendered model, string userIdentifier);

		Task<IEnumerable<BankDetail>> GetBankDetailsByNpoProfileId(int npoProfileId);

		Task Create(BankDetail model, string userIdentifier);

		Task Update(BankDetail model, string userIdentifier);
	}
}
