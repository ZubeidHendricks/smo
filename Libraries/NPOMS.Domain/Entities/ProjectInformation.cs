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

        //public string InitiatedQuestion { get; set; }
        //public string considerQuestion { get; set; }
        public string purposeQuestion { get; set; }

    }
}
