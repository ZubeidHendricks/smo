using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("SourceOfInformation", Schema = "dbo")]
    public class SourceOfInformation : BaseEntity
    {
        public int? NpoProfileId { get; set; }
        public int? SelectedSourceValue { get; set; }
        public string AdditionalSourceInformation { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

    }
}
