using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ApplicationApprovals", Schema = "dbo")]
	public class ApplicationApproval : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int StatusId { get; set; }

		public string ApprovedFrom { get; set; }

		public bool isActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public virtual User CreatedUser { get; set; }
	}
}
