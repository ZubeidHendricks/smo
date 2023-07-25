using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("FoundationalEnergyStudy_ImplementationTimeline", Schema = "mapping")]
	public class FoundationalEnergyStudyTimeline : BaseEntity
	{
		public int ImplementationTimelineId { get; set; }

		public int FoundationalEnergyStudyId { get; set; }
	}
}
