using Microsoft.Graph;
using NPOMS.Domain.Evaluation;
using System;
using System.Collections.Generic;

namespace NPOMS.Services.Models
{
	public class QuestionResponseViewModel
	{
		public int QuestionCategoryId { get; set; }

		public string QuestionCategoryName { get; set; }

		public int QuestionSectionId { get; set; }

		public string QuestionSectionName { get; set; }

		public int ResponseTypeId { get; set; }

		public int QuestionId { get; set; }

		public string QuestionName { get; set; }

		public int QuestionSortOrder { get; set; }

		public bool HasComment { get; set; }

		public bool CommentRequired { get; set; }

		public bool HasDocument { get; set; }

		public bool DocumentRequired { get; set; }

		public int Weighting { get; set; }

		public int ResponseId => Response == null ? 0 : Response.Id;

		public int ResponseOptionId => Response == null ? 0 : Response.ResponseOptionId;

		public string Comment => Response == null ? string.Empty : Response.Comment;

        public string RejectionComment => Response == null ? string.Empty : Response.RejectionComment;

        public string ReviewerCategoryComment => Response == null ? string.Empty : Response.ReviewerCategoryComment;

        public int RejectionFlag => Response == null ? 0 : Response.RejectionFlag;

        public bool IsSaved => Response != null && Response.Id > 0;

		public int CreatedUserId => Response == null ? 0 : Response.CreatedUserId;

		private Response Response { get; }
		public int SumOfResponse { get; }
		
		public List<int> ResponsesO { get; set; } = new();

        public ResponseOption ResponseOption => Response == null ? new ResponseOption() : Response.ResponseOption;

		public QuestionResponseViewModel(Question question, Response response)
		{
             
			this.QuestionCategoryId = question.QuestionSection.QuestionCategory.Id;
			this.QuestionCategoryName = question.QuestionSection.QuestionCategory.Name;
			this.QuestionSectionId = question.QuestionSection.Id;
			this.QuestionSectionName = question.QuestionSection.Name;
			this.ResponseTypeId = question.ResponseTypeId;
			this.QuestionId = question.Id;
			this.QuestionName = question.Name;
			this.QuestionSortOrder = question.SortOrder;

			this.HasComment = question.QuestionProperty.HasComment;
			this.CommentRequired = question.QuestionProperty.CommentRequired;
			this.HasDocument = question.QuestionProperty.HasDocument;
			this.DocumentRequired = question.QuestionProperty.DocumentRequired;
			this.Weighting = question.QuestionProperty.Weighting;

			this.Response = response;
		}

        public QuestionResponseViewModel(Question question, List<Response> responses, bool v)
        {
			try
			{
                this.QuestionCategoryId = question.QuestionSection.QuestionCategory.Id;
                this.QuestionCategoryName = question.QuestionSection.QuestionCategory.Name;
                this.QuestionSectionId = question.QuestionSection.Id;
                this.QuestionSectionName = question.QuestionSection.Name;
                this.ResponseTypeId = question.ResponseTypeId;
                this.QuestionId = question.Id;
                this.QuestionName = question.Name;
                this.QuestionSortOrder = question.SortOrder;

                this.HasComment = question.QuestionProperty.HasComment;
                this.CommentRequired = question.QuestionProperty.CommentRequired;
                this.HasDocument = question.QuestionProperty.HasDocument;
                this.DocumentRequired = question.QuestionProperty.DocumentRequired;
                this.Weighting = question.QuestionProperty.Weighting;
				
				foreach(var r in responses)
				{
					if(r.QuestionId == question.Id)
					this.ResponsesO.Add(Int32.Parse(r.ResponseOption.Name));
				}

                foreach (var r in responses)
                {
                    if (r.QuestionId == question.Id)
                        this.SumOfResponse += Int32.Parse(r.ResponseOption.Name);
                }

            }
			catch(Exception ex)
			{

			}
            
        }

        public QuestionResponseViewModel(Question question, List<Response> response)
        {
            this.QuestionCategoryId = question.QuestionSection.QuestionCategory.Id;
            this.QuestionCategoryName = question.QuestionSection.QuestionCategory.Name;
            this.QuestionSectionId = question.QuestionSection.Id;
            this.QuestionSectionName = question.QuestionSection.Name;
            this.ResponseTypeId = question.ResponseTypeId;
            this.QuestionId = question.Id;
            this.QuestionName = question.Name;
            this.QuestionSortOrder = question.SortOrder;

            this.HasComment = question.QuestionProperty.HasComment;
            this.CommentRequired = question.QuestionProperty.CommentRequired;
            this.HasDocument = question.QuestionProperty.HasDocument;
            this.DocumentRequired = question.QuestionProperty.DocumentRequired;
            this.Weighting = question.QuestionProperty.Weighting;

            this.Response = response;
        }
    }
}
