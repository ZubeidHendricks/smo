using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentApplicationFormFinalApproverItemGet
    {
        public string Name { get; }
        public int? RecommendationOptionId { get; }
        public string RecommendationReason { get; }

        public int SortOrder { get; }

        public bool IsComment { get; }

        private dtoFundingAssessmentApplicationFormFinalApproverItemGet()
        {
            
        }

        public dtoFundingAssessmentApplicationFormFinalApproverItemGet(string name, int recommendationOptionId, string recommendationReason, int sortOrder, bool isComment)
        {
            this.Name = name;
            this.RecommendationOptionId = recommendationOptionId;
            this.RecommendationReason = recommendationReason;
            this.SortOrder = sortOrder;
            this.IsComment = isComment;
        }
    }
}
