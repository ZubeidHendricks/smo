using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Dropdown
{
    [Table("Places", Schema = "dropdown")]
    public class Place : BaseEntity
    {
        private ICollection<SubPlace> _subPlaces;

        public string Name { get; set; }

        public string SystemName { get; set; }

        public int ServiceDeliveryAreaId { get; set; }

        public virtual ServiceDeliveryArea ServiceDeliveryArea { get; set; }
        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public int? ExternalId { get; set; }


        public DateTime? UpdatedDateTime { get; set; }

        public virtual ICollection<SubPlace> SubPlaces
        {
            get => _subPlaces ?? (_subPlaces = new List<SubPlace>());
            protected set => _subPlaces = value;
        }
    }
}
