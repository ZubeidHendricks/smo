

using NPOMS.Domain.Entities;
using NPOMS.Domain.FundingAssessment;
using System.Linq;

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
        public string ProgrammeName { get; }
        public string SubProgrammeName { get; }
        public string SubProgrammeTypeName { get; }

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
            this.ProgrammeName = application.ApplicationPeriod?.Programme?.Name;
            this.SubProgrammeName = application.ApplicationPeriod?.SubProgramme?.Name;
            this.SubProgrammeTypeName = application.ApplicationPeriod?.SubProgrammeType?.Name;
            this.SelectedAreaCount = fundingAssessmentForm?.FundingAssessmentFormSDAs?.Where(x=>x.IsSelected)?.Count() ?? 0;
            this.IsCompliant = (fundingAssessmentForm?.DOICapturerId ?? 0) > 0;
            this.PreSelected = (fundingAssessmentForm?.DOIApproverId ?? 0) > 0;

            if (fundingAssessmentForm == null)
            {
                this.FundingAssessmentStatusName = "Pending DOI Capturer";
            }
            else if (fundingAssessmentForm.IsFormComplete)
            {
                this.FundingAssessmentStatusName = "Assessment Completed";
            }
            else if (fundingAssessmentForm.DOICapturerId > 0 && fundingAssessmentForm.SubmittedCapturerId == null)
            {
                this.FundingAssessmentStatusName = "Pending Assessment Capturer";
            }
            else 
            {
                this.FundingAssessmentStatusName = "Pending Assessment Approver";
            }
        }
    }
}
