using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class FundAppSDADetailRepository : BaseRepository<FundAppSDADetail>, IFundAppSDADetailRepository
    {
        public FundAppSDADetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(FundAppSDADetail model)
        {
            await CreateAsync(model);
        }

        public async Task<FundAppSDADetail> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.DistrictCouncil).Include(x => x.LocalMunicipality).AsNoTracking().FirstOrDefaultAsync();
        }    

        public async Task UpdateEntity(FundAppSDADetail model, int currentUserId)
        {
            var oldEntity = await this.RepositoryContext.FundAppSDADetails.FindAsync(model.Id);
            await UpdateAsync(oldEntity, model, true, currentUserId);
        }
    }
}
