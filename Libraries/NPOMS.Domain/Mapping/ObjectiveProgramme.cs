using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Objectives_Programmes", Schema = "mapping")]
	public class ObjectiveProgramme	
	{
		public int ObjectiveId { get; set; }

		public int ProgrammeId { get; set; }

		public int SubProgrammeId { get; set; }

		public Objective Objective { get; set; }

	//	public Programme Programme { get; set; }

		public SubProgramme SubProgramme { get; set; }
	}
}
