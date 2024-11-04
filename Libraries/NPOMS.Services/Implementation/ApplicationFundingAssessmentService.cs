﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Evaluation;
using NPOMS.Domain.FundingAssessment;
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
            var currentDate = DateTime.Now;
            var previousFinancialYear = this._repositoryContext.FinancialYears
                .Where(x => x.EndDate < currentDate) // Ensures only past financial years are considered
                .OrderByDescending(x => x.StartDate)
                .FirstOrDefault();

            var result = new List<dtoFundingAssessmentApplicationGet>();
            var applications = await this._repositoryContext.Applications
                                                                    .Include(x=>x.Npo).ThenInclude(x=>x.OrganisationType)
                                                                    .Include(x => x.ApplicationPeriod)
                                                                    .Where(x => x.StatusId == (int)StatusEnum.Approved ).ToListAsync();

            var fundingAssessmentForms = await this._repositoryContext.FundingAssessmentForms.ToListAsync();
 

            applications.ForEach(application =>
            {
                var fundingAssessmentForm = fundingAssessmentForms.FirstOrDefault(x=>x.ApplicationId == application.Id);
                result.Add(new(application, fundingAssessmentForm));
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

            var fundingAssessmentForm = await this._repositoryContext.FundingAssessmentForms
                                        .Include(x => x.FundingAssessmentFormResponses)
                                        .FirstOrDefaultAsync(x=>x.ApplicationId == applicationId);

            var responseTypeIds = questions.Select(x=>x.ResponseTypeId).ToList();

            var responseOptions = await this._repositoryContext.ResponseOptions.Include(x=>x.ResponseType).Where(x => responseTypeIds.Contains(x.ResponseTypeId)).ToListAsync();

            var application = await this._repositoryContext.Applications
                                                                    .Include(x => x.Npo).ThenInclude(x => x.OrganisationType)
                                                                    .Include(x => x.ApplicationPeriod)
                                                                    .FirstOrDefaultAsync(x => x.Id == applicationId);

            dtoFundingAssessmentApplicationFormGet form = new(application, questions, responseOptions, fundingAssessmentForm);

            return form;
        }


        public async Task ConfirmDOICapturer(int applicationId, string loggedInUsername)
        {
            var loggedInUser = await this._repositoryContext.Users.Where(x=>x.UserName == loggedInUsername).FirstOrDefaultAsync();
            var fundingAssessmentForm = await this._repositoryContext.FundingAssessmentForms
                                   .FirstOrDefaultAsync(x => x.ApplicationId == applicationId);

            if (fundingAssessmentForm == null)
            {
                FundingAssessmentForm form = new FundingAssessmentForm(applicationId, loggedInUser.Id);
                this._repositoryContext.FundingAssessmentForms.Add(form);
                await this._repositoryContext.SaveChangesAsync();
            }
        }

        public async Task UpsertQuestionResponse(dtoFundingAssessmentFormQuestionResponseUpsert dto, string loggedInUsername)
        {
            var loggedInUser = await this._repositoryContext.Users.Where(x => x.UserName == loggedInUsername).FirstOrDefaultAsync();
            
            var fundingAssessmentFormResponses = await this._repositoryContext.FundingAssessmentFormResponses
                                        .Where(x => x.FundingAssessmentFormId == dto.AssessmentApplicationFormId && x.QuestionId == dto.Id)
                                        .ToListAsync();


            if (dto.SelectedResponseOptionId > 0)
            {
                var existingFundingAssessmentFormResponse = fundingAssessmentFormResponses.FirstOrDefault(x => x.ResponseOptionSystemType == "Option");
                var responseOption = await this._repositoryContext.ResponseOptions
                                                .FirstOrDefaultAsync(x => x.Id == dto.SelectedResponseOptionId);

                if (existingFundingAssessmentFormResponse == null)
                {
                    FundingAssessmentFormResponse newFundingAssessmentFormResponse = new(dto.AssessmentApplicationFormId, dto.Id, dto.Comment, responseOption, loggedInUser.Id);
                    this._repositoryContext.FundingAssessmentFormResponses.Add(newFundingAssessmentFormResponse);
                }
                else {
                    existingFundingAssessmentFormResponse.UpdateResponse(dto.Comment, responseOption, loggedInUser.Id);
                }
            }

            if (dto.SelectedResponseRatingId > 0)
            {
                var existingFundingAssessmentFormResponse = fundingAssessmentFormResponses.FirstOrDefault(x => x.ResponseOptionSystemType == "Rating");
                var responseOption = await this._repositoryContext.ResponseOptions
                                                .FirstOrDefaultAsync(x => x.Id == dto.SelectedResponseRatingId);

                if (existingFundingAssessmentFormResponse == null)
                {
                    FundingAssessmentFormResponse newFundingAssessmentFormResponse = new(dto.AssessmentApplicationFormId, dto.Id, dto.Comment, responseOption, loggedInUser.Id);
                    this._repositoryContext.FundingAssessmentFormResponses.Add(newFundingAssessmentFormResponse);
                }
                else
                {
                    existingFundingAssessmentFormResponse.UpdateResponse(dto.Comment, responseOption, loggedInUser.Id);
                }
            }

            if (dto.SelectedResponseOptionId == null && dto.SelectedResponseRatingId == null ) {
                var existingFundingAssessmentFormResponse = fundingAssessmentFormResponses.FirstOrDefault(x => x.ResponseOptionSystemType == null);

                if (existingFundingAssessmentFormResponse == null)
                {
                    FundingAssessmentFormResponse newFundingAssessmentFormResponse = new(dto.AssessmentApplicationFormId, dto.Id, dto.Comment, null, loggedInUser.Id);
                    this._repositoryContext.FundingAssessmentFormResponses.Add(newFundingAssessmentFormResponse);
                }
                else
                {
                    existingFundingAssessmentFormResponse.UpdateResponse(dto.Comment, null, loggedInUser.Id);
                }
            }

            await this._repositoryContext.SaveChangesAsync();
        }
    }
}
