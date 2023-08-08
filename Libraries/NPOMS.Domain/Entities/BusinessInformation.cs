using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("BusinessInformation", Schema = "dbo")]
	public class BusinessInformation : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string RegisteredName { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string RegistrationNumber { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string TradingName { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string MunicipalityName { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string PhysicalBusinessAddress { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string PostalAddress { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Telephone { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Cellphone { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string EmailAddress { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string TaxReferenceNumber { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string TaxPinNumber { get; set; }

		public int BBBEELevelId { get; set; }

		public virtual BBBEELevel BBBEELevel { get; set; }

		#endregion
	}
}
