﻿using Azure.Storage.Blobs.Models;
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
    public class dtoFundingAssessmentApplicationFormSDAGet
    {
        public int Id { get; private set; }
        public int ProgramServiceDeliveryAreaId { get; private set; }
        public string RegionName { get; private set; }
        public string DistrictCouncilName { get; private set; }
        public string LocalMunicipalityName { get; private set;  }

        public string ServiceDeliveryAreaName { get; set; }

        public bool IsSelected { get; private set;  }

        private dtoFundingAssessmentApplicationFormSDAGet()
        {
            
        }
        public dtoFundingAssessmentApplicationFormSDAGet(ProgrameServiceDeliveryArea programeServiceDeliveryArea, FundingAssessmentForm fundingAssessmentForm  )
        {
            var psda = fundingAssessmentForm.FundingAssessmentFormSDAs.FirstOrDefault(x => x.ProgrameServiceDeliveryAreaId == programeServiceDeliveryArea.Id);

            this.Id = psda != null ? psda.Id : 0;

            this.ProgramServiceDeliveryAreaId = programeServiceDeliveryArea.Id;
            this.RegionName = programeServiceDeliveryArea.ProgrameServiceDelivery?.Regions.FirstOrDefault()?.Region.Name;
            this.DistrictCouncilName = programeServiceDeliveryArea.ProgrameServiceDelivery?.DistrictCouncil.Name;
            this.LocalMunicipalityName = programeServiceDeliveryArea.ProgrameServiceDelivery?.LocalMunicipality.Name;
            this.ServiceDeliveryAreaName = programeServiceDeliveryArea.ServiceDeliveryArea.Name;

            this.IsSelected = psda?.IsSelected ?? false;
        }
    }
}
