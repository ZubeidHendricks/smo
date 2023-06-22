using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
    [Table("FinancialMattersExpenditure", Schema = "fa")]
    public class FinancialMattersExpenditure : BaseEntity
    {
        public int? npoProfileId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string ExpenditureDescription { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountOneE { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountTwoE { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountThreeE { get; set; }
        public int TotalFundingAmountE { get; set; }
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
