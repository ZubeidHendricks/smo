using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
	[Table("SuccessStoryTypes", Schema = "dropdown")]
	public class SuccessStoryType : BaseEntity
	{
		#region Properties

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string SystemName { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string Description { get; set; }

		public int NumberOfStories { get; set; }

		public int ApplicationCategoryId { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		#endregion
	}
}
