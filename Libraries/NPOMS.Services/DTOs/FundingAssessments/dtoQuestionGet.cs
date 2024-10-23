using NPOMS.Domain.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoQuestionGet
    {
        public int Id { get; }
        public string Name { get;  }
        public string QuestionSectionName { get; }

        private List<dtoResponseOptionGet> _responseOptions { get; set; } = new();
        public IReadOnlyList<dtoResponseOptionGet> ResponseOptions => _responseOptions;

        public dtoQuestionGet(Question question, List<ResponseOption> responseOptions )
        {
            this.Id = question.Id;
            this.Name = question.Name;
            this.QuestionSectionName = question.QuestionSection.Name;


            responseOptions.ForEach(responseOption => this._responseOptions.Add(new(responseOption)));
        }

    }
}
