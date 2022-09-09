using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Indicator
{
	[Table("WorkplanComments", Schema = "indicator")]
	public class WorkplanComment : BaseEntity
	{
		public int WorkplanActualId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(2000)")]
		public string Comment { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public User CreatedUser { get; set; }
	}
}
