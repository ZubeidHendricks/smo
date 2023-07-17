using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("FoundationalEnergyStudy_Cashflow", Schema = "mapping")]
	public class FoundationalEnergyStudyCashflow : BaseEntity
	{
		public int CashflowId { get; set; }

		public int FoundationalEnergyStudyId { get; set; }
	}
}
