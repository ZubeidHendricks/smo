using System.ComponentModel.DataAnnotations;

namespace NPOMS.Domain
{
	public class BaseEntity
	{
		[Key]
		public int Id { get; set; }
	}
}
