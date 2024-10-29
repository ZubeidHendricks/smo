using Azure.Storage.Blobs.Models;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Evaluation;
using NPOMS.Domain.FundingAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentApplicationFormGet
    {

        public int? Id { get; }
        public int ApplicationId { get; }
        public string OrganisationName { get; private set; }
        public bool DOICaptured { get; }
        public bool DOIApproved { get; }

        private List<dtoFundingAssessmentApplicationFormSummaryItemGet> _summaryItems { get; set; } = new();
        public IReadOnlyList<dtoFundingAssessmentApplicationFormSummaryItemGet> SummaryItems => _summaryItems;

        

        private List<dtoServiceDeliveryAreaGet> _serviceDeliveries { get; set; } = new();
        public IReadOnlyList<dtoServiceDeliveryAreaGet> ServiceDeliveries => _serviceDeliveries;

        private List<dtoQuestionGet> _questions { get; set; } = new();
        public IReadOnlyList<dtoQuestionGet> Questions => _questions;

        private List<dtoFundingAssessmentApplicationFormFinalApproverItemGet> _finalApprovalItems { get; set; } = new();
        public IReadOnlyList<dtoFundingAssessmentApplicationFormFinalApproverItemGet> FinalApprovalItems => _finalApprovalItems;

        public dtoFundingAssessmentApplicationFormGet(Application application, List<Question> questions, List<ResponseOption> responseOptions, FundingAssessmentForm fundingAssessmentForm)
        {
            this.Id = fundingAssessmentForm?.Id;
            this.ApplicationId = application.Id;
            this.OrganisationName = application.Npo.Name;
            this.DOICaptured = fundingAssessmentForm?.DOICapturerId > 0;
            this.DOIApproved = (fundingAssessmentForm?.DOIApproverId ?? 0) > 0;

            questions.OrderBy(x=>x.SortOrder).ToList().ForEach(question =>
            {
                var filteredResponseOptions = responseOptions.Where(x=>x.ResponseTypeId == question.ResponseTypeId).ToList();
                this._questions.Add(new(question, filteredResponseOptions, fundingAssessmentForm?.FundingAssessmentFormResponses.ToList()));
            });

            var questionSections = questions.Select(x => x.QuestionSection.Name).Distinct().ToList();

            foreach (var questionSection in questionSections)
            {
                this._summaryItems.Add(new(questionSection));
            }
            this._summaryItems.Add(new("Final Score"));


            this._finalApprovalItems.Add(new("Recommendation", 1, "", 1, false));
            this._finalApprovalItems.Add(new("Recommendation Reason", 0, "", 2, true));

        }
    }
}
