using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IApplicationPeriodService
	{
		Task<IEnumerable<ApplicationPeriod>> Get();

		Task<ApplicationPeriod> GetById(int id);

		Task Create(ApplicationPeriod model, string userIdentifier);

		Task Update(ApplicationPeriod model, string userIdentifier);
	}
}
