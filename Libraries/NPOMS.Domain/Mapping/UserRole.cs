using NPOMS.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Users_Roles", Schema = "mapping")]
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public bool IsActive { get; set; }

        public virtual Role Role { get; set; }
    }
}
