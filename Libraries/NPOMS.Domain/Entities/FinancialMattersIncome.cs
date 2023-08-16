using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
    [Table("FinancialMattersIncome", Schema = "fa")]
    public class FinancialMattersIncome : BaseEntity
    {
        public int npoProfileId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string IncomeDescription { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountOneI { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountTwoI { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountThreeI { get; set; }
        public int TotalFundingAmountI { get; set; }
        public int? FundingApplicationDetailId { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public FundingApplicationDetail FundingApplicationDetail { get; set; }

    }
}
