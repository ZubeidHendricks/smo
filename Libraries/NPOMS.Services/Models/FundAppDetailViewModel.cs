
using Microsoft.Graph.TermStore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class FundAppDetailViewModel
    {
        public FundAppDetailViewModel()
        {
            FinancialMatters = FinancialMatters ?? new List<FinancialMattersViewModel>();
            Implementations = Implementations ?? new List<ProjectImplementationViewModel>();
        }
        public int Id { get; set; }
        public int ApplicationPeriodId { get; set; }
        public int? ProjectInformationId { get; set; }
        public bool IsActive { get; set; }
        public int ApplicationId { get; set; }
        public int ProgramId { get; set; }
        public int subProgramId { get; set; }
        public int subProgramTypeId {  get; set; }
        public string ApplicationPeriodName { get; set; }
        public string MonEvDescrition { get; set; }
        public ProjectInformationViewModel ProjectInformation { get; set; }
        public int ApplicationDetailId { get; set; }
        public ApplicationDetailViewModel ApplicationDetails { get; set; }

        public int? MonitoringEvaluationId { get; set; }    
        public MonitoringEvaluationViewModel MonitoringEvaluation { get; set; }
        public List<ProjectImplementationViewModel> Implementations { get; set; }
        public List<FinancialMattersViewModel> FinancialMatters { get; set; }

        public virtual Npo Npo { get; set; }
        public virtual User User { get; set; }
        public ApplicationPeriod ApplicationPeriod { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string UpdatedUser { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

    }
}
