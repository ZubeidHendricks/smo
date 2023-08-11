using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("Objectives", Schema = "dbo")]
	public class Objective : BaseEntity
	{
		public int ApplicationId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Description { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string FundingSource { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string FundingPeriodStartDate { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string FundingPeriodEndDate { get; set; }

		public int RecipientTypeId { get; set; }

		[Column(TypeName = "numeric(18,6)")]
		public decimal Budget { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public bool? ChangesRequired { get; set; }

		public bool? IsNew { get; set; }

		public RecipientType RecipientType { get; set; }

		public List<ObjectiveProgramme> ObjectiveProgrammes { get; set; } = new List<ObjectiveProgramme>();
	}
}
