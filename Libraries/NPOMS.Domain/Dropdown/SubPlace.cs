using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Dropdown
{
    [Table("SubPlaces", Schema = "dropdown")]
    public class SubPlace : BaseEntity
    {
        public string Name { get; set; }

        public string SystemName { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public int? ExternalId { get; set; }


        public DateTime? UpdatedDateTime { get; set; }
    }
}
