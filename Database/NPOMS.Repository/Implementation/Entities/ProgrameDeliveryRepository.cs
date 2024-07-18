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

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByProgramId(int programmeId, int npoProfileId)
        {
            var result = await FindByCondition(x => x.ProgramId.Equals(programmeId) && x.IsActive && x.NpoProfileId == npoProfileId)
                            .Include(x => x.DistrictCouncil)
                            .Include(x => x.ApprovalStatus)
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

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetails(int npoProfileId)
        {
            var result = await FindByCondition(x => x.IsActive && x.NpoProfileId == npoProfileId)
                            .Include(x => x.DistrictCouncil)
                            .Include(x => x.ApprovalStatus)
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

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryyProgramId(int programmeId, int npoProfileId)
        {
            var result = await FindByCondition(x => x.ProgramId.Equals(programmeId) && x.NpoProfileId == npoProfileId && x.IsActive)
                           .AsNoTracking().ToListAsync();

            return result;
        }
    }
}
