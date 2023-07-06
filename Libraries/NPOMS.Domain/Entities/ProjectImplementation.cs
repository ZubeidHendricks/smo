using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NPOMS.Domain.Mapping;

namespace NPOMS.Domain.Entities
{
    [Table("ProjectImplementations", Schema = "fa")]
    public class  ProjectImplementation : BaseEntity
    {
        private ICollection<ProjectImplementationPlace> _implementationPlaces;
        private ICollection<ProjectImplementationSubPlace> _implementationSubPlaces;
        public int NpoProfileId { get; set; }

        public string Description { get; set; }
        public string ProjectObjective { get; set; }
        public int Beneficiaries { get; set; }
        public string TimeframeFrom { get; set; }
        public string TimeframeTo { get; set; }

        public string Results { get; set; }
        public string Resources { get; set; }
        public int BudgetAmount { get; set; }
        public int FundingApplicationDetailId { get; set; }

        public virtual FundingApplicationDetail FundingApplicationDetail { get; set; }
        public virtual ICollection<ProjectImplementationPlace> ImplementationPlaces
        {
            get => _implementationPlaces ?? (_implementationPlaces = new List<ProjectImplementationPlace>());
            set => _implementationPlaces = value;
        }

        public virtual ICollection<ProjectImplementationSubPlace> ImplementationSubPlaces
        {
            get => _implementationSubPlaces ?? (_implementationSubPlaces = new List<ProjectImplementationSubPlace>());
            set => _implementationSubPlaces = value;
        }


    }
}
