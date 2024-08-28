using NPOMS.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.FundingManagement
{
    [Table("BankDetails", Schema = "fm")]
    public class BankDetail : BaseEntity
    {
        public int FundingCaptureId { get; set; }

        public int? ProgramBankDetailsId { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public FundingCapture FundingCapture { get; set; }

        public ProgramBankDetails ProgramBankDetails { get; set; }
    }
}
