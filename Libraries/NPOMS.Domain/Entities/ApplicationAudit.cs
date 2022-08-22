using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ApplicationAudits", Schema = "dbo")]
	public class ApplicationAudit : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int StatusId { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public Status Status { get; set; }

		public User CreatedUser { get; set; }
	}
}
