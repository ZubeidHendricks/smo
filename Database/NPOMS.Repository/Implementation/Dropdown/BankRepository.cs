using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
	public class BankRepository : BaseRepository<Bank>, IBankRepository
	{
		#region Constructors

		public BankRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<Bank>> GetEntities(bool returnInactive)
		{
			if (returnInactive)
			{
				return await FindAll()
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
			else
			{
				return await FindAll()
								.Where(x => x.IsActive)
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
		}

		#endregion
	}
}
