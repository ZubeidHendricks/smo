using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Dropdown
{
    [Table("Areas", Schema = "dropdown")]
    public  class Area :BaseEntity
    {

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        public int DistrictId { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
        public DistrictDemographic DistrictDemographic { get; set; }

    }
}
