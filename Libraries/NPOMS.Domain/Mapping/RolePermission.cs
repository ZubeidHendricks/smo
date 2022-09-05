using NPOMS.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Roles_Permissions", Schema = "mapping")]
    public class RolePermission
    {
        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public Role Role { get; set; }

        public Permission Permission { get; set; }
    }
}
