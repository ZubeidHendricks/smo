using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class RegionViewModel
    {
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int localMunicipalityId { get; set; }
    }
}
