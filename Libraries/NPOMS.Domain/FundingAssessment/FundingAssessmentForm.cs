using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.FundingAssessment
{
    [Table("FundingAssessmentForms", Schema = "fuas")]
    public class FundingAssessmentForm : BaseEntity
    {

        public int ApplicationId { get; }

        public int DOICapturerId { get; }
        public DateTime  DOICapturedDateTime { get;  }
        public int? DOIApproverId { get; private set; }
        public DateTime? DOIApprovedDateTime { get; private set; }

        public int CreatedUserId { get;  }

        public DateTime CreatedDateTime { get;  }

        public int? UpdatedUserId { get; private set; }

        public DateTime? UpdatedDateTime { get; private set; }


        private List<FundingAssessmentFormResponse> _responses { get; set; } = new();
        public IReadOnlyList<FundingAssessmentFormResponse> FundingAssessmentFormResponses => _responses;

        private List<FundingAssessmentFormSDA> _fundingAssessmentFormSDAs { get; set; } = new();
        public IReadOnlyList<FundingAssessmentFormSDA> FundingAssessmentFormSDAs => _fundingAssessmentFormSDAs;


        public Application Application { get; }
        private FundingAssessmentForm()
        {

        }

        public FundingAssessmentForm(int applicationId, int loggedUserId)
        {
            this.ApplicationId = applicationId;
            this.CreatedUserId = loggedUserId;
            this.CreatedDateTime = DateTime.UtcNow;
            this.DOICapturerId = loggedUserId;
            this.DOICapturedDateTime = DateTime.UtcNow; 
        }

        public void SetDOIApprover(int loggedInUserId)
        { 
            this.DOIApproverId = loggedInUserId;
            this.DOIApprovedDateTime = DateTime.UtcNow;

            this.UpdatedUserId = loggedInUserId;
            this.UpdatedDateTime    = DateTime.UtcNow;
        }
    }
}
