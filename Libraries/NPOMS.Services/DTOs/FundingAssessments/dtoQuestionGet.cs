﻿using NPOMS.Domain.Evaluation;
using NPOMS.Domain.FundingAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.DTOs.FundingAssessments
{
    public class dtoQuestionGet
    {
        public int Id { get; }
        public string Name { get;  }
        public string QuestionSectionName { get; }
        public bool HasComment { get; }

        public int? SelectedResponseOptionId { get; }
        public int? SelectedResponseRatingId { get; }
        public int? SelectedRatingValue { get; }
        public string Comment { get; private set; }
        public bool IsValid => IsQuestionValidMarkedAsValid();

        private List<dtoResponseOptionGet> _responseOptions { get; set; } = new();
        public IReadOnlyList<dtoResponseOptionGet> ResponseOptions => _responseOptions;

        private List<dtoResponseOptionGet> _responseRatings { get; set; } = new();
        public IReadOnlyList<dtoResponseOptionGet> ResponseRatings => _responseRatings;

        public dtoQuestionGet(Question question, List<ResponseOption> responseOptions, List<FundingAssessmentFormResponse> fundingAssessmentFormResponses)
        {
            this.Id = question.Id;
            this.Name = question.Name;
            this.QuestionSectionName = question.QuestionSection.Name;
            this.HasComment = question.QuestionProperty?.HasComment ?? false;

            responseOptions.Where(x=>x.SystemName == "Option").ToList().ForEach(responseOption => this._responseOptions.Add(new(responseOption)));
            responseOptions.Where(x=>x.SystemName == "Rating").ToList().ForEach(responseOption => this._responseRatings.Add(new(responseOption)));


            var responseOption = fundingAssessmentFormResponses?.Where(x => x.QuestionId == this.Id && x.ResponseOptionSystemType == "Option").FirstOrDefault();
            var responseRating = fundingAssessmentFormResponses?.Where(x => x.QuestionId == this.Id && x.ResponseOptionSystemType == "Rating").FirstOrDefault();
            var responseComment = fundingAssessmentFormResponses?.Where(x => x.QuestionId == this.Id && x.ResponseOptionSystemType == null).FirstOrDefault();

            if (responseOption != null)
            {
                this.SelectedResponseOptionId = responseOption.ResponseOptionId;
            }

            if (responseRating != null)
            {
                this.SelectedResponseRatingId = responseRating.ResponseOptionId;
                this.SelectedRatingValue = responseRating.RatingValue;
            }

            if (responseComment != null)
            {
                this.Comment = responseComment.Comment;
            }

            if (!string.IsNullOrEmpty(responseOption?.Comment))
            {
                this.Comment = responseOption.Comment;
            }
        }

        public void UpdateOverallValue(string value)
        {
            this.Comment = $"{value}";
        }

        private bool IsQuestionValidMarkedAsValid()
        { 
            bool isValid = true;

            if (this._responseOptions.Count > 0)
            {
                isValid = this.SelectedResponseOptionId != null;
            }

            if (isValid && this._responseRatings.Count > 0)
            {
                isValid = this.SelectedResponseRatingId != null;
            }

            if (isValid && this._responseOptions.Count > 0 && this._responseRatings.Count > 0 && this.HasComment)
            {
                isValid = !string.IsNullOrEmpty(this.Comment);
            }

            if (this.Name == "Approver Recommendation" || this.QuestionSectionName == "Assessment Summary") {
                isValid = true;
            }

            return isValid;
        }

    }
}
