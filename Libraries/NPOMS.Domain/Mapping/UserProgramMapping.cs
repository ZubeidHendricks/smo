using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Mapping
{
    [Table("UserProgramMapping", Schema = "mapping")]
    public class UserProgramMapping : BaseEntity
    {
        public int UserId { get; set; }

        public int ProgramId { get; set; }

        public bool IsActive { get; set; }

        public UserProgram UserProgram { get; set; }
    }
}
