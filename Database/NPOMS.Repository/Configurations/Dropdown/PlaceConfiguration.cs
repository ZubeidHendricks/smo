using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {

            builder.HasData(
                new Place
                {
                    Id = 1,
                    Name = "Athlone",
                    SystemName = "PL9",
                    ServiceDeliveryAreaId = 175
                },
                new Place
                {
                    Id = 2,
                    Name = "Atlantis",
                    SystemName = "PL12",
                    ServiceDeliveryAreaId = 176
                },
                new Place
                {
                    Id = 3,
                    Name = "Belhar",
                    SystemName = "PL19",
                    ServiceDeliveryAreaId = 178
                },
                new Place
                {
                    Id = 4,
                    Name = "Bellville",
                    SystemName = "PL21",
                    ServiceDeliveryAreaId = 178
                },
                new Place
                {
                    Id = 5,
                    Name = "Cape Farms",
                    SystemName = "PL51",
                    ServiceDeliveryAreaId = 176
                },

                new Place
                {
                    Id = 6,
                    Name = "Cape Metro",
                    SystemName = "PL52",
                    ServiceDeliveryAreaId = 176
                },
                new Place
                {
                    Id = 7,
                    Name = "Cape Metro",
                    SystemName = "PL53",
                    ServiceDeliveryAreaId = 178
                },

                new Place
                {
                    Id = 8,
                    Name = "Cape Town",
                    SystemName = "PL54",
                    ServiceDeliveryAreaId = 175
                }
                );
        }
    }
}