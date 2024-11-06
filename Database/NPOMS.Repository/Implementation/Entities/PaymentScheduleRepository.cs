using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
    public class PaymentScheduleRepository : BaseRepository<PaymentSchedule>, IPaymentScheduleRepository
	{
		#region Constructors

		public PaymentScheduleRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulesByIds(int departmentId, int financialYearId)
		{
			return await FindByCondition(x => x.CompliantCycle.DepartmentId.Equals(departmentId) &&
											  x.CompliantCycle.FinancialYearId.Equals(financialYearId) && 
											  x.IsActive)
							.OrderBy(x => x.CompliantCycle.CompliantCycleRuleId).ToListAsync();
		}

		#endregion
	}
}
