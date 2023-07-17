using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("Questions", Schema = "eval")]
	public class Question : BaseEntity
	{
		public int QuestionSectionId { get; set; }

		public int ResponseTypeId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(MAX)")]
		public string Name { get; set; }

		public int SortOrder { get; set; }
		
		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public QuestionSection QuestionSection { get; set; }

		public ResponseType ResponseType { get; set; }

		public QuestionProperty QuestionProperty { get; set; }
	}
}
