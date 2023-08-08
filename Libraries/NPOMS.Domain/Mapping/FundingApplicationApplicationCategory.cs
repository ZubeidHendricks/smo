using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("FundingApplication_ApplicationCategory", Schema = "mapping")]
	public class FundingApplicationApplicationCategory : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		public int ApplicationCategoryId { get; set; }

		public virtual ApplicationCategory ApplicationCategory { get; set; }
	}
}
