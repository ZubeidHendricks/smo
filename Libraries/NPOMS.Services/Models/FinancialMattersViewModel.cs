using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class FinancialMattersViewModel
    {     

        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int SubPropertyId { get; set; }
        public string Property { get; set; }
        public string SubProperty { get; set; }
        public string AmountOne { get; set; }
        public string AmountTwo { get; set; }
        public string AmountThree { get; set; }
        public string TotalFundingAmount { get; set; }
        public int FundingApplicationDetailId { get; set; }
        public string Type { get; set; }
    }
}
