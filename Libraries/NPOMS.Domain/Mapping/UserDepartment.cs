using NPOMS.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Users_Departments", Schema = "mapping")]
	public class UserDepartment : BaseEntity
	{
		public int UserId { get; set; }

		public int DepartmentId { get; set; }

		public virtual Department Department { get; set; }
	}
}
