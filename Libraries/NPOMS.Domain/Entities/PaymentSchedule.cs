using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("PaymentSchedules", Schema = "dbo")]
	public class PaymentSchedule : BaseEntity
	{
		public int CompliantCycleId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime ReleaseDate { get; set; }

		public DateTime PaymentDate { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public CompliantCycle CompliantCycle { get; set; }
	}
}
