using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface INpoService
	{
		Task<IEnumerable<Npo>> Get(string userIdentifier, AccessStatusEnum accessStatus);

        Task<IEnumerable<Npo>> Get(string email);

        Task<IEnumerable<Npo>> GetQuickCaptures(string userIdentifier, AccessStatusEnum accessStatus);


        Task<Npo> GetById(int id);

		Task<IEnumerable<Npo>> Search(string name);

		Task<IEnumerable<Npo>> SearchApprovedNpo(string name);

		Task<Npo> GetByNameAndOrgTypeId(string name, int organisationTypeId, string CCode);

		Task Create(Npo npo, string userIdentifier);

		Task Update(Npo npo, string userIdentifier);

		Task UpdateNpoStatus(Npo npo, string userIdentifier);
	}
}
