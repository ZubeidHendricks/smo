﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
	[Table("FacilityClasses", Schema = "dropdown")]
	public class FacilityClass : BaseEntity
	{
		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
