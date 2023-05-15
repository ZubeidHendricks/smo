using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class ServiceDeliveryAreaConfiguration : IEntityTypeConfiguration<ServiceDeliveryArea>
    {
        public void Configure(EntityTypeBuilder<ServiceDeliveryArea> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                 new ServiceDeliveryArea
                 {
                     Id = 1,
                     RegionId = 6,
                     Name = "Mitchells Plain 1"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 2,
                     RegionId = 6,
                     Name = "Mitchells Plain 2"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 3,
                     RegionId = 6,
                     Name = "Fish Hoek"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 4,
                     RegionId = 6,
                     Name = "Athlone"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 5,
                     RegionId = 6,
                     Name = "Gugulethu"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 6,
                     RegionId = 6,
                     Name = "Retreat"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 7,
                     RegionId = 6,
                     Name = "Claremont"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 8,
                     RegionId = 6,
                     Name = "Mowbray"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 9,
                     RegionId = 6,
                     Name = "Wynberg"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 10,
                     RegionId = 6,
                     Name = "Philippi"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 11,
                     RegionId = 6,
                     Name = "Rondebosch"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 12,
                     RegionId = 6,
                     Name = "Plumstead"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 13,
                     RegionId = 6,
                     Name = "Wetton"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 14,
                     RegionId = 6,
                     Name = "Khayelitsha"
                 },

                 new ServiceDeliveryArea
                 {
                     Id = 15,
                     RegionId = 4,
                     Name = "Khayelitsha 1 SDA"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 16,
                     RegionId = 4,
                     Name = "Kraaifontein"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 17,
                     RegionId = 4,
                     Name = "Khayelitsha 3  SDA"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 18,
                     RegionId = 4,
                     Name = "Somerset West"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 19,
                     RegionId = 4,
                     Name = "xxEersterivier"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 20,
                     RegionId = 4,
                     Name = "Eersteriver"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 21,
                     RegionId = 4,
                     Name = "Blackheath"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 22,
                     RegionId = 4,
                     Name = "Khayelitsha 2  SDA"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 23,
                     RegionId = 4,
                     Name = "Eerste River"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 24,
                     RegionId = 4,
                     Name = "Khayelitsha"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 25,
                     RegionId = 4,
                     Name = "Eerste Rivier"
                 },

        new ServiceDeliveryArea
        {
            Id = 26,
            RegionId = 5,
            Name = "Parow"
        },
                 new ServiceDeliveryArea
                 {
                     Id = 27,
                     RegionId = 5,
                     Name = "Athlone"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 28,
                     RegionId = 5,
                     Name = "xxElsies Rivier"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 29,
                     RegionId = 5,
                     Name = "Kraaifontein"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 30,
                     RegionId = 5,
                     Name = "Durbanville"
                 },

                                  new ServiceDeliveryArea
                                  {
                                      Id = 31,
                                      RegionId = 5,
                                      Name = "Goodwood"
                                  },
                 new ServiceDeliveryArea
                 {
                     Id = 32,
                     RegionId = 5,
                     Name = "Metro North"
                 },


                                  new ServiceDeliveryArea
                                  {
                                      Id = 33,
                                      RegionId = 5,
                                      Name = "Tygerberg"
                                  },
                 new ServiceDeliveryArea
                 {
                     Id = 34,
                     RegionId = 5,
                     Name = "Milnerton"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 35,
                     RegionId = 5,
                     Name = "Delft"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 36,
                     RegionId = 5,
                     Name = "Bellville"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 37,
                     RegionId = 5,
                     Name = "Atlantis"
                 },
                 new ServiceDeliveryArea
                 {
                     Id = 38,
                     RegionId = 5,
                     Name = "Langa"
                 }
             );
        }

    }
}
