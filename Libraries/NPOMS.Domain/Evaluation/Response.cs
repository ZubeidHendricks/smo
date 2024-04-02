using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
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

        [Column(TypeName = "nvarchar(MAX)")]
        public string RejectionComment { get; set; }
        public int RejectionFlag { get; set; }

        public int RejectedByUserId { get; set; }

        public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public Question Question { get; set; }

		public ResponseOption ResponseOption { get; set; }
        public User CreatedUser { get; set; }

		public static implicit operator Response(List<Response> v)
		{
			throw new NotImplementedException();
		}
	}
}
