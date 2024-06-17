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
    [Table("ProgrammeServiceDelivery", Schema = "dbo")]
    public class ProgrammeServiceDelivery : BaseEntity
    {
        private ICollection<ProgrameServiceDeliveryArea> _ServiceDeliveryAreas;
        private ICollection<ProgrammeSDADetail_Region> _Regions;

        public int ProgramId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? DistrictCouncilId { get; set; }
        public int? LocalMunicipalityId { get; set; }
        public  DistrictCouncil DistrictCouncil { get; set; }
        public  LocalMunicipality LocalMunicipality { get; set; }

        public virtual ICollection<ProgrameServiceDeliveryArea> ServiceDeliveryAreas
        {
            get => _ServiceDeliveryAreas ??= new List<ProgrameServiceDeliveryArea>();
            set => _ServiceDeliveryAreas = value;
        }

        public virtual ICollection<ProgrammeSDADetail_Region> Regions

        {
            get => _Regions ??= new List<ProgrammeSDADetail_Region>();
            set => _Regions = value;
        }
    }
}
