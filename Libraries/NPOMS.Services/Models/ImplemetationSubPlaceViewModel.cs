using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class ImplemetationSubPlaceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }
        public int SubPlaceId { get; set; }
        public int ImplementationId { get; set; }
        public bool IsActive { get; set; }
    }
}
