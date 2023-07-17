using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ApplicationInformation", Schema = "dbo")]
	public class ApplicationInformation : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string FullProjectBudget { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string FundingRequiredFromDEDAT { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string ValueOfOwnContribution { get; set; }

		public virtual List<ApplicationInformationCommunicationType> CommunicationTypeMappings { get; set; } = new List<ApplicationInformationCommunicationType>();

		[Column(TypeName = "nvarchar(255)")]
		public string PleaseSpecify { get; set; }


		#endregion
	}
}
