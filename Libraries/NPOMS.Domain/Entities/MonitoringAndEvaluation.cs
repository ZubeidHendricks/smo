using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("MonitoringAndEvaluations", Schema = "dbo")]
	public class MonitoringAndEvaluation : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string ProjectMonitoredByOrganisation { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string BeneficiariesOfProjectMonitored { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string OftenBeneficiariesMonitored { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string MeasurePerformanceOfBeneficiaries { get; set; }

		#endregion
	}
}
