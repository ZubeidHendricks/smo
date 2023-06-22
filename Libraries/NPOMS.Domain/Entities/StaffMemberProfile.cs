using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("StaffMemberProfiles", Schema = "dbo")]
	public class StaffMemberProfile : BaseEntity
	{
		public int NpoProfileId { get; set; }

		public int StaffCategoryId { get; set; }

		public int VacantPosts { get; set; }

		public int FilledPosts { get; set; }

		public int ConsultantsAppointed { get; set; }

		public int StaffWithDisabilities { get; set; }

		public int AfricanMale { get; set; }

		public int AfricanFemale { get; set; }

		public int IndianMale { get; set; }

		public int IndianFemale { get; set; }

		public int ColouredMale { get; set; }

		public int ColouredFemale { get; set; }

		public int WhiteMale { get; set; }

		public int WhiteFemale { get; set; }

		public string OtherSpecify { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
