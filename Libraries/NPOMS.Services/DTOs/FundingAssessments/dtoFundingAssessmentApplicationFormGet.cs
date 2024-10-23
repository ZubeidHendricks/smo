using Azure.Storage.Blobs.Models;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentApplicationFormGet
    {

        public int Id { get; }
        public int ApplicationId { get; }
        public string OrganisationName { get; private set; }

        private List<dtoServiceDeliveryAreaGet> _serviceDeliveries { get; set; } = new();
        public IReadOnlyList<dtoServiceDeliveryAreaGet> ServiceDeliveries => _serviceDeliveries;

        private List<dtoQuestionGet> _questions { get; set; } = new();
        public IReadOnlyList<dtoQuestionGet> Questions => _questions;

        public dtoFundingAssessmentApplicationFormGet(Application application, List<Question> questions, List<ResponseOption> responseOptions)
        {
            this.Id = 0;
            this.ApplicationId = application.Id;
            this.OrganisationName = application.Npo.Name;

            questions.ForEach(question =>
            {
                var filteredResponseOptions = responseOptions.Where(x=>x.ResponseTypeId == question.ResponseTypeId).ToList();
                this._questions.Add(new(question, filteredResponseOptions));
            });
        }
    }
}
