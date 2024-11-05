

using NPOMS.Domain.Entities;
using NPOMS.Domain.FundingAssessment;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentApplicationGet
    {   
        public int Id { get; private set; }
        public int ApplicationId { get; private set; }
        public int OrganisationId { get; private set; }
        public string OrganisationName { get; private set; }
        public string CCode { get; private set; }
        public string FinancialYearName { get; private set; }

        public string FundingAssessmentStatusName { get; private set; }
        public bool IsCompliant { get; private set; }
        public bool PreSelected { get; private set; }
        public int SelectedAreaCount { get; private set; }



        public dtoFundingAssessmentApplicationGet(Application application, FundingAssessmentForm fundingAssessmentForm)
        {
            this.Id = fundingAssessmentForm?.Id ?? 0;
            this.ApplicationId = application.Id;
            this.OrganisationId = application.NpoId;
            this.OrganisationName = application.Npo.Name;
            this.CCode = application.Npo.CCode;
            this.FinancialYearName = application.ApplicationPeriod.FinancialYear.Name;
            this.FundingAssessmentStatusName = "";//"Pending DOI Capturer"; "Pending Assessment Capturer" "Pending Assessment Approver " "Assessment Completed"

            if (fundingAssessmentForm == null)
            {
                this.FundingAssessmentStatusName = "Pending DOI Capturer";
            }
            else if (fundingAssessmentForm.DOICapturerId > 0 && fundingAssessmentForm.DOIApproverId == null)
            {
                this.FundingAssessmentStatusName = "Pending Assessment Capturer";
            }
            else if (fundingAssessmentForm.DOICapturerId > 0 && fundingAssessmentForm.DOIApproverId > 0)
            {
                this.FundingAssessmentStatusName = "Assessment Completed";
            }
            else 
            {
                this.FundingAssessmentStatusName = "Pending Assessment Approver";
            }
        }
    }
}
