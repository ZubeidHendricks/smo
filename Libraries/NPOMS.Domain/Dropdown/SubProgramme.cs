using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
	[Table("SubProgrammes", Schema = "dropdown")]
	public class SubProgramme : BaseEntity
	{
		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(1000)")]
		public string Description { get; set; }

		[Required]
		public int ProgrammeId { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public List<ObjectiveProgramme> Programmes { get; set; } = new List<ObjectiveProgramme>();
	}
}
