using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("NpoWorkPlanApproverTrackings", Schema = "dbo")]
    public class NpoWorkPlanApproverTracking : BaseEntity
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public DateTime SentDateTime { get; set; }
    }
}
