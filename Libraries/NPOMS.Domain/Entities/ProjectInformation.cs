using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
    [Table("ProjectInformation", Schema = "fa")]
    public class ProjectInformation : BaseEntity
    {

        public int ApplicationId { get; set; }

        public bool? IsNew { get; set; }
        public bool IsActive { get; set; }
        public string purposeQuestion { get; set; }
        public int? CreatedUserId { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
