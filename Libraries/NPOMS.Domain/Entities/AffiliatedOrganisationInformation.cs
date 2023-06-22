using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{

    [Table("AffiliatedOrganisationInformation", Schema = "dbo")]
    public class AffiliatedOrganisationInformation : BaseEntity
    {
        public int? npoProfileId { get; set; }
        public string NameOfOrganisation { get; set; }
        public string ContactPerson { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Website { get; set; } 
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
