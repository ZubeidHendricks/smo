using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using System.Linq;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
    public class FundAppRegionRepository : BaseRepository<FundAppSDADetail_Region>, IFundAppRegionRepository
    {
        public FundAppRegionRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        #region Methods

        public async Task<FundAppSDADetail_Region> GetById(int id, int geoId)
        {
            return await FindByCondition(x => x.RegionId.Equals(id) && x.FundAppSDADetailId.Equals(geoId)).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<FundAppSDADetail_Region>> GetBidRegionByGeographicalDetailId(int geographicalDetailId)
        {
            return await FindByCondition(x => x.FundAppSDADetailId.Equals(geographicalDetailId) && x.IsActive)
                .Include(x => x.Region).ToListAsync();
        }

        public async Task<IEnumerable<FundAppSDADetail_Region>> GetAllBidRegionByGeographicalDetailId(int geographicalDetailId)
        {
            return await FindByCondition(x => x.FundAppSDADetailId.Equals(geographicalDetailId))
                .Include(x => x.Region).ToListAsync();
        }

        #endregion
    }

}