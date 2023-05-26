
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class FundAppSDADetailViewModel
    {
        public int Id { get; set; }
        public int? RegionId { get; set; }
        public int DistrictCouncilId { get; set; }
        public int LocalMunicipalityId { get; set; }
        public DistrictCouncilViewModel DistrictCouncil { get; set; }
        public LocalMunicipalityViewModel LocalMunicipality { get; set; }
        public IEnumerable<RegionViewModel> Regions { get; set; }
        public IEnumerable<ServiceDeliveryAreaViewModel> ServiceDeliveryAreas { get; set; }
        public virtual ServiceDeliveryArea ServiceDeliveryArea { get; set; }
    }
}
