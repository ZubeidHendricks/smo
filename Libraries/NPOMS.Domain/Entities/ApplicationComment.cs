using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ApplicationComments", Schema = "dbo")]
	public class ApplicationComment : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int ServiceProvisionStepId { get; set; }

		public int EntityId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(2000)")]
		public string Comment { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public virtual User CreatedUser { get; set; }
	}
}
