using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IPaymentScheduleRepository : IBaseRepository<PaymentSchedule>
	{
		Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulesByIds(int departmentId, int financialYearId);
	}
}
