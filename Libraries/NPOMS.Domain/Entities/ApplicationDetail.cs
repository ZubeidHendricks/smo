
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
    [Table("ApplicationDetails", Schema = "fa")]
    public class ApplicationDetail : BaseEntity
    {
        public int FundAppSDADetailId { get; set; }
        public FundAppSDADetail FundAppSDADetail { get; set; }
        public decimal AmountApplyingFor { get; set; }

    }
}
