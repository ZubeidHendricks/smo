

using NPOMS.Domain.Entities;
using NPOMS.Domain.FundingAssessment;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentApplicationGet
    {
        public int ApplicationId { get; private set; }
        public int OrganisationId { get; private set; }
        public string RefNo { get; private set; }
        public string OrganisationName { get; private set; }
        public string OrganisationType { get; private set; }
        public string ApplicationName { get; private set; }
        public string SubProgrammeName { get; private set; }
        public string FinancialYearName { get; private set; }
        public string ClosingDate { get; private set; }
        public string FundingAssessmentStatusName { get; private set; }



        public dtoFundingAssessmentApplicationGet(Application application, FundingAssessmentForm fundingAssessmentForm)
        {
            this.ApplicationId = application.Id;
            this.OrganisationId = application.NpoId;
            this.RefNo = application.RefNo;
            this.OrganisationName = application.Npo.Name;
            this.OrganisationType = application.Npo.OrganisationType.Name;
            this.ApplicationName = "";
            this.SubProgrammeName = "";
            this.FinancialYearName = application.ApplicationPeriod.Name;
            this.ClosingDate = "";
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
