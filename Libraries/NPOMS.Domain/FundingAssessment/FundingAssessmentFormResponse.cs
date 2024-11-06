using NPOMS.Domain.Evaluation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.FundingAssessment
{
    [Table("FundingAssessmentFormResponses", Schema = "fuas")]
    public class FundingAssessmentFormResponse : BaseEntity
    {
        public int FundingAssessmentFormId { get; }
        public string ResponseOptionSystemType { get; }
        public int QuestionId { get; }
        public int? ResponseOptionId { get; private set; }
        public int? RatingValue { get; private set; }
        public string Comment { get; private set; }
        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get;  }

        public int? UpdatedUserId { get; private set; }

        public DateTime? UpdatedDateTime { get; private set; }

        public FundingAssessmentForm FundingAssessmentForm { get;  }

        private FundingAssessmentFormResponse()
        {
            
        }

        public FundingAssessmentFormResponse(int fundingAssessmentFormId, int questionId, string comment, ResponseOption responseOption, int loggedInUserId )
        {
            this.FundingAssessmentFormId = fundingAssessmentFormId;
            this.QuestionId = questionId;
            this.Comment = comment;
            this.ResponseOptionId = responseOption?.Id;
            this.CreatedUserId = loggedInUserId;
            this.CreatedDateTime = DateTime.UtcNow;
            this.ResponseOptionSystemType = responseOption?.SystemName;

            if (responseOption?.SystemName == "Rating")
            {
                this.RatingValue = int.TryParse(responseOption.Name.Split('-').FirstOrDefault()?.Trim(), out int result) ? result : (int?)null;
            }
        }

        public void UpdateResponse(string comment, ResponseOption responseOption, int loggedInUserId)
        {
            this.Comment = comment;
            this.ResponseOptionId = responseOption?.Id;
            this.UpdatedUserId = loggedInUserId;
            this.UpdatedDateTime = DateTime.UtcNow;

            if (responseOption?.SystemName == "Rating")
            {
                this.RatingValue = int.TryParse(responseOption.Name.Split('-').FirstOrDefault()?.Trim(), out int result) ? result : (int?)null;
            }
        }
    }
}
