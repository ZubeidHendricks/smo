using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("SubRecipients", Schema = "dbo")]
	public class SubRecipient : BaseEntity
	{
		public int ObjectiveId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string OrganisationName { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string FundingPeriodStartDate { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string FundingPeriodEndDate { get; set; }

		[Column(TypeName = "numeric(18,6)")]
		public decimal Budget { get; set; }

		public int RecipientTypeId { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public List<SubSubRecipient> SubSubRecipients { get; set; } = new List<SubSubRecipient>();
	}
}
