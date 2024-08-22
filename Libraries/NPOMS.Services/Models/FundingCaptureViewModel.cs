﻿namespace NPOMS.Services.Models
{
    public class FundingCaptureViewModel
    {
        public int Id { get; set; }
        public string RefNo { get; set; }
        public int NpoId { get; set; }
        public int? FinancialYearId { get; set; }
        public string FinancialYearName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsActive { get; set; }
    }
}
