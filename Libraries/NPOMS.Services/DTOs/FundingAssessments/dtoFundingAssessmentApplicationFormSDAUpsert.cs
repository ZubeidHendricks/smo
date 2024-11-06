using Azure.Storage.Blobs.Models;
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
    public class dtoFundingAssessmentApplicationFormSDAUpsert
    {
        public int Id { get; set; }
        public int FundingAssessmentFormId { get; set; }
        public int ProgramServiceDeliveryAreaId { get; set; }
        public bool IsSelected { get; set;  }
    }
}
