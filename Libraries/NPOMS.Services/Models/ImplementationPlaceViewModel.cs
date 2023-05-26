
using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class ImplementationPlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }

        public int ServiceDeliveryAreaId { get; set; }
        public int ImplementationId { get; set; }
        public bool IsActive { get; set; }
    }
}
