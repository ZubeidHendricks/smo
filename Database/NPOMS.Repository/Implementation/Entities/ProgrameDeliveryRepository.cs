using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
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
        RepositoryContext _repositoryContext;
        public ProgrameDeliveryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
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


        public async Task<IEnumerable<ServiceDeliveryArea>> GetServiveDeliveryMasterByProgramId(int programmeId, int npoId)
        {
            var npoProfile =  await _repositoryContext.NpoProfiles.Where(pro => pro.NpoId == npoId).FirstOrDefaultAsync();

            var result = await FindByCondition(x => x.ProgramId.Equals(programmeId) && x.IsActive && x.NpoProfileId == npoProfile.Id)
                        .Include(x => x.DistrictCouncil)
                        .Include(x => x.ApprovalStatus)
                        .Include(x => x.LocalMunicipality)
                        .Include(x => x.ServiceDeliveryAreas)
                        .AsNoTracking().ToListAsync();

            var serviceDeliveryAreaIds = result.SelectMany(psd =>
                                  psd.ServiceDeliveryAreas
                                 .Where(sda => sda.IsActive)
                                 .Select(sda => sda.ServiceDeliveryAreaId))
                                 .Distinct();

            var activeServiceDeliveryAreas = await _repositoryContext.ServiceDeliveryAreas
                                       .Where(sda => serviceDeliveryAreaIds.Contains(sda.Id))
                                       .ToListAsync();

            return activeServiceDeliveryAreas;
        }

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetProgrammeDeliveryArea()
        {
            var result = await FindAll()
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
            var result = await FindByCondition(x => x.NpoProfileId == npoProfileId)
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

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryByProgramId(int programmeId, int npoProfileId)
        {
            var result = await FindByCondition(x => x.ProgramId.Equals(programmeId) && x.NpoProfileId == npoProfileId && x.IsActive)
                           .AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId)
        {
            var result = await FindByCondition(x => x.ProgramId.Equals(programmeId) 
            && x.SubProgrammeId.Equals(subProgramId)
            && x.SubProgrammeTypeId.Equals(subProgramTypeId)
            && x.NpoProfileId == npoProfileId && x.IsActive)
                           .AsNoTracking().ToListAsync();

            return result;
        }
    }
}
