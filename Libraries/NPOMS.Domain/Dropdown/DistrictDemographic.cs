using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace NPOMS.Domain.Dropdown
{

    [Table("DistrictDemographics", Schema = "dropdown")]
    public class DistrictDemographic : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public bool IsSubParent { get; set; } = false;
        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
