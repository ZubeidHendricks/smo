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
                    Id = 26,
                    Name = "Beaufort West",
                    DistrictCouncilId = 8
                },
                new LocalMunicipality
                {
                    Id = 27,
                    Name = "Bergrivier",
                    DistrictCouncilId = 12
                },
                new LocalMunicipality
                {
                    Id = 28,
                    Name = "Bitou",
                    DistrictCouncilId = 10
                },
                new LocalMunicipality
                {
                    Id = 29,
                    Name = "Breede Valley",
                    DistrictCouncilId = 7
                },
                new LocalMunicipality
                {
                    Id = 30,
                    //SystemName = "LC5",
                    Name = "Cape Agulhas",
                    DistrictCouncilId = 11
                },
                new LocalMunicipality
                {
                    Id = 31,
                    Name = "Cederberg",
                    DistrictCouncilId = 12
                },
                new LocalMunicipality
                {
                    Id = 32,
                    Name = "City of Cape Town",
                    DistrictCouncilId = 9
                },
                new LocalMunicipality
                {
                    Id = 33,
                    Name = "Drakenstein",
                    DistrictCouncilId = 7
                },
                new LocalMunicipality
                {
                    Id = 34,
                    Name = "George ",
                    DistrictCouncilId = 10
                },
                new LocalMunicipality
                {
                    Id = 35,
                    Name = "Hessequa",
                    DistrictCouncilId = 10
                },
                new LocalMunicipality
                {
                    Id = 36,
                    Name = "Kannaland",
                    DistrictCouncilId = 10
                },
                new LocalMunicipality
                {
                    Id = 37,
                    Name = "Knysna",
                    DistrictCouncilId = 10
                },
                new LocalMunicipality
                {
                    Id = 38,
                    Name = "Laingsburg",
                    DistrictCouncilId = 8
                },
                new LocalMunicipality
                {
                    Id = 39,
                    Name = "Langeberg",
                    DistrictCouncilId = 7
                },
                new LocalMunicipality
                {

                    Id = 40,
                    Name = "Matzikama",
                    DistrictCouncilId = 12
                },
                new LocalMunicipality
                {

                    Id = 41,
                    Name = "Mossel Bay",
                    DistrictCouncilId = 10
                },
                new LocalMunicipality
                {

                    Id = 42,
                    Name = "Oudtshoorn",
                    DistrictCouncilId = 10
                },
                new LocalMunicipality
                {

                    Id = 43,
                    Name = "Overstrand",
                    DistrictCouncilId = 11
                },
                new LocalMunicipality
                {

                    Id = 44,
                    Name = "Prince Albert",
                    DistrictCouncilId = 8
                },
                new LocalMunicipality
                {
                    Id = 45,
                    Name = "Saldanha Bay",
                    DistrictCouncilId = 12
                },

                new LocalMunicipality
                {
                    Id = 46,
                    Name = "Stellenbosch",
                    DistrictCouncilId = 7
                },
                new LocalMunicipality
                {
                    Id = 47,
                    Name = "Swartland",
                    DistrictCouncilId = 12
                },
                new LocalMunicipality
                {
                    Id = 48,
                    Name = "Swellendam",
                    DistrictCouncilId = 11
                },
                new LocalMunicipality
                {
                    Id = 49,
                    Name = "Theewaterskloof",
                    DistrictCouncilId = 11
                },
                new LocalMunicipality
                {
                    Id = 50,
                    Name = "Witzenberg",
                    DistrictCouncilId = 7
                }
                #region Commented Code
            //#region CapeTown-DistrictCouncil-Municipality
            //    new LocalMunicipality
            //    {
            //        Id = 1,
            //        DistrictCouncilId = 1,
            //        Name = "Cape Town"
            //    },
            //#endregion
            //#region WestCoast-DistrictCouncil-Municipality
            //    new LocalMunicipality
            //    {
            //        Id = 2,
            //        DistrictCouncilId = 2,
            //        Name = "Bergrivier"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 3,
            //        DistrictCouncilId = 2,
            //        Name = "Cederberg"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 4,
            //        DistrictCouncilId = 2,
            //        Name = "Matzikama"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 5,
            //        DistrictCouncilId = 2,
            //        Name = "Saldanha Bay"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 6,
            //        DistrictCouncilId = 2,
            //        Name = "Swartland"
            //    },
            //#endregion
            //#region CapeWinelands-DistrictCouncil-Municipality
            //    new LocalMunicipality
            //    {
            //        Id = 7,
            //        DistrictCouncilId = 3,
            //        Name = "Breede"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 8,
            //        DistrictCouncilId = 3,
            //        Name = "Drakenstein"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 9,
            //        DistrictCouncilId = 3,
            //        Name = "Langeberg"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 10,
            //        DistrictCouncilId = 3,
            //        Name = "Stellenbosch"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 11,
            //        DistrictCouncilId = 3,
            //        Name = "Witzenberg"
            //    },
            //#endregion
            //#region Overberg-DistrictCouncil-Municipality
            //    new LocalMunicipality
            //    {
            //        Id = 12,
            //        DistrictCouncilId = 4,
            //        Name = "Cape Agulhas"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 13,
            //        DistrictCouncilId = 4,
            //        Name = "Overstrand"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 14,
            //        DistrictCouncilId = 4,
            //        Name = "Swellendam"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 15,
            //        DistrictCouncilId = 4,
            //        Name = "Theewaterskloof"
            //    },
            //#endregion
            //#region Eden-DistrictCouncil-Municipality
            //    new LocalMunicipality
            //    {
            //        Id = 16,
            //        DistrictCouncilId = 5,
            //        Name = "Bitou"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 17,
            //        DistrictCouncilId = 5,
            //        Name = "George"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 18,
            //        DistrictCouncilId = 5,
            //        Name = "Hessequa"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 19,
            //        DistrictCouncilId = 5,
            //        Name = "Kannaland"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 20,
            //        DistrictCouncilId = 5,
            //        Name = "Knysna"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 21,
            //        DistrictCouncilId = 5,
            //        Name = "Mossel Bay"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 22,
            //        DistrictCouncilId = 5,
            //        Name = "Oudtshoorn"
            //    },
            //#endregion
            //#region CentralKaroo-DistrictCouncil-LocalMunicipality
            //    new LocalMunicipality
            //    {
            //        Id = 23,
            //        DistrictCouncilId = 6,
            //        Name = "Beaufort West"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 24,
            //        DistrictCouncilId = 6,
            //        Name = "Laingsburg"
            //    },
            //    new LocalMunicipality
            //    {
            //        Id = 25,
            //        DistrictCouncilId = 6,
            //        Name = "Prince Albert"
            //    }
            //    #endregion
                #endregion
            );
        }
    }
}
