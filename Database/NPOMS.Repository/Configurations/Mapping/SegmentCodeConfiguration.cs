using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Mapping
{
    public class SegmentCodeConfiguration : IEntityTypeConfiguration<SegmentCode>
    {
        public void Configure(EntityTypeBuilder<SegmentCode> builder)
        {
            builder.HasData(
                new SegmentCode { Id = 1, ProgrammeId = 8, ResponsibilityCode = "30075059", SubProgrammeTypeId = 15, ObjectiveCode = "30024059" },
                 new SegmentCode { Id = 2, ProgrammeId = 8, ResponsibilityCode = "30075059", SubProgrammeTypeId = 16, ObjectiveCode = "30023059" },
                new SegmentCode { Id = 3, ProgrammeId = 9, ResponsibilityCode = "30075059", SubProgrammeTypeId = 18, ObjectiveCode = "30028059" },
                new SegmentCode { Id = 4, ProgrammeId = 10, ResponsibilityCode = "30070059", SubProgrammeTypeId = 25, ObjectiveCode = "30040059" },
                new SegmentCode { Id = 5, ProgrammeId = 11, ResponsibilityCode = "30081059", SubProgrammeTypeId = 26, ObjectiveCode = "30064059" },
                new SegmentCode { Id = 6, ProgrammeId = 15, ResponsibilityCode = "30078059", SubProgrammeTypeId = 33, ObjectiveCode = "30011059" },
                new SegmentCode { Id = 7, ProgrammeId = 15, ResponsibilityCode = "30078059", SubProgrammeTypeId = 35, ObjectiveCode = "30007059" },
                new SegmentCode { Id = 8, ProgrammeId = 15, ResponsibilityCode = "30078059", SubProgrammeTypeId = 36, ObjectiveCode = "30009059" },
                new SegmentCode { Id = 9, ProgrammeId = 15, ResponsibilityCode = "30078059", SubProgrammeTypeId = 37, ObjectiveCode = "30008059" },
                new SegmentCode { Id = 10, ProgrammeId = 16, ResponsibilityCode = "30077059", SubProgrammeTypeId = 40, ObjectiveCode = "30015059" },
                new SegmentCode { Id = 11, ProgrammeId = 16, ResponsibilityCode = "30077059", SubProgrammeTypeId = 41, ObjectiveCode = "30017059" },
                new SegmentCode { Id = 12, ProgrammeId = 16, ResponsibilityCode = "30077059", SubProgrammeTypeId = 43, ObjectiveCode = "30018059" },
                new SegmentCode { Id = 13, ProgrammeId = 16, ResponsibilityCode = "30077059", SubProgrammeTypeId = 45, ObjectiveCode = "30016059" },
                new SegmentCode { Id = 14, ProgrammeId = 17, ResponsibilityCode = "30079059", SubProgrammeTypeId = 48, ObjectiveCode = "30049059" },
                new SegmentCode { Id = 15, ProgrammeId = 17, ResponsibilityCode = "30079059", SubProgrammeTypeId = 49, ObjectiveCode = "30047059" },
                new SegmentCode { Id = 16, ProgrammeId = 17, ResponsibilityCode = "30079059", SubProgrammeTypeId = 50, ObjectiveCode = "30048059" },
                new SegmentCode { Id = 17, ProgrammeId = 17, ResponsibilityCode = "30079059", SubProgrammeTypeId = 51, ObjectiveCode = "30053059" },
                new SegmentCode { Id = 18, ProgrammeId = 17, ResponsibilityCode = "30079059", SubProgrammeTypeId = 52, ObjectiveCode = "30046059" },
                new SegmentCode { Id = 19, ProgrammeId = 17, ResponsibilityCode = "30079059", SubProgrammeTypeId = 56, ObjectiveCode = "30050059" },
                new SegmentCode { Id = 20, ProgrammeId = 18, ResponsibilityCode = "30064059", SubProgrammeTypeId = 62, ObjectiveCode = "30059059" },
                new SegmentCode { Id = 21, ProgrammeId = 19, ResponsibilityCode = "30069059", SubProgrammeTypeId = 64, ObjectiveCode = "30044059" },
                new SegmentCode { Id = 22, ProgrammeId = 20, ResponsibilityCode = "30062059", SubProgrammeTypeId = 70, ObjectiveCode = "30062059" },
                new SegmentCode { Id = 23, ProgrammeId = 21, ResponsibilityCode = "30074059", SubProgrammeTypeId = 71, ObjectiveCode = "30037059" }
            );
        }
    }
}
