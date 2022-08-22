using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Activities_SubProgrammes", Schema = "mapping")]
	public class ActivitySubProgramme : BaseEntity
	{
		public int ActivityId { get; set; }

		public int SubProgrammeId { get; set; }

		public bool IsActive { get; set; }

		//public Activity Activity { get; set; }

		public SubProgramme SubProgramme { get; set; }
	}
}
