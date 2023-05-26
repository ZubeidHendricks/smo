using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Mapping
{
    [Table("Project_Implementation_SubPlaces", Schema = "mapping")]
    public class ProjectImplementationSubPlace : BaseEntity
    {
        public int ImplementationId { get; set; }
        public virtual ProjectImplementation Implementation { get; set; }
        public int SubPlaceId { get; set; }
        public virtual SubPlace SubPlace { get; set; }
        public bool IsActive { get; set; }
    }
}
