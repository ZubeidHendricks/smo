using NPOMS.Services.DTOs.FundingAssessments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IApplicationFundingAssessmentService
    {
       Task<IEnumerable<dtoFundingAssessmentApplicationGet>> GetAllFundingAssessmentApplications(string userIdentifier);
        Task<dtoFundingAssessmentApplicationFormGet> GetFundingAssessmentById(int Id, int applicationId);
        Task ConfirmDOICapturer(int applicationId, string loggedInUsername);
        Task ConfirmDOIApprover(int applicationId, string loggedInUsername);
        Task SubmitForm(int applicationId, string loggedInUsername);
        Task EndAssessmentForm(int applicationId, string loggedInUsername);
        Task UpsertQuestionResponse(dtoFundingAssessmentFormQuestionResponseUpsert dto, string loggedInUsername);
        Task FundingAssessmentApplicationFormSDAUpsert(int fundingAssessmentFormId, dtoFundingAssessmentApplicationFormSDAUpsert dto, string loggedInUsername);
    }
}
