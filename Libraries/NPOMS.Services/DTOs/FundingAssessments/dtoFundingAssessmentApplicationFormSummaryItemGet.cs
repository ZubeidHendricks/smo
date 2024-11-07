using NPOMS.Domain.Evaluation;
using NPOMS.Domain.FundingAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public  class dtoFundingAssessmentApplicationFormSummaryItemGet
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Score { get; }
        public int FinalRating { get; }
        public int? SelectedResponseOptionId { get; }

        private List<dtoResponseOptionGet> _responseOptions { get; set; } = new();
        public IReadOnlyList<dtoResponseOptionGet> ResponseOptions => _responseOptions;

        private dtoFundingAssessmentApplicationFormSummaryItemGet()
        {
            
        }

        public dtoFundingAssessmentApplicationFormSummaryItemGet(string name, decimal score, int finalRating)
        {
            this.Id = 0;
            this.Name = name;
            this.Score = score;
            this.FinalRating = finalRating;

        }

        public dtoFundingAssessmentApplicationFormSummaryItemGet(Question question, decimal score, int finalRating, List<ResponseOption> responseOptions, List<FundingAssessmentFormResponse> fundingAssessmentFormResponses)
        {
            this.Id = question.Id;
            this.Name = question.Name;
            this.Score = score; 
            this.FinalRating = finalRating;

            responseOptions.Where(x => x.SystemName == "Option").ToList().ForEach(responseOption => this._responseOptions.Add(new(responseOption)));

            var responseOption = fundingAssessmentFormResponses?.Where(x => x.QuestionId == this.Id && x.ResponseOptionSystemType == "Option").FirstOrDefault();

            if (responseOption != null)
            {
                this.SelectedResponseOptionId = responseOption.ResponseOptionId;
            }
        }
    }
}
