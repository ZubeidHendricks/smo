using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("ProjectDescription_SectorGrouping", Schema = "mapping")]
	public class ProjectDescriptionSectorGrouping
	{
		#region Properties

		public int ProjectDescriptionId { get; set; }

		public int SectorGroupingId { get; set; }

		public virtual SectorGrouping SectorGrouping { get; set; }

		#endregion
	}
}
