using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.FundingAssessment;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public  class dtoServiceDeliveryAreaGet
    {
        public int Id { get;  }
        public string Name { get; private set; }
        public bool IsSelected { get; private set; } = false;


        public dtoServiceDeliveryAreaGet(ProgrameServiceDeliveryArea programeServiceDeliveryArea, FundingAssessmentForm fundingAssessmentForm)
        {
            this.Id = programeServiceDeliveryArea.Id;
            this.Name = programeServiceDeliveryArea.ServiceDeliveryArea.Name;

            this.IsSelected = fundingAssessmentForm.FundingAssessmentFormSDAs.FirstOrDefault(x=>x.ProgrameServiceDeliveryAreaId == programeServiceDeliveryArea.Id) != null ? true : false;
        }
    }
}
