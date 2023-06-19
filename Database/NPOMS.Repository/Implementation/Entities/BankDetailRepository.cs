using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Entities;
using System;
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
        //public async Task CreateEntity(BankDetail model, int currentUserId)
        //{
        //    await CreateAsync(model);
        //}

		#endregion
	}
}
