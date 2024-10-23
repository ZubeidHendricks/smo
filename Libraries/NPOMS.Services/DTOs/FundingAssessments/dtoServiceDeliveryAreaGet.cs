using NPOMS.Domain.Dropdown;
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


        public dtoServiceDeliveryAreaGet(ServiceDeliveryArea serviceDeliveryArea)
        {
            this.Id = serviceDeliveryArea.Id;
            this.Name = serviceDeliveryArea.Name;
        }
    }
}
