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
    public class DistrictCouncilConfiguration : IEntityTypeConfiguration<DistrictCouncil>
    {
        public void Configure(EntityTypeBuilder<DistrictCouncil> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new DistrictCouncil
                {
                    Id = 7,
                    Name = "Cape Winelands",
                    //SystemName = "DC1"
                },
                new DistrictCouncil
                {
                    Id = 8,
                    Name = "Central Karoo",
                    //SystemName = "DC2"
                },
                new DistrictCouncil
                {
                    Id = 9,
                    Name = "City of Cape Town",
                    //SystemName = "DC3"
                },
                new DistrictCouncil
                {
                    Id = 10,
                    Name = "Eden",
                    //SystemName = "DC4"
                },
                new DistrictCouncil
                {
                    Id = 11,
                    Name = "Overberg",
                    //SystemName = "DC5"
                },
                new DistrictCouncil
                {
                    Id = 12,
                    Name = "West Coast",
                    //SystemName = "DC6"
                }

                #region CommentedCode
            //new DistrictCouncil
            //{
            //    Id = 1,
            //    Name = "Cape Town"
            //},
            //new DistrictCouncil
            //{
            //    Id = 2,
            //    Name = "West Coast"
            //},
            //new DistrictCouncil
            //{
            //    Id = 3,
            //    Name = "Cape Winelands"
            //},
            //new DistrictCouncil
            //{
            //    Id = 4,
            //    Name = "Overberg"
            //},
            //new DistrictCouncil
            //{
            //    Id = 5,
            //    Name = "Eden"
            //},
            //new DistrictCouncil
            //{
            //    Id = 6,
            //    Name = "Central Karoo"
            //}
                #endregion

            );
        }
    }
}
