﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
	[Table("FrequencyPeriods", Schema = "dropdown")]
	public class FrequencyPeriod : BaseEntity
	{
		public int FrequencyId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string SystemName { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}