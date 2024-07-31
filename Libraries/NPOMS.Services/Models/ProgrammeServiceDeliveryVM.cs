using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class ProgrammeServiceDeliveryVM
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public int SubProgrammeId { get; set; }
        public int SubProgrammeTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelected { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? RegionId { get; set; }
        public int? ServiceDeliveryAreaId { get; set; }

        public int? DistrictCouncilId { get; set; }
        public int? LocalMunicipalityId { get; set; }
        public DistrictCouncilViewModel DistrictCouncil { get; set; }
        public LocalMunicipalityViewModel LocalMunicipality { get; set; }
        public IEnumerable<RegionViewModel> Regions { get; set; }
        public IEnumerable<ServiceDeliveryAreaViewModel> ServiceDeliveryAreas { get; set; }
        public int ApprovalStatusId { get; set; }
        public AccessStatus ApprovalStatus { get; set; }

    }
}
