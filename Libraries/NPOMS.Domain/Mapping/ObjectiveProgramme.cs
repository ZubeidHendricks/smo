using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Objectives_Programmes", Schema = "mapping")]
	public class ObjectiveProgramme	
	{
		public int ObjectiveId { get; set; }

		public int ProgrammeId { get; set; }

		public int SubProgrammeId { get; set; }

		public virtual Programme Programme { get; set; }

		public virtual SubProgramme SubProgramme { get; set; }
	}
}
