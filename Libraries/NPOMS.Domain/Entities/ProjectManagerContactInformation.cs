using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ProjectManagerContactInformation", Schema = "dbo")]
	public class ProjectManagerContactInformation : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Surname { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Designation { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Cellphone { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string EmailAddress { get; set; }

		public int TitleId { get; set; }

		public virtual Title Title { get; set; }

		#endregion
	}
}
