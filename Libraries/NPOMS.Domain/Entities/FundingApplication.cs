using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("FundingApplications", Schema = "dbo")]
	public class FundingApplication : BaseEntity
	{
		#region Properties

		[Column(TypeName = "char(15)")]
		public string RefNo { get; set; }

		public int ProgrammeId { get; set; }

		public int StatusId { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public int? VerifiedStatusId { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string VerifiedComments { get; set; }

		public int? VerifiedUserId { get; set; }

		public DateTime? VerifiedDateTime { get; set; }

		public int? ApprovedStatusId { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string ApprovedComments { get; set; }

		public int? ApprovedUserId { get; set; }

		public DateTime? ApprovedDateTime { get; set; }

		public virtual Programme Programme { get; set; }

		public virtual FundingApplicationApplicationCategory FundingApplicationApplicationCategoryMappings { get; set; }

		public virtual ContactInformation ContactInformation { get; set; }

		public virtual ProjectManagerContactInformation ProjectManagerContactInformation { get; set; }

		public virtual BusinessInformation BusinessInformation { get; set; }

		public virtual ApplicationInformation ApplicationInformation { get; set; }

		public virtual OrganisationalProfile OrganisationalProfile { get; set; }

		public virtual ProjectDescription ProjectDescription { get; set; }

		public virtual ProjectImpact ProjectImpact { get; set; }

		public virtual MonitoringAndEvaluation MonitoringAndEvaluation { get; set; }

		public virtual List<Budget> Budgets { get; set; } = new List<Budget>();

		public virtual List<Cashflow> Cashflows { get; set; } = new List<Cashflow>();

		public virtual List<ImplementationTimeline> ImplementationTimelines { get; set; } = new List<ImplementationTimeline>();

		public virtual Status Status { get; set; }

		public virtual User CreatedUser { get; set; }

		public virtual User UpdatedUser { get; set; }

		public virtual User VerifiedUser { get; set; }

		public virtual User ApprovedUser { get; set; }

		public virtual Declaration Declaration { get; set; }

		public virtual MunicipalityInformation MunicipalityInformation { get; set; }

		public virtual BackgroundInformation BackgroundInformation { get; set; }

		public virtual FundingDescription FundingDescription { get; set; }

		public virtual List<ImplementationRisk> ImplementationRisks { get; set; } = new List<ImplementationRisk>();

		public virtual List<MunicipalResourceContribution> MunicipalResourceContributions { get; set; } = new List<MunicipalResourceContribution>();

		public virtual List<DocumentChecklist> DocumentChecklists { get; set; } = new List<DocumentChecklist>();

		#endregion
	}
}
