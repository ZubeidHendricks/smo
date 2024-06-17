using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Mapping
{
    [Table("Segment_Code", Schema = "mapping")]
    public class SegmentCode : BaseEntity
    {
        public int ProgrammeId {get; set;}
        public string ResponsibilityCode {get; set;}
        public int SubProgrammeTypeId {get; set;}
        public string ObjectiveCode { get; set; }
        public Programme Programme { get; set; }
        public SubProgrammeType SubProgrammeType { get; set; }
    }
}
