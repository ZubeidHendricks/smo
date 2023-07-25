using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("ResponseHistory", Schema = "eval")]
	public class ResponseHistory : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		public int QuestionId { get; set; }

		public int ResponseOptionId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Comment { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public ResponseOption ResponseOption { get; set; }

		public User CreatedUser { get; set; }
	}
}
