using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ServicesRendered", Schema = "dbo")]
	public class ServicesRendered : BaseEntity
	{
		public int NpoProfileId { get; set; }

		public int ProgrammeId { get; set; }

		public int SubProgrammeId { get; set; }

		public int SubProgrammeTypeId { get; set; }

		public bool IsActive { get; set; }
	}
}
