

using NPOMS.Domain.Entities;
using NPOMS.Domain.Evaluation;
using NPOMS.Domain.FundingAssessment;
using System.Collections.Generic;
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
        public bool IsCompliant => IsCompliantValidation();
        public bool PreSelected { get; private set; }
        public int SelectedAreaCount { get; private set; }
        private FundingAssessmentForm _fundingAssessmentForm { get; }
        private List<ResponseOption> _responseOptions = new List<ResponseOption>();

        public dtoFundingAssessmentApplicationGet(Application application, FundingAssessmentForm fundingAssessmentForm, List<ResponseOption> responseOptions)
        {
            this._fundingAssessmentForm = fundingAssessmentForm;
            this._responseOptions = responseOptions;
           
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

        public bool IsCompliantValidation()
        {
            bool isCompliant = false;

            var notRegisteredResponseIds = _responseOptions.Where(x => x.Name.Contains("1 - Not Registered")).Select(x => x.Id).ToList();
            var notRegisteredValidation = _fundingAssessmentForm?.FundingAssessmentFormResponses.Where(x => notRegisteredResponseIds.Contains(x?.ResponseOptionId ?? 0)).Count() ?? 0;

            if (notRegisteredValidation > 0)
            {
                isCompliant = false;
            } else {
                isCompliant = (_fundingAssessmentForm?.DOICapturerId ?? 0) > 0;
            }


            return isCompliant;

        }
    }
}
