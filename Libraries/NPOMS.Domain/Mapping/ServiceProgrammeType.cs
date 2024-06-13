using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
    [Table("Service_ProgrammeType", Schema = "mapping")]
    public class ServiceProgrammeType : BaseEntity
    {
        public int ServicesRenderedId { get; set; }

        public int SubProgrammeTypeId { get; set; }

        public bool IsActive { get; set; }

        public SubProgrammeType SubProgrammeType { get; set; }
    }
}
