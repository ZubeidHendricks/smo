using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("OrganisationalProfiles", Schema = "dbo")]
	public class OrganisationalProfile : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string OrganisationBackground { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string DateOfEstablishment { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Achievements { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string CoreActivities { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string OtherRelevantInformation { get; set; }

		public virtual List<MemberDetail> MemberDetails { get; set; } = new List<MemberDetail>();

		#endregion
	}
}
