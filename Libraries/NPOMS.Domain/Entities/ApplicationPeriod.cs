using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ApplicationPeriods", Schema = "dbo")]
	public class ApplicationPeriod : BaseEntity
	{
		[Column(TypeName = "char(15)")]
		public string RefNo { get; set; }

		public int DepartmentId { get; set; }

		public int ProgrammeId { get; set; }

		public int SubProgrammeId { get; set; }
		public int? SubProgrammeTypeId { get; set; }	

        public int ApplicationTypeId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(500)")]
		public string Description { get; set; }

		public int FinancialYearId { get; set; }

		public DateTime OpeningDate { get; set; }

		public DateTime ClosingDate { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public Department Department { get; set; }

		public Programme Programme { get; set; }

		public SubProgramme SubProgramme { get; set; }

		public SubProgrammeType SubProgrammeType { get; set; }

		public FinancialYear FinancialYear { get; set; }

		public ApplicationType ApplicationType { get; set; }
	}
}
