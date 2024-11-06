﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Evaluation
{
	[Table("ResponseOptions", Schema = "eval")]
	public class ResponseOption : BaseEntity
	{
		public int ResponseTypeId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string SystemName { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public ResponseType ResponseType { get; set; }
	}
}
