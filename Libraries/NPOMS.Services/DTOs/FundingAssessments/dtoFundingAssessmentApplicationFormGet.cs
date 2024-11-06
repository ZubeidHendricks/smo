﻿using Azure.Storage.Blobs.Models;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Evaluation;
using NPOMS.Domain.FundingAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoFundingAssessmentApplicationFormGet
    {

        public int? Id { get; }
        public int ApplicationId { get; }
        public string OrganisationName { get; private set; }
        public string CCode { get; private set; }
        public bool DOICaptured { get; }
        public bool DOIApproved { get; }

        public bool CapturerSubmitted { get; }
        public bool ApproverSubmitted { get; }




        public bool ContinueWithAssessment { get; }
        public bool LegislativeComplianceFinalCommentRequired { get; private set; } = false;
        public bool PFMAComplianceAnalysisCommentRequired { get; private set; } = false;
        public bool PerformanceAnalysisCommentRequired { get; private set; } = false;

        private List<dtoFundingAssessmentApplicationFormSummaryItemGet> _summaryItems { get; set; } = new();
        public IReadOnlyList<dtoFundingAssessmentApplicationFormSummaryItemGet> SummaryItems => _summaryItems;



        private List<dtoFundingAssessmentApplicationFormSDAGet> _serviceDeliveries { get; set; } = new();
        public IReadOnlyList<dtoFundingAssessmentApplicationFormSDAGet> ServiceDeliveries => _serviceDeliveries;

        private List<dtoQuestionGet> _questions { get; set; } = new();
        public IReadOnlyList<dtoQuestionGet> Questions => _questions;


        public dtoFundingAssessmentApplicationFormFinalApproverItemGet FinalApprovalItem { get; }


        private List<ResponseOption> _orginalResponseOptions { get; } //only used internally
        private List<Question> _originalQuestions { get; }
        private FundingAssessmentForm _fundingAssessmentForm { get; }
        private List<ServicesRendered> _servicesRendered { get; }
        private List<ProgrammeServiceDelivery> _programServiceDeliveries { get; }
        
        public dtoFundingAssessmentApplicationFormGet(Application application, List<Question> questions, List<ResponseOption> responseOptions, FundingAssessmentForm fundingAssessmentForm, NpoProfile npoProfile, List<ServicesRendered> servicesRendered, List<ProgrammeServiceDelivery> programServiceDeliveries)
        {
            this._orginalResponseOptions = responseOptions;
            this._originalQuestions = questions;
            this._fundingAssessmentForm = fundingAssessmentForm;
            this._servicesRendered = servicesRendered;
            this._programServiceDeliveries = programServiceDeliveries;

            this.Id = fundingAssessmentForm?.Id;
            this.ApplicationId = application.Id;
            this.OrganisationName = npoProfile.Npo.Name;
            this.CCode = npoProfile.Npo.CCode;
            this.DOICaptured = fundingAssessmentForm?.DOICapturerId > 0;
            this.DOIApproved = (fundingAssessmentForm?.DOIApproverId ?? 0) > 0;

            questions.OrderBy(x=>x.SortOrder).ToList().ForEach(question =>
            {
                var filteredResponseOptions = _orginalResponseOptions.Where(x=>x.ResponseTypeId == question.ResponseTypeId).ToList();
                this._questions.Add(new(question, filteredResponseOptions, fundingAssessmentForm?.FundingAssessmentFormResponses.ToList()));
            });

            var approverQuestion = this._originalQuestions.First(x => x.QuestionSection.Name == "Final Approver Section");
            var approverResponseOptions = _orginalResponseOptions.Where(x => x.ResponseTypeId == approverQuestion.ResponseTypeId).ToList();
            this.FinalApprovalItem = new(approverQuestion, approverResponseOptions, fundingAssessmentForm?.FundingAssessmentFormResponses.ToList());

            this.AddServiceDeliveryAreas();

            this.CalcOverallRatingValue();
            this.CalSummaryByQuestionSection();
            this.ContinueWithAssessment = this.onContinueWithAssessment();

        }

        private void CalcOverallRatingValue()
        {
            var overallQuestions = this._questions.Where(x => x.Name.Contains("Overall"));
            foreach (var overallQuestion in overallQuestions)
            {
                var questionsWithRating = this.Questions.Where(x => x.QuestionSectionName == overallQuestion.QuestionSectionName && x.SelectedRatingValue > 0);
                var questionsCount = questionsWithRating.Count();
                var ratingValueSum = questionsWithRating.Sum(x => x.SelectedRatingValue);

                if (questionsCount > 0 && questionsCount > 0)
                {
                    var avg = ratingValueSum.Value / questionsCount;

                    overallQuestion.UpdateOverallValue(avg.ToString());
                }
                else { overallQuestion.UpdateOverallValue(0.ToString()); }
            }
        }

        private void CalSummaryByQuestionSection()
        {
            var questionSections = this._originalQuestions.Select(x => x.QuestionSection.Name).Distinct().ToList();
            foreach (var questionSectionName in questionSections.Where(x =>  x != "Assessment Summary" && x != "Final Approver Section"))
            {
                var responseTypeIds = this._originalQuestions.Where(x => x.QuestionSection.Name == questionSectionName).Select(x => x.ResponseTypeId);
                var ratingOptions = this._orginalResponseOptions.Where(x => responseTypeIds.Contains(x.ResponseTypeId) && x.SystemName == "Rating").ToList();
                var questions = this._questions.Where(x => x.QuestionSectionName == questionSectionName && x.SelectedRatingValue > 0);

                this.CreateSummaryItem(ratingOptions, questionSectionName, questions.Sum(x => x.SelectedRatingValue) ?? 0, questions.Count());
            }

            this.CreateSummaryFinalItem();
        }

        private void CreateSummaryItem(List<ResponseOption> ratingOptions, string questionSectionName, int ratingValue, int count)
        {
            var maxDenominator = 0;
            var minDenominator = 0;
            var score = 0.00M;

            if (ratingValue > 0)
            {
                // Group items by ResponseTypeId
                var groupedOptions = ratingOptions.GroupBy(x => x.ResponseTypeId);

                // Loop through each group
                foreach (var ratingGroup in groupedOptions)
                {

                    maxDenominator += this.GetMax(ratingGroup.ToList());
                    if (!this.HasZero(ratingGroup.ToList()) || ratingValue > 0)
                    {
                        minDenominator += this.GetMax(ratingGroup.ToList());
                    }
                }


                if (maxDenominator == minDenominator)
                {
                    score = (decimal)ratingValue / maxDenominator;
                }
                else
                {
                    score = (decimal)ratingValue / minDenominator;
                }

                score = score * 100;
                score = Math.Round(score, 2);
            }

            var question = _originalQuestions.First(x => x.Name == questionSectionName);
            var filteredResponseOptions = _orginalResponseOptions.Where(x => x.ResponseTypeId == question.ResponseTypeId).ToList();


            this._summaryItems.Add(new(question, score, count==0 ? 0 : ratingValue / count, filteredResponseOptions, _fundingAssessmentForm?.FundingAssessmentFormResponses.ToList()));
        }

        private void CreateSummaryFinalItem()
        {
            var denominator = this._summaryItems.Count;
            var finalScore = this._summaryItems.Sum(x => x.Score);
            var finalRating = this._summaryItems.Sum(x=>x.FinalRating);

            this._summaryItems.Add(new("Final Score", Math.Round(finalScore / denominator, 2), finalRating / denominator));
        }

        private int GetMax(List<ResponseOption> ratingOptions)
        {
            var numbers = ratingOptions.Select(x=>x.Name)
                                .Select(Name => Name.Split('-').FirstOrDefault()?.Trim()) // Get the part before the dash
                                .Where(part => int.TryParse(part, out _)) // Filter out any non-numeric entries
                                .Select(part => int.Parse(part)) // Parse to int
                                .ToList();

            return numbers.Max();
        }

        private bool HasZero(List<ResponseOption> ratingOptions)
        {
            var numbers = ratingOptions.Select(x => x.Name)
                                .Select(Name => Name.Split('-').FirstOrDefault()?.Trim()) // Get the part before the dash
                                .Where(part => int.TryParse(part, out _)) // Filter out any non-numeric entries
                                .Select(part => int.Parse(part)) // Parse to int
                                .ToList();

            return numbers.Min() == 0;
        }

        public bool onContinueWithAssessment()
        {
           // return true;

            var question = this.Questions.FirstOrDefault(x => x.QuestionSectionName == "Legislative Compliance" && x.Name == "Approval");

            if (question == null)
                return false;

            var selectedResponse = question.ResponseOptions.FirstOrDefault(x => x.Id == question.SelectedResponseOptionId);
            if (selectedResponse == null) return false;


            if (selectedResponse.Name.ToLower().Equals("approved"))
            {
                return true;
            }
            else if (selectedResponse.Name.ToLower().Equals("approved with condition") && (question.Comment.Length > 0))
            {
                LegislativeComplianceFinalCommentRequired = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    

        private void AddServiceDeliveryAreas() {

            if (this._programServiceDeliveries.Count() == 0)
                return;

            foreach (var servicesRendered in this._servicesRendered)
            {
                var programServiceDelivery = this._programServiceDeliveries.FirstOrDefault(x => x.SubProgrammeTypeId == servicesRendered.SubProgrammeTypeId && x.SubProgrammeId == servicesRendered.SubProgrammeId);

                if (programServiceDelivery != null)
                { 
                    programServiceDelivery.ServiceDeliveryAreas.ToList().ForEach(x => this._serviceDeliveries.Add(new(x, programServiceDelivery, this._fundingAssessmentForm)));
                }
            
            }

        }
    
    }


}
