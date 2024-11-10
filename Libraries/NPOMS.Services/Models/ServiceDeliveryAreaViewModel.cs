using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class ServiceDeliveryAreaViewModel
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public int ServiceDeliveryAreaId { get; set; }
    }
}
