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

namespace NPOMS.Repository.Interfaces.Entities
{

    public interface IFundAppRegionRepository : IBaseRepository<FundAppSDADetail_Region>
    {

        Task<FundAppSDADetail_Region> GetById(int id, int geoId);

        Task<IEnumerable<FundAppSDADetail_Region>> GetBidRegionByGeographicalDetailId(int geographicalDetailId);
        Task<IEnumerable<FundAppSDADetail_Region>> GetAllBidRegionByGeographicalDetailId(int geographicalDetailId);

    }
}