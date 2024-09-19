using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class SubDistrictDemographicConfiguration : IEntityTypeConfiguration<SubDistrictDemographic>
    {
        public void Configure(EntityTypeBuilder<SubDistrictDemographic> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new SubDistrictDemographic
                {
                    Id = 1,
                    Name = "Cape Town Eastern Health sub-District",
                    SubSctrcureDemographicId = 1,
                    AreaId = 3,

                },
                new SubDistrictDemographic
                {
                    Id = 2,
                    Name = "Khayelitsha Health sub-District",
                    SubSctrcureDemographicId = 1,
                    AreaId = 3,

                },
                new SubDistrictDemographic
                {
                    Id = 3,
                    Name = "Klipfontein Health sub-District",
                    SubSctrcureDemographicId = 2,
                    AreaId = 1,
                },
                new SubDistrictDemographic
                {
                    Id = 4,
                    Name = "Mitchells Plain Health sub-District",
                    SubSctrcureDemographicId = 2,
                    AreaId = 4,
                },
                new SubDistrictDemographic
                {
                    Id = 5,
                    Name = "Cape Town Northern Health sub-District",
                    SubSctrcureDemographicId = 3,
                    AreaId = 2,
                },
                new SubDistrictDemographic
                {
                    Id = 6,
                    Name = "Tygerberg Health sub-District",
                    SubSctrcureDemographicId = 3,
                    AreaId = 1,
                },
                new SubDistrictDemographic
                {
                    Id = 7,
                    Name = "Cape Town Southern Health sub-District",
                    SubSctrcureDemographicId = 4,
                    AreaId = 4,
                },
                new SubDistrictDemographic
                {
                    Id = 8,
                    Name = "Cape Town Western Health sub-District",
                    SubSctrcureDemographicId = 4,
                    AreaId = 2,
                },
                 new SubDistrictDemographic
                 {
                     Id = 9,
                     Name = "Breede Valley Local Municipality",
                     SubSctrcureDemographicId = 5
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 10,
                     Name = "Drakenstein Local Municipality",
                     SubSctrcureDemographicId = 5
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 11,
                     Name = "Langeberg Local Municipality",
                     SubSctrcureDemographicId = 5
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 12,
                     Name = "Stellenbosch Local Municipality",
                     SubSctrcureDemographicId = 5
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 13,
                     Name = "Witzenberg Local Municipality",
                     SubSctrcureDemographicId = 5
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 14,
                     Name = "Beaufort West Local Municipality",
                     SubSctrcureDemographicId = 6
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 15,
                     Name = "Laingsburg Local Municipality",
                     SubSctrcureDemographicId = 6
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 16,
                     Name = "Prince Albert Local Municipality",
                     SubSctrcureDemographicId = 6
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 17,
                     Name = "Bitou Local Municipality",
                     SubSctrcureDemographicId = 7
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 18,
                     Name = "Hessequa Local Municipality",
                     SubSctrcureDemographicId = 7
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 19,
                     Name = "Kannaland Local Municipality",
                     SubSctrcureDemographicId = 7
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 20,
                     Name = "Knysna Local Municipality",
                     SubSctrcureDemographicId = 7
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 21,
                     Name = "Mossel Bay Local Municipality",
                     SubSctrcureDemographicId = 7
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 22,
                     Name = "Oudtshoorn Local Municipality",
                     SubSctrcureDemographicId = 7
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 23,
                     Name = "Cape Agulhas Local Municipality",
                     SubSctrcureDemographicId = 8
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 24,
                     Name = "Overstrand Local Municipality",
                     SubSctrcureDemographicId = 8
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 25,
                     Name = "Swellendam Local Municipality",
                     SubSctrcureDemographicId = 8
                 }

                 ,
                 new SubDistrictDemographic
                 {
                     Id = 27,
                     Name = "Theewaterskloof Local Municipality",
                     SubSctrcureDemographicId = 8
                 }
                  ,
                 new SubDistrictDemographic
                 {
                     Id = 28,
                     Name = "Bergrivier Local Municipality",
                     SubSctrcureDemographicId = 9
                 }
                  ,
                 new SubDistrictDemographic
                 {
                     Id = 29,
                     Name = "Cederberg Local Municipality",
                     SubSctrcureDemographicId = 9
                 }
                  ,
                 new SubDistrictDemographic
                 {
                     Id = 30,
                     Name = "Matzikama Local Municipality",
                     SubSctrcureDemographicId = 9
                 },
                 new SubDistrictDemographic
                 {
                     Id = 31,
                     Name = "Saldanha Bay Local Municipality",
                     SubSctrcureDemographicId = 9
                 },
                 new SubDistrictDemographic
                 {
                     Id = 32,
                     Name = "Swartland Local Municipality",
                     SubSctrcureDemographicId = 9
                 }
            );
        }
    }
}
