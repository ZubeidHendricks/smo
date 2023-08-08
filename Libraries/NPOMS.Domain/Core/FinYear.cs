using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Core
{
	[Table("FinYears", Schema = "core")]
	public class FinYear : BaseEntity
	{
		#region Properties

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Required]
		public int Year { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		#endregion
	}
}
