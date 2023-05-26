using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class ApplicationDetailViewModel
    {
        public int Id { get; set; }
        public int FundAppSDADetailId { get; set; }
        public FundAppSDADetailViewModel FundAppSDADetail { get; set; }
        public decimal AmountApplyingFor { get; set; }
    }
}
