using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class BankDetailRepository : BaseRepository<BankDetail>, IBankDetailRepository
	{
		#region Constructors

		public BankDetailRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<BankDetail>> GetByNpoProfileId(int npoProfileId)
		{
			return await FindByCondition(x => x.NpoProfileId.Equals(npoProfileId) && x.IsActive)
							.AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
