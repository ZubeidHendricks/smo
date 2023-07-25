using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("MunicipalityInformation", Schema = "dbo")]
	public class MunicipalityInformation : BaseEntity
	{
		#region Properties
		public int FundingApplicationId { get; set; }

		public int MunicipalityId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Address { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string CleanAudit { get; set; }

		public virtual Municipality Municipality { get; set; }

		#endregion
	}
}
