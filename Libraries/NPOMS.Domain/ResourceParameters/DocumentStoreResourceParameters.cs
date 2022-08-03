using NPOMS.Domain.Enumerations;

namespace NPOMS.Domain.ResourceParameters
{
	public class DocumentStoreResourceParameters : ResourceParametersBase
	{
		public EntityTypeEnum EntityType { get; set; }

		public int EntityId { get; set; }
	}
}
