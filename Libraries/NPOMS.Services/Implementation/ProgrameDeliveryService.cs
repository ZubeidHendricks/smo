using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{

    public class ProgrameDeliveryService : IProgrameDeliveryService
    {
        private IProgrameDeliveryRepository _programeDeliveryRepository;

        public ProgrameDeliveryService(
            IProgrameDeliveryRepository programeDeliveryRepository)
        {
            _programeDeliveryRepository = programeDeliveryRepository;

        }

        public async Task<IEnumerable<ProgrammeServiceDeliveryVM>> GetDeliveryDetailsByProgramId(int progId)
        {
            var model = await _programeDeliveryRepository.GetDeliveryDetailsByProgramId(progId);

            return await MapToViewModelListAsync(model);
        }


        public async Task<IEnumerable<ProgrammeServiceDeliveryVM>> MapToViewModelListAsync(IEnumerable<ProgrammeServiceDelivery> entities)
        {
            var viewModelList = new List<ProgrammeServiceDeliveryVM>();

            foreach (var entity in entities)
            {
                var viewModel = await MapToViewModelAsync(entity);
                viewModelList.Add(viewModel);
            }

            return viewModelList;
        }


        private async Task<ProgrammeServiceDeliveryVM> MapToViewModelAsync(ProgrammeServiceDelivery entity)
        {
            var viewModel = new ProgrammeServiceDeliveryVM
            {
                ProgramId = entity.ProgramId
            };

            if (entity.DistrictCouncilId.HasValue)
            {
                viewModel.DistrictCouncil = new DistrictCouncilViewModel
                {
                    Id = entity.DistrictCouncil.Id,
                    Name = entity.DistrictCouncil.Name,
                };
            }

            if (entity.LocalMunicipalityId.HasValue)
            {
                viewModel.LocalMunicipality = new LocalMunicipalityViewModel
                {
                    ID = entity.LocalMunicipality.Id,
                    ParentId = entity.LocalMunicipality.DistrictCouncilId,
                    Name = entity.LocalMunicipality.Name,
                };
            }

            viewModel.Regions = await Task.WhenAll(entity.Regions.Select(async r => new RegionViewModel
            {
                ID = r.Region.Id,
                Name = r.Region.Name,
                IsActive = r.Region.IsActive,
            }));

            viewModel.ServiceDeliveryAreas = await Task.WhenAll(entity.ServiceDeliveryAreas.Select(async sda => new ServiceDeliveryAreaViewModel
            {
                ID = sda.ServiceDeliveryArea.Id,
                Name = sda.ServiceDeliveryArea.Name,
                IsActive = sda.ServiceDeliveryArea.IsActive,
                RegionId = sda.ServiceDeliveryArea.RegionId,
            }));

            viewModel.Id = entity.Id;
            viewModel.ApprovalStatus = entity.ApprovalStatus;

            return viewModel;
        }

    }
}
