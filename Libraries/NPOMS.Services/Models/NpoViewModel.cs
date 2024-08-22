using System.Collections.Generic;

namespace NPOMS.Services.Models
{
    public class NpoViewModel
    {
        public NpoViewModel()
        {
            this.FundingCaptureViewModels = this.FundingCaptureViewModels ?? new List<FundingCaptureViewModel>();
        }

        public int Id { get; set; }
        public string RefNo { get; set; }
        public string Name { get; set; }
        public string CCode { get; set; }
        public bool IsActive { get; set; }

        public List<FundingCaptureViewModel> FundingCaptureViewModels { get; set; }
    }
}
