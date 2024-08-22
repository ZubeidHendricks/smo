using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface INpoRepository : IBaseRepository<Npo>
	{
		Task<IEnumerable<Npo>> GetEntities();

		Task<IEnumerable<Npo>> GetEntitiesWithoutDetails();

        Task<IEnumerable<Npo>> GetQuickCapturers();

        //Task<Npo> GetQuickCapturersByQCId(int id);

        Task<Npo> GetById(int id);

		Task<IEnumerable<Npo>> SearchByName(string name);

		Task<IEnumerable<Npo>> SearchApprovedNpoByName(string name);

		Task<Npo> GetByNameAndOrgTypeId(string name, int organisationTypeId, string CCode);

		Task CreateEntity(Npo model);

		Task UpdateEntity(Npo model, int currentUserId);

		Task<IEnumerable<Npo>> GetAssignedEntities(string emailAddress);
	}
}
