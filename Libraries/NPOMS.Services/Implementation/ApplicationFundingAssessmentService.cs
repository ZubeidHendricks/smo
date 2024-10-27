using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository;
using NPOMS.Services.DTOs.FundingAssessments;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class ApplicationFundingAssessmentService : IApplicationFundingAssessmentService
    {
        private RepositoryContext _repositoryContext;

        public ApplicationFundingAssessmentService(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<dtoFundingAssessmentApplicationGet>> GetAllFundingAssessmentApplications(string userIdentifier)
        {
            var result = new List<dtoFundingAssessmentApplicationGet>();
            var applications = await this._repositoryContext.Applications
                                                                    .Include(x=>x.Npo).ThenInclude(x=>x.OrganisationType)
                                                                    .Include(x => x.ApplicationPeriod)
                                                                    .Where(x => x.StatusId == (int)StatusEnum.Approved).ToListAsync();

            applications.ForEach(application =>
            {
                result.Add(new(application));
            });

            return result;
        }

        public async Task<dtoFundingAssessmentApplicationFormGet> GetFundingAssessmentById(int Id, int applicationId) {

            var questions = await this._repositoryContext.Questions
                                            .Include(x=>x.QuestionProperty)
                                            .Include(x=>x.QuestionSection).ThenInclude(x=>x.QuestionCategory)
                                            .Include(x=>x.ResponseType)
                                            .Where(x => x.QuestionSection.QuestionCategory.Name.Equals("Assessment & Evaluation")).
                                            ToListAsync();

            var responseTypeIds = questions.Select(x=>x.ResponseTypeId).ToList();

            var responseOptions = await this._repositoryContext.ResponseOptions.Include(x=>x.ResponseType).Where(x => responseTypeIds.Contains(x.ResponseTypeId)).ToListAsync();

            var application = await this._repositoryContext.Applications
                                                                    .Include(x => x.Npo).ThenInclude(x => x.OrganisationType)
                                                                    .Include(x => x.ApplicationPeriod)
                                                                    .FirstOrDefaultAsync(x => x.Id == applicationId);

            dtoFundingAssessmentApplicationFormGet form = new(application, questions, responseOptions);

            return form;
        }
    }
}
