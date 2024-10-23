

using NPOMS.Domain.Entities;

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

        public dtoFundingAssessmentApplicationGet(Application application)
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
            this.FundingAssessmentStatusName = "";
        }
    }
}
