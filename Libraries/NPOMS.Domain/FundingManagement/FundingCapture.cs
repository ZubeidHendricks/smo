using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.FundingManagement
{
    [Table("FundingCaptures", Schema = "fm")]
    public class FundingCapture : BaseEntity
    {
        [Column(TypeName = "char(15)")]
        public string RefNo { get; set; }

        public int NpoId { get; set; }

        public int? FinancialYearId { get; set; }

        public int StatusId { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public string ApproverComment { get; set; }

        public int? ApproverUserId { get; set; }

        public DateTime? ApprovedDateTime { get; set; }

        public Npo Npo { get; set; }

        public FinancialYear FinancialYear { get; set; }

        public Status Status { get; set; }

        public bool HasAddendum { get; set; }

    }
}
