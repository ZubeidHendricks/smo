using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IUserNpoRepository : IBaseRepository<UserNpo>
	{
		Task<IEnumerable<UserNpo>> GetEntities();

		Task<IEnumerable<UserNpo>> GetByCurrentUserId(int currentUserId);

		Task<IEnumerable<UserNpo>> GetApprovedEntities(int currentUserId);

		Task CreateEntity(UserNpo model);

		Task UpdateEntity(UserNpo model, int currentUserId);

		Task<UserNpo> GetById(int id);

		Task<UserNpo> GetByUserAndNpoId(int userId, int NpoId);
	}
}
