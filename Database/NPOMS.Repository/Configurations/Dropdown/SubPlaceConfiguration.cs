using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class SubPlaceConfiguration : IEntityTypeConfiguration<SubPlace>
    {
        public void Configure(EntityTypeBuilder<SubPlace> builder)
        {

            builder.HasData(
                new SubPlace
                {
                    Id = 1,
                    Name = "Athlone SP",
                    SystemName = "SP28",
                    PlaceId = 1,
                },
            new SubPlace
            {
                Id = 2,
                Name = "Belgravia(Athlone)",
                SystemName = "SP66",
                PlaceId = 1
            },
              new SubPlace
              {
                  Id = 3,
                  Name = "Atlantis Industrial",
                  SystemName = "SP29",
                  PlaceId = 2,
              },

              new SubPlace
              {
                  Id = 4,
                  Name = "Avondale SP1",
                  SystemName = "SP36",
                  PlaceId = 2,
              },

               new SubPlace
               {
                   Id = 5,
                   Name = "Belhar 1",
                   SystemName = "SP68",
                   PlaceId = 3,
               },
                new SubPlace
                {
                    Id = 6,
                    Name = "Belhar 10",
                    SystemName = "SP69",
                    PlaceId = 3,
                },
                 new SubPlace
                 {
                     Id = 7,
                     Name = "Bellville Central",
                     SystemName = "SP95",
                     PlaceId = 4,
                 },
                  new SubPlace
                  {
                      Id = 8,
                      Name = "Bellville Lot 1",
                      SystemName = "SP96",
                      PlaceId = 4,
                  },
                   new SubPlace
                   {
                       Id = 9,
                       Name = "Papekuil Outspan",
                       SystemName = "SP1040",
                       PlaceId = 5,
                   },

                    new SubPlace
                    {
                        Id = 10,
                        Name = "Cape Metro NU1",
                        SystemName = "SP239",
                        PlaceId = 6,
                    },
                     new SubPlace
                     {
                         Id = 11,
                         Name = "Cape Metro NU2",
                         SystemName = "SP240",
                         PlaceId = 6,
                     },

                       new SubPlace
                       {
                           Id = 12,
                           Name = "Cape Metro NU3",
                           SystemName = "SP241",
                           PlaceId = 7,
                       },
                     new SubPlace
                     {
                         Id = 13,
                         Name = "Buckingham",
                         SystemName = "SP226",
                         PlaceId = 8,
                     },
                      new SubPlace
                      {
                          Id = 14,
                          Name = "Crawford",
                          SystemName = "SP289",
                          PlaceId = 8,
                      }
            );
        }
    }
}
