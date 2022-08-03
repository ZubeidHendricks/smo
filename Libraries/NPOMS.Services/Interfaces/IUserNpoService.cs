using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IUserNpoService
	{
		Task Create(UserNpo model, string userIdentifier);

		Task<IEnumerable<UserNpo>> Get(string userIdentifier);

		Task Update(UserNpo model, string userIdentifier);

		Task UpdateEntity(UserNpo model, string userIdentifier);

		Task<UserNpo> GetByUserIdAndNpoId(int userId, int NpoId);
	}
}
