using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("AuditorOrAffiliations", Schema = "dbo")]
	public class AuditorOrAffiliation : BaseEntity
	{
		/// <summary>
		/// This is the Id of the entity. In this case, it could either be the NpoProfileId or FundingApplicationId.
		/// </summary>
		public int EntityId { get; set; }

		/// <summary>
		/// This is the Name of the entity. In this case, it could either be the NpoProfile or FundingApplication.
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public string EntityName { get; set; }

		/// <summary>
		/// This is the entity type. In this case, it could either be Auditor or Affiliation.
		/// </summary>
		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public string EntityType { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string OrganisationName { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string RegistrationNumber { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string Address { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string ContactPerson { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string EmailAddress { get; set; }

		[Column(TypeName = "nvarchar(10)")]
		public string TelephoneNumber { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Website { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
