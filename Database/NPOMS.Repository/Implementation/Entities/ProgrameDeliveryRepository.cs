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
    public class ProgrameDeliveryRepository : BaseRepository<ProgrammeServiceDelivery>, IProgrameDeliveryRepository
    {

        public ProgrameDeliveryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByProgramId(int progId)
        {
            var result =  await FindByCondition(x => x.ProgramId.Equals(progId) && x.IsActive)
                            .Include(x => x.DistrictCouncil)
                            .Include(x => x.LocalMunicipality)                             
                            .Include(x => x.ServiceDeliveryAreas).
                                ThenInclude(x => x.ServiceDeliveryArea)
                            .Include(x => x.Regions)
                              .ThenInclude(x => x.Region)
                           .AsNoTracking().ToListAsync();

            result.ForEach(psd =>
            {
                psd.ServiceDeliveryAreas = psd.ServiceDeliveryAreas.Where(sda => sda.IsActive).ToList();
                psd.Regions = psd.Regions.Where(region => region.IsActive).ToList();
            });

            return result;
        }
    }
}
