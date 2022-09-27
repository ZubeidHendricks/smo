using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface INpoRepository : IBaseRepository<Npo>
	{
		Task<IEnumerable<Npo>> GetEntities();

		Task<Npo> GetById(int id);

		Task<IEnumerable<Npo>> SearchByName(string name);

		Task<IEnumerable<Npo>> SearchApprovedNpoByName(string name);

		Task<Npo> GetByNameAndOrgTypeId(string name, int organisationTypeId);

		Task CreateEntity(Npo model);

		Task UpdateEntity(Npo model);

		Task<IEnumerable<Npo>> GetAssignedEntities(string emailAddress);
	}
}
