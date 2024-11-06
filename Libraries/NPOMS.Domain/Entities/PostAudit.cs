using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
    [Table("PostAudits", Schema = "dbo")]
    public class PostAudit : BaseEntity
    {
        public int PostReportId { get; set; }

        public string StatusName { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public PostReport PostReport { get; set; }
    }
}
