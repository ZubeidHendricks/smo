﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Dropdown
{
    [Table("ServiceDeliveryAreas", Schema = "dropdown")]

    public class ServiceDeliveryArea : BaseEntity
    {
        [Required]
        public int RegionId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        public string SystemName { get; set; }
        
        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public int? ExternalId { get; set; }
   
        public Region Region { get; set; }

    }
}
