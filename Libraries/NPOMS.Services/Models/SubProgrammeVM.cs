using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class SubProgrammeVM
    {
        public SubProgrammeVM()
        {
            this.SubProgrammeType = this.SubProgrammeType ?? new List<SubProgrammeTypeVM>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProgrammeId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public List<SubProgrammeTypeVM> SubProgrammeType { get; set; } = new List<SubProgrammeTypeVM>();
    }
}
