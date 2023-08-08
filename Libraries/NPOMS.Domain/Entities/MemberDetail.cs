using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("MemberDetails", Schema = "dbo")]
	public class MemberDetail : BaseEntity
	{
		#region Properties

		public int OrganisationalProfileId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Surname { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string ContactNumber { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string EmailAddress { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Role { get; set; }

		public bool IsActive { get; set; }

		#endregion
	}
}
