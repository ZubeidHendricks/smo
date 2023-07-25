using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("DocumentChecklists", Schema = "dbo")]
	public class DocumentChecklist : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		public int DocumentChecklistTypeId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Selection { get; set; }

		public virtual DocumentChecklistType DocumentChecklistType { get; set; }
	}
}
