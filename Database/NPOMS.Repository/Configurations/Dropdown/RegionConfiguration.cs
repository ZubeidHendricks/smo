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
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(

                            new Region
                            {

                                Id = 49,
                                Name = "Metro East",
                                //SystemName = "RG11",
                                LocalMunicipalityId = 32
                            },
                new Region
                {
                    Id = 50,
                    Name = "Metro North",
                    //SystemName = "RG12",
                    LocalMunicipalityId = 32
                },
                new Region
                {

                    Id = 51,
                    Name = "Metro South",
                    //SystemName = "RG13",
                    LocalMunicipalityId = 32
                }

                #region CommentedCode-Workable
             //#region Region-CapeTown
             //    new Region
             //    {
             //        Id = 1,
             //        LocalMunicipalityId= 1,
             //        Name= "Cape Winelands",
             //    },
             //    new Region
             //    {
             //        Id= 2,
             //        LocalMunicipalityId= 1,
             //        Name = "Cross Boundary"
             //    },
             //    new Region
             //    {
             //        Id = 3,
             //        LocalMunicipalityId = 1,
             //        Name = "Eden Karoo",
             //    },
             //    new Region
             //    {
             //        Id = 4,
             //        LocalMunicipalityId = 1,
             //        Name = "Metro East"
             //    },
             //   new Region
             //   {
             //       Id = 5,
             //       LocalMunicipalityId = 1,
             //       Name = "Metro North",
             //   },
             //    new Region
             //    {
             //        Id = 6,
             //        LocalMunicipalityId = 1,
             //        Name = "Metro South"
             //    },
             //    new Region
             //    {
             //        Id = 7,
             //        LocalMunicipalityId = 1,
             //        Name = "Winelands Overberg"
             //    },
             //#endregion

             //#region Region-WestCoast
             //   new Region
             //   {
             //       Id = 8,
             //       LocalMunicipalityId = 2,
             //       Name = "West Coast",
             //   }
             //   #endregion
                #endregion

                #region Commented Code
             //new Region
             //{
             //    Id = 1,
             //    LocalMunicipalityId = 5,
             //    Name = "Cape Winelands"
             //},
             //new Region
             //{
             //    Id = 2,
             //    LocalMunicipalityId = 5,
             //    Name = "Cross Boundary"
             //},
             //new Region
             //{
             //    Id = 3,
             //    LocalMunicipalityId = 5,
             //    Name = "Eden Karoo"
             //},
             //new Region
             //{
             //    Id = 4,
             //    LocalMunicipalityId = 5,
             //    Name = "Metro East"
             //},
             //new Region
             //{
             //    Id = 5,
             //    LocalMunicipalityId = 5,
             //    Name = "Metro North"
             //},
             //new Region
             //{
             //    Id = 6,
             //    LocalMunicipalityId = 5,
             //    Name = "Metro South"
             //},
             //new Region
             //{
             //    Id = 7,
             //    LocalMunicipalityId = 5,
             //    Name = "Winelands Overberg"
             //},
             //new Region
             //{
             //    Id = 8,
             //    LocalMunicipalityId = 6,
             //    Name = "West Coast"
             //},
             //new Region
             //{
             //    Id = 9,
             //    LocalMunicipalityId = 12,
             //    Name = "Winelands Overberg"
             //},
             //new Region
             //{
             //    Id = 10,
             //    LocalMunicipalityId = 12,
             //    Name = "Cape Winelands"
             //},
             //new Region
             //{
             //    Id = 11,
             //    LocalMunicipalityId = 3,
             //    Name = "Witzenberg"
             //},
             //new Region
             //{
             //    Id = 12,
             //    LocalMunicipalityId = 4,
             //    Name = "Cape Agulhas"
             //},
             //new Region
             //{
             //    Id = 13,
             //    LocalMunicipalityId = 4,
             //    Name = "Overstrand"
             //},
             //new Region
             //{
             //    Id = 14,
             //    LocalMunicipalityId = 4,
             //    Name = "Swellendam"
             //},
             //new Region
             //{
             //    Id = 15,
             //    LocalMunicipalityId = 4,
             //    Name = "Theewaterskloof"
             //},
             //new Region
             //{
             //    Id = 16,
             //    LocalMunicipalityId = 5,
             //    Name = "Bitou"
             //},
             //new Region
             //{
             //    Id = 17,
             //    LocalMunicipalityId = 5,
             //    Name = "George"
             //},
             //new Region
             //{
             //    Id = 18,
             //    LocalMunicipalityId = 5,
             //    Name = "Hessequa"
             //},
             //new Region
             //{
             //    Id = 19,
             //    LocalMunicipalityId = 5,
             //    Name = "Kannaland"
             //},
             //new Region
             //{
             //    Id = 20,
             //    LocalMunicipalityId = 5,
             //    Name = "Knysna"
             //},
             //new Region
             //{
             //    Id = 21,
             //    LocalMunicipalityId = 5,
             //    Name = "Mossel Bay"
             //},
             //new Region
             //{
             //    Id = 22,
             //    LocalMunicipalityId = 5,
             //    Name = "Oudtshoorn"
             //},
             //new Region
             //{
             //    Id = 23,
             //    LocalMunicipalityId = 6,
             //    Name = "Beaufort West"
             //},
             //new Region
             //{
             //    Id = 24,
             //    LocalMunicipalityId = 6,
             //    Name = "Laingsburg"
             //},
             //new Region
             //{
             //    Id = 25,
             //    LocalMunicipalityId = 6,
             //    Name = "Prince Albert"
             //}
                #endregion
             );
        }
    }
}
