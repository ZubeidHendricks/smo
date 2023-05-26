using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{

    public interface IFundAppServiceDeliveryAreaRepository : IBaseRepository<FundAppServiceDeliveryArea>
    {

        Task<FundAppServiceDeliveryArea> GetById(int id, int i);
        Task<IEnumerable<FundAppServiceDeliveryArea>> GetBidServiceDeliveryAreaByGeographicalDetailId(int geographicalDetailId);
        Task<IEnumerable<FundAppServiceDeliveryArea>> GetAllBidSdasByGeographicalDetailId(int geographicalDetailId);
    }

}
