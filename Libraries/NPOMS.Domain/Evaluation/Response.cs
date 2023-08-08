using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("Responses", Schema = "eval")]
	public class Response : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		public int QuestionId { get; set; }

		public int ResponseOptionId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Comment { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public Question Question { get; set; }

		public ResponseOption ResponseOption { get; set; }
	}
}
