using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
	[Table("SustainabilityPlans", Schema = "dbo")]
	public class SustainabilityPlan : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int ActivityId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Description { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string Risk { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string Mitigation { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public bool? ChangesRequired { get; set; }

		public bool? IsNew { get; set; }

		public Activity Activity { get; set; }
	}
}
