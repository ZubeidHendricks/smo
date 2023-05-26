using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class FundAppServiceDeliveryAreaRepository : BaseRepository<FundAppServiceDeliveryArea>, IFundAppServiceDeliveryAreaRepository
    {
        #region Constructors

        public FundAppServiceDeliveryAreaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<FundAppServiceDeliveryArea> GetById(int id, int geoId)
        {
            return await FindByCondition(x => x.ServiceDeliveryAreaId.Equals(id) && x.FundAppSDADetailId.Equals(geoId)).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<FundAppServiceDeliveryArea>> GetBidServiceDeliveryAreaByGeographicalDetailId(int geographicalDetailId)
        {
            var s = await FindByCondition(x => x.FundAppSDADetailId.Equals(geographicalDetailId) && x.IsActive)
                .Include(x => x.ServiceDeliveryArea).ToListAsync();
            return s;
        }

        public async Task<IEnumerable<FundAppServiceDeliveryArea>> GetAllBidSdasByGeographicalDetailId(int geographicalDetailId)
        {
            return await FindByCondition(x => x.FundAppSDADetailId.Equals(geographicalDetailId))
                .Include(x => x.ServiceDeliveryArea).ToListAsync();
        }
        #endregion
    }



}
