using NPOMS.Domain.Budget;
using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IBankService
	{
		Task<IEnumerable<BankDetail>> GetBankDetailsById(int banDetailId);

		Task Create(BankDetail model, string userIdentifier);

		Task Update(BankDetail model, string userIdentifier);

		Task<IEnumerable<BankDetail>> GetBankDetails();

	}
}
