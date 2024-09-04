using System.Collections.Generic;

namespace NPOMS.Services.Models.FundingManagement
{
    public class NpoViewModel
    {
        public NpoViewModel()
        {
            FundingCaptureViewModels = FundingCaptureViewModels ?? new List<FundingCaptureViewModel>();
        }

        public int Id { get; set; }
        public string RefNo { get; set; }
        public string Name { get; set; }
        public string CCode { get; set; }
        public bool IsActive { get; set; }
        public int NpoProfileId { get; set; }

        public List<FundingCaptureViewModel> FundingCaptureViewModels { get; set; }
    }
}
