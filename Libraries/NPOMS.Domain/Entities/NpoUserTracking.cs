using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
    [Table("NpoUserTrackings", Schema = "dbo")]
    public class NpoUserTracking : BaseEntity
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public DateTime SentDateTime { get; set; }
    }
}
