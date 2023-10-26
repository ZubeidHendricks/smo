using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Activities_Recipients", Schema = "mapping")]
	public class ActivityRecipient
	{
		public int ActivityId { get; set; }

		public int RecipientTypeId { get; set; }

		public int EntityId { get; set; }

		public string Entity { get; set; }

		public string RecipientName { get; set; }
	}
}
