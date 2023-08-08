using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("MunicipalResourceContributions", Schema = "dbo")]
	public class MunicipalResourceContribution : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		public int MunicipalResourceId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(MAX)")]
		public string Current { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(MAX)")]
		public string Planned { get; set; }

		public bool IsActive { get; set; }

		public virtual MunicipalResource MunicipalResource { get; set; }
	}
}
