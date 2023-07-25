using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("ApplicationInformation_CommunicationType", Schema = "mapping")]
	public class ApplicationInformationCommunicationType
	{
		#region Properties

		public int ApplicationInformationId { get; set; }

		public int CommunicationTypeId { get; set; }

		public virtual CommunicationType CommunicationType { get; set; }

		#endregion
	}
}
