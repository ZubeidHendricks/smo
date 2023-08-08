using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("Declarations", Schema = "dbo")]
	public class Declaration : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		public int TitleId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Surname { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Cellphone { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string EmailAddress { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Designation { get; set; }

		public bool DeclarationAccepted { get; set; }

		public virtual Title Title { get; set; }
	}
}
