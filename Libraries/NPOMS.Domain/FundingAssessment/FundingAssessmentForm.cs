using NPOMS.Domain.Entities;
using NPOMS.Domain.Mapping;
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
        public int? SubmittedCapturerId { get; private set; }
        public DateTime? SubmittedCapturerDateTime { get; private set; }

        public int? SubmittedApproverId { get; private set; }
        public DateTime? SubmittedApproverDateTime { get; private set; }

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

        public void SubmitForm(int loggedInUserId)
        {
            if (this.SubmittedCapturerId == null)
            {
                this.SubmittedCapturerId = loggedInUserId;
                this.SubmittedCapturerDateTime = DateTime.UtcNow;

                this.UpdatedUserId = loggedInUserId;
                this.UpdatedDateTime = DateTime.UtcNow;
            }
            else
            {
                this.SubmittedApproverId = loggedInUserId;
                this.SubmittedApproverDateTime = DateTime.UtcNow;

                this.UpdatedUserId = loggedInUserId;
                this.UpdatedDateTime = DateTime.UtcNow;
            }
        }

        public void UpsertSDAs(ProgrameServiceDeliveryArea programeServiceDeliveryArea, bool isSelected)
        {
            var psda = _fundingAssessmentFormSDAs.FirstOrDefault(x => x.ProgrameServiceDeliveryAreaId == programeServiceDeliveryArea.Id);
            if (psda == null)
            {
                this._fundingAssessmentFormSDAs.Add(new(this, programeServiceDeliveryArea));
            }
            else {
                psda.SetIsSelected(isSelected);
            }
        }
    }
}
