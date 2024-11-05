using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.FundingAssessment
{
    [Table("FundingAssessmentFormSDAs", Schema = "fuas")]
    public class FundingAssessmentFormSDA : BaseEntity
    {

        public int FundingAssessmentFormId { get; }
        public int ProgrameServiceDeliveryAreaId { get; }
        public bool IsSelected { get; private set; }

        public FundingAssessmentForm FundingAssessmentForm { get; }

        private FundingAssessmentFormSDA()
        {
            
        }

        public FundingAssessmentFormSDA(FundingAssessmentForm fundingAssessmentForm, ProgrameServiceDeliveryArea programeServiceDeliveryArea)
        {
            this.FundingAssessmentFormId = fundingAssessmentForm.Id;
            this.ProgrameServiceDeliveryAreaId = programeServiceDeliveryArea.Id;
            this.IsSelected = true;
        }

        public void SetIsSelected( bool isSelected)
        { 
            this.IsSelected = isSelected;
        }
    }
}
