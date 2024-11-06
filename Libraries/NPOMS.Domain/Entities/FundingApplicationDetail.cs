using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using NPOMS.Domain.Mapping;

namespace NPOMS.Domain.Entities
{
    [Table("FundingApplicationDetails", Schema = "fa")]
    public class FundingApplicationDetail : BaseEntity
    {

        private ICollection<FinancialMatters> _financialMatters;
        private ICollection<ProjectImplementation> _implementations;
        public int ApplicationPeriodId { get; set; }
        public int? ProjectInformationId { get; set; }
        public int ApplicationId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public int UpdatedUserId { get; set; }
        public int? MonitoringEvaluationId { get; set; }
        public MonitoringEvaluation MonitoringEvaluation { get; set; }
        public int ApplicationDetailId { get; set; }
        public ApplicationDetail ApplicationDetails { get; set; }
        public virtual ApplicationPeriod ApplicationPeriod { get; set; }
        public ProjectInformation ProjectInformation { get; set; }
        public virtual ICollection<ProjectImplementation> Implementations
        {
            get => _implementations ?? (_implementations = new List<ProjectImplementation>());
            set => _implementations = value;
        }

        public virtual ICollection<FinancialMatters> FinancialMatters
        {
            get => _financialMatters ?? (_financialMatters = new List<FinancialMatters>());
            protected set => _financialMatters = value;
        }
    }
}
