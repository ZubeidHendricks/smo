
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Services.Models
{
    public class ProjectImplementationViewModel
    {


        public int ID { get; set; }
        public string Description { get; set; }
        public string ProjectObjective { get; set; }
        public int Beneficiaries { get; set; }
        public string TimeframeFrom { get; set; }
        public string TimeframeTo { get; set; }
        public string Results { get; set; }
        public string Resources { get; set; }
        public int Budget { get; set; }
        public int FundingApplicationDetailId { get; set; }
        public IEnumerable<ImplementationPlaceViewModel> Places { get; set; }
        public IEnumerable<ImplemetationSubPlaceViewModel> SubPlaces { get; set; }

    }
}
