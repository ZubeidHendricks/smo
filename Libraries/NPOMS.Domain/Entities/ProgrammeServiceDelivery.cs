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
        public int ProgramId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int? RegionId { get; set; }
        public int? DistrictCouncilId { get; set; }
        public int? LocalMunicipalityId { get; set; }
        public  Region Region { get; set; }
        public  DistrictCouncil DistrictCouncil { get; set; }
        public  LocalMunicipality LocalMunicipality { get; set; }
    }
}
