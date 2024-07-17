using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
    [Table("ServicesRendered", Schema = "dbo")]
    public class ServicesRendered : BaseEntity
    {
        public int NpoProfileId { get; set; }

        public int ProgrammeId { get; set; }

        public int SubProgrammeId { get; set; }

        public int SubProgrammeTypeId { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public int EntityTypeNumber { get; set; }

        public int EntitySystemNumber { get; set; }
    }
}