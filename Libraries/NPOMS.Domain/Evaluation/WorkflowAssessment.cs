using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("WorkflowAssessments", Schema = "eval")]
	public class WorkflowAssessment : BaseEntity
	{
		public int QuestionCategoryId { get; set; }

		public int NumberOfAssessments { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
