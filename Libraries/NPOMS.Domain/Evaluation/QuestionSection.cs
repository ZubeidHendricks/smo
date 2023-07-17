using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("QuestionSections", Schema = "eval")]
	public class QuestionSection : BaseEntity
	{
		public int QuestionCategoryId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		public int SortOrder { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public QuestionCategory QuestionCategory { get; set; }
	}
}
