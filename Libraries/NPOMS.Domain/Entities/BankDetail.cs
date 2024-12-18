﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("BankDetails", Schema = "dbo")]
	public class BankDetail : BaseEntity
	{
		public int NpoProfileId { get; set; }

		public int BankId { get; set; }

		public int BranchId { get; set; }

		public int AccountTypeId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string AccountNumber { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
