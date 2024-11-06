using Azure;
using NPOMS.Domain.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoResponseOptionGet
    {
        public int Id { get; }
        public string ResponseTypeName { get; }
        public string Name { get; }
        public bool IsSelected { get; } = false;


        public dtoResponseOptionGet(ResponseOption responseOption)
        {
            this.Id = responseOption.Id;
            this.Name = responseOption.Name;
            this.ResponseTypeName = responseOption?.ResponseType?.Name;
           
        }
    }
}
