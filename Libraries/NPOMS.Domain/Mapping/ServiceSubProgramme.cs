using NPOMS.Domain.Dropdown;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
    [Table("Service_SubProgramme", Schema = "mapping")]
    public class ServiceSubProgramme : BaseEntity
    {
        public int ServicesRenderedId { get; set; }

        public int SubProgrammeId { get; set; }

        public bool IsActive { get; set; }

        public SubProgramme SubProgramme { get; set; }
    }
}
