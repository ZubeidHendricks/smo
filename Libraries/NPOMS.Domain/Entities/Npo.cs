﻿using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("Npos", Schema = "dbo")]
	public class Npo : BaseEntity
	{
		[Column(TypeName = "char(15)")]
		public string RefNo { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		public int OrganisationTypeId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string RegistrationNumber { get; set; }

		[Column(TypeName = "nvarchar(10)")]
		public string YearRegistered { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Website { get; set; }

		public bool IsNew { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public int ApprovalStatusId { get; set; }

		public int? ApprovalUserId { get; set; }

		public DateTime? ApprovalDateTime { get; set; }

		public virtual OrganisationType OrganisationType { get; set; }

		public virtual List<ContactInformation> ContactInformation { get; set; } = new List<ContactInformation>();

		public virtual User CreatedUser { get; set; }

		public virtual AccessStatus ApprovalStatus { get; set; }

		public virtual User ApprovalUser { get; set; }
	}
}
