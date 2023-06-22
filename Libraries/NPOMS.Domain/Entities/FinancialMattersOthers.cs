using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
    [Table("FinancialMattersOthers", Schema = "fa")]
    public class FinancialMattersOthers : BaseEntity
    {

        public int? npoProfileId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string OtherDescription { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountOneO { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountTwoO { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountThreeO { get; set; }
        public int TotalFundingAmountO { get; set; }
        public int? FundingApplicationDetailId { get; set; }
        public string Type { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public FundingApplicationDetail FundingApplicationDetail { get; set; }

    }
}
