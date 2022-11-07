using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IAdminService
	{
		Task<IEnumerable<CompliantCycle>> GetCompliantCyclesByIds(int departmentId, int financialYearId);

		Task Create(CompliantCycle model, string userIdentifier);

		Task Update(CompliantCycle model, string userIdentifier);

		Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulesByIds(int departmentId, int financialYearId);

		Task Create(PaymentSchedule model, string userIdentifier);

		Task Update(PaymentSchedule model, string userIdentifier);
	}
}
