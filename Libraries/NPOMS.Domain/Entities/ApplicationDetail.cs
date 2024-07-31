
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
    [Table("ApplicationDetails", Schema = "fa")]
    public class ApplicationDetail : BaseEntity
    {
        public int ApplicationId { get; set; }
        public int FundAppSDADetailId { get; set; }
        public FundAppSDADetail FundAppSDADetail { get; set; }
        public decimal AmountApplyingFor { get; set; }
        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

    }
}
