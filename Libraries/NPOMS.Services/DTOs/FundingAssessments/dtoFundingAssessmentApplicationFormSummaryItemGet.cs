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
        public decimal FinalRating { get; }
        public int? IsApproved { get; }

        private dtoFundingAssessmentApplicationFormSummaryItemGet()
        {
            
        }

        public dtoFundingAssessmentApplicationFormSummaryItemGet(string name)
        {
            this.Name = name;
        }
    }
}
