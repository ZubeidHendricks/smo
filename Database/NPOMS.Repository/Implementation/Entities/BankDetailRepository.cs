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

        public async Task<BankDetail> DeleteBankDetailById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<BankDetail>> GetByNpoProfileId(int npoProfileId)
		{
			return await FindByCondition(x => x.NpoProfileId.Equals(npoProfileId) && x.IsActive)
							.AsNoTracking().ToListAsync();
		}

		public async Task<BankDetail> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
		}


		#endregion
	}
}
