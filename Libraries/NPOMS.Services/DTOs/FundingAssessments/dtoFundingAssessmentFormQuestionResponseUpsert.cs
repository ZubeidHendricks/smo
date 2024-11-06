using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentFormQuestionResponseUpsert
    {

        public int Id { get; set; }
        public int AssessmentApplicationFormId { get; set; }
        public int? SelectedResponseOptionId { get; set; }
        public int? SelectedResponseRatingId { get; set; }
        public string Comment { get; set; }
    }
}
