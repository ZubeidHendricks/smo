using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class LocalMunicipalityConfiguration : IEntityTypeConfiguration<LocalMunicipality>
    {
        public void Configure(EntityTypeBuilder<LocalMunicipality> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new LocalMunicipality
                {
                    Id = 1,
                    DistrictCouncilId = 1,
                    Name = "Cape Town"
                },
                new LocalMunicipality
                {
                    Id = 2,
                    DistrictCouncilId = 2,
                    Name = "Bergrivier"
                },
                new LocalMunicipality
                {
                    Id = 3,
                    DistrictCouncilId = 2,
                    Name = "Cederberg"
                },
                new LocalMunicipality
                {
                    Id = 4,
                    DistrictCouncilId = 2,
                    Name = "Matzikama"
                },
                new LocalMunicipality
                {
                    Id = 5,
                    DistrictCouncilId = 2,
                    Name = "Saldanha Bay"
                },
                new LocalMunicipality
                {
                    Id = 6,
                    DistrictCouncilId = 2,
                    Name = "Swartland"
                },
                new LocalMunicipality
                {
                    Id = 7,
                    DistrictCouncilId = 3,
                    Name = "Breede"
                },
                new LocalMunicipality
                {
                    Id = 8,
                    DistrictCouncilId = 3,
                    Name = "Drakenstein"
                },
                new LocalMunicipality
                {
                    Id = 9,
                    DistrictCouncilId = 3,
                    Name = "Langeberg"
                },
                new LocalMunicipality
                {
                    Id = 10,
                    DistrictCouncilId = 3,
                    Name = "Stellenbosch"
                },
                new LocalMunicipality
                {
                    Id = 11,
                    DistrictCouncilId = 3,
                    Name = "Witzenberg"
                },
                new LocalMunicipality
                {
                    Id = 12,
                    DistrictCouncilId = 4,
                    Name = "Cape Agulhas"
                },
                new LocalMunicipality
                {
                    Id = 13,
                    DistrictCouncilId = 4,
                    Name = "Overstrand"
                },
                new LocalMunicipality
                {
                    Id = 14,
                    DistrictCouncilId = 4,
                    Name = "Swellendam"
                },
                new LocalMunicipality
                {
                    Id = 15,
                    DistrictCouncilId = 4,
                    Name = "Theewaterskloof"
                },
                new LocalMunicipality
                {
                    Id = 16,
                    DistrictCouncilId = 5,
                    Name = "Bitou"
                },
                new LocalMunicipality
                {
                    Id = 17,
                    DistrictCouncilId = 5,
                    Name = "George"
                },
                new LocalMunicipality
                {
                    Id = 18,
                    DistrictCouncilId = 5,
                    Name = "Hessequa"
                },
                new LocalMunicipality
                {
                    Id = 19,
                    DistrictCouncilId = 5,
                    Name = "Kannaland"
                },
                new LocalMunicipality
                {
                    Id = 20,
                    DistrictCouncilId = 5,
                    Name = "Knysna"
                },
                new LocalMunicipality
                {
                    Id = 21,
                    DistrictCouncilId = 5,
                    Name = "Mossel Bay"
                },
                new LocalMunicipality
                {
                    Id = 22,
                    DistrictCouncilId = 5,
                    Name = "Oudtshoorn"
                },
                new LocalMunicipality
                {
                    Id = 23,
                    DistrictCouncilId = 6,
                    Name = "Beaufort West"
                },
                new LocalMunicipality
                {
                    Id = 24,
                    DistrictCouncilId = 6,
                    Name = "Laingsburg"
                },
                new LocalMunicipality
                {
                    Id = 25,
                    DistrictCouncilId = 6,
                    Name = "Prince Albert"
                }
            );
        }
    }
}
