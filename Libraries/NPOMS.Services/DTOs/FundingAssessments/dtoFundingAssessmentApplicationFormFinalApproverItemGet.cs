using NPOMS.Domain.Evaluation;
using NPOMS.Domain.FundingAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentApplicationFormFinalApproverItemGet
    {
        public int Id { get; }
        public string Name { get; }
        public int? SelectedResponseOptionId { get; }
        public string Comment { get; private set; }
        private List<dtoResponseOptionGet> _responseOptions { get; set; } = new();
        public IReadOnlyList<dtoResponseOptionGet> ResponseOptions => _responseOptions;

        private dtoFundingAssessmentApplicationFormFinalApproverItemGet()
        {
            
        }

        public dtoFundingAssessmentApplicationFormFinalApproverItemGet(Question question, List<ResponseOption> responseOptions, List<FundingAssessmentFormResponse> fundingAssessmentFormResponses)
        {
            this.Id = question.Id;
            this.Name = question.Name;

            responseOptions.Where(x => x.SystemName == "Option").ToList().ForEach(responseOption => this._responseOptions.Add(new(responseOption)));

            var responseOption = fundingAssessmentFormResponses?.Where(x => x.QuestionId == this.Id && x.ResponseOptionSystemType == "Option").FirstOrDefault();

            if (responseOption != null)
            {
                this.SelectedResponseOptionId = responseOption.ResponseOptionId;
                this.Comment = responseOption.Comment;
            }
        }
    }
}
