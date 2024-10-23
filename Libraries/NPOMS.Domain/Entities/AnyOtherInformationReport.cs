using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("AnyOtherInformationReports", Schema = "dbo")]
    public  class AnyOtherInformationReport : BaseEntity
    {
        public int StatusId { get; set; }
        public string Highlights { get; set; }
        public string Challenges { get; set; }
      
        public int ApplicationId { get; set; }

        public int QaurterId { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }
        public bool IsActive { get; set;}
        public Status Status { get; set; }
    }
}
