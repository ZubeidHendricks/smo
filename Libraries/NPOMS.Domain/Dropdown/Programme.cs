﻿using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
	[Table("Programmes", Schema = "dropdown")]
	public class Programme : BaseEntity
	{
		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(1000)")]
		public string Description { get; set; }

		[Required]
		public int DepartmentId { get; set; }

		public int? DirectorateId { get; set; }

        public string Code { get; set; }

        public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public List<ObjectiveProgramme> SubProgrammes { get; set; } = new List<ObjectiveProgramme>();
	}
}
