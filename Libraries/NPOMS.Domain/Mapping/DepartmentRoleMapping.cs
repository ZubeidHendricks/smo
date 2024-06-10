using NPOMS.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
    [Table("Departments_Roles", Schema = "mapping")]
    public class DepartmentRoleMapping:BaseEntity
    {
        public int RoleId { get; set; }

        public int DepartmentId { get; set; }

        public bool IsActive { get; set; }

        public Role Role { get; set; }

        public Department department { get; set; }
        
    }
}
