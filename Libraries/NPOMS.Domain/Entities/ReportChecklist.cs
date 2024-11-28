using NPOMS.Domain.Core;
using System;
namespace NPOMS.Domain.Entities
{
    public class ReportChecklist : BaseEntity

    {
        public bool RequiresTPASubmission { get; set; }

        public bool VerifiableReasonsProvided { get; set; }

        public bool ReportedReportingPeriod { get; set; }

        public bool ReportedServiceOutput{ get; set; }

        public bool SupportingDocuments { get; set; }

        public string RequiresTPASubmissionComments { get; set; }
        public string VerifiableReasonsProvidedComments { get; set; }

        public string ReportedReportingPeriodComments { get; set; }
        public string ReportedServiceOutputComments { get; set; }
        public string SupportingDocumentsComments { get; set; }

        public int ApplicationId { get; set; }

        public int ServiceDeliveryAreaId { get; set; }

        public int QaurterId { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }
        public int FinancialYearId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }

    }
}
