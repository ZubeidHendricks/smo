using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class UserProgramViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProgramId { get; set; }

        public bool IsActive { get; set; }
    }
}
