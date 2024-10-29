using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public  class dtoFundingAssessmentApplicationFormSummaryItemGet
    {
        public string Name { get; }
        public decimal Score { get; }
        public int FinalRating { get; }
        public int? IsApproved { get; }

        private dtoFundingAssessmentApplicationFormSummaryItemGet()
        {
            
        }

        public dtoFundingAssessmentApplicationFormSummaryItemGet(string name, decimal score, int finalRating)
        {
            this.Name = name;
            this.Score = score; 
            this.FinalRating = finalRating;
        }
    }
}
