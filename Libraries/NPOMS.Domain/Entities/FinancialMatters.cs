using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
    [Table("FinancialMatters", Schema = "fa")]
    public class FinancialMatters : BaseEntity
    {
        //public int PropertyId { get; set; }
        //public int SubPropertyId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Property { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        //public string SubProperty { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountOne { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountTwo { get; set; }
        [Column(TypeName = "numeric(18,6)")]
        public decimal AmountThree { get; set; }
        public int TotalFundingAmount { get; set; }
        public int? FundingApplicationDetailId { get; set; }
        //public string Type { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool? ChangesRequired { get; set; }
        public bool? IsNew { get; set; }
        public FundingApplicationDetail FundingApplicationDetail { get; set; }
        //public PropertyType PropertyType { get; set; }
        //public PropertySubType PropertySubType { get; set; }
    }
}
