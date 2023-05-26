using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Mapping
{
    [Table("Project_Implementation_Places", Schema = "mapping")]
    public class ProjectImplementationPlace : BaseEntity
    {
        public int ImplementationId { get; set; }
        public virtual ProjectImplementation Implementation { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }
        public bool IsActive { get; set; }
    }
}
