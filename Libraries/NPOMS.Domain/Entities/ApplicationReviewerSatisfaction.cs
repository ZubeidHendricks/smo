using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ApplicationReviewerSatisfactions", Schema = "dbo")]
	public class ApplicationReviewerSatisfaction : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int ServiceProvisionStepId { get; set; }

		public int EntityId { get; set; }

		public bool IsSatisfied { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public User CreatedUser { get; set; }
	}
}
