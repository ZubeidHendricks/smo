using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ContactInformation", Schema = "dbo")]
	public class ContactInformation : BaseEntity
	{
		public int NpoId { get; set; }

		public int TitleId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string FirstName { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string LastName { get; set; }

		public bool RSAIdNumber { get; set; }

		[Column(TypeName = "nvarchar(13)")]
		public string IdNumber { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string PassportNumber { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string EmailAddress { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Telephone { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Cellphone { get; set; }

		public int PositionId { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string Comments { get; set; }

		public bool IsPrimaryContact { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public virtual Title Title { get; set; }

		public virtual Position Position { get; set; }
	}
}
