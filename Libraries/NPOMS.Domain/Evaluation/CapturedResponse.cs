using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("CapturedResponses", Schema = "eval")]
	public class CapturedResponse : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		public int QuestionCategoryId { get; set; }

		public int StatusId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Comments { get; set; }

		public bool IsActive { get; set; }
		public bool IsSignedOff { get; set; }
		public bool isDeclarationAccepted { get; set; }

        public string selectedStatus { get; set; }

        public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public User CreatedUser { get; set; }
	}
}
