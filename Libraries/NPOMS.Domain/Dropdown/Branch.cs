using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
	[Table("Branches", Schema = "dropdown")]
	public class Branch : BaseEntity
	{
		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string BranchCode { get; set; }

		public int BankId { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
