using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Indicator
{
	[Table("WorkplanActualAudits", Schema = "indicator")]
	public class WorkplanActualAudit : BaseEntity
	{
		public int WorkplanActualId { get; set; }

		public int StatusId { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public Status Status { get; set; }

		public User CreatedUser { get; set; }
	}
}
