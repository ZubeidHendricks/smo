using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("FundAppSDADetail", Schema = "fa")]
    public class FundAppSDADetail : BaseEntity
    {
        private ICollection<FundAppServiceDeliveryArea> _bidServiceDeliveryAreas;
        private ICollection<FundAppSDADetail_Region> _bidRegions;

        public int? RegionId { get; set; }
        public int DistrictCouncilId { get; set; }
        public int LocalMunicipalityId { get; set; }

        public virtual Region Region { get; set; }
        public virtual DistrictCouncil DistrictCouncil { get; set; }
        public virtual LocalMunicipality LocalMunicipality { get; set; }

        public virtual ICollection<FundAppServiceDeliveryArea> ServiceDeliveryAreas
        {
            get => _bidServiceDeliveryAreas ??= new List<FundAppServiceDeliveryArea>();
            set => _bidServiceDeliveryAreas = value;
        }

        public virtual ICollection<FundAppSDADetail_Region> Regions
 
        {
            get => _bidRegions ??= new List<FundAppSDADetail_Region>();
            set => _bidRegions = value;
        }
    }
}
