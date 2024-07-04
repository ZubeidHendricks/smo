using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class ServicesRenderedVM
    {
        public ServicesRenderedVM()
        {
            this.SubProgramme = this.SubProgramme ?? new List<SubProgrammeVM>();
        }
        public int Id { get; set; }
        public int NpoProfileId { get; set; }

        public int ProgrammeId { get; set; }

        public int SubProgrammeId { get; set; }

        public int SubProgrammeTypeId { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public List<SubProgrammeVM> SubProgramme { get; set; } = new List<SubProgrammeVM>();
    }
}
