using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("BusinessesSupportedList", Schema = "dbo")]
	public class BusinessesSupportedList : BaseEntity
	{
		public int ProjectDescriptionId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string BusinessName { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string BusinessOwner { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string BusinessAddress { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string ContactNumber { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string EmailAddress { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string CommencementDate { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfEmployees { get; set; }

		public bool IsActive { get; set; }
	}
}
