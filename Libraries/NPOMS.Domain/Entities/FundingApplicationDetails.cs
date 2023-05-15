using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
	[Table("FundingApplicationDetails", Schema = "fa")]

    public class FundingApplicationDetails : BaseEntity
    {
        public int ApplicationId { get; set; }
        public int DistrictCouncilId { get; set; }
        public int localMunicipalityId { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountApplyingFor { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public bool? ChangesRequired { get; set; }

        public bool? IsNew { get; set; }

        public LocalMunicipality LocalMunicipality { get; set; }
        public DistrictCouncil DistrictCouncil { get; set; }

    }
}
