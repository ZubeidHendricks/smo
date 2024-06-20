using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

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

                    Id = 175,
                    Name = "Athlone",
                   // SystemName = "SDA1",
                    RegionId = 51,

                },
                new ServiceDeliveryArea
                {
                    Id = 176,
                    Name = "Atlantis",
                    //SystemName = "SDA2",
                    RegionId = 50
                },
                new ServiceDeliveryArea
                {

                    Id = 178,
                    Name = "Bellville",
                    //SystemName = "SDA4",
                    RegionId = 50
                },



                new ServiceDeliveryArea
                {

                    Id = 183,
                    Name = "Cape Town",
                    //SystemName = "SDA9",
                    RegionId = 50,

                },
                new ServiceDeliveryArea
                {
                    Id = 185,
                    Name = "Delft",
                    //SystemName = "SDA11",
                    RegionId = 50
                },

                    new ServiceDeliveryArea
                    {

                        Id = 187,
                        Name = "Eersterivier",
                        //SystemName = "SDA13",
                        RegionId = 49,

                    },
                new ServiceDeliveryArea
                {
                    Id = 188,
                    Name = "Elsies Rivier",
                    //SystemName = "SDA14",
                    RegionId = 50
                },
                new ServiceDeliveryArea
                {

                    Id = 189,
                    Name = "Fish Hoek",
                    //SystemName = "SDA15",
                    RegionId = 51
                },
                new ServiceDeliveryArea
                {
                    Id = 190,
                    Name = "Gugulethu",
                    //SystemName = "SDA17",
                    RegionId = 51,

                },
                new ServiceDeliveryArea
                {

                    Id = 191,
                    Name = "Khayelitsha",
                    //SystemName = "SDA20",
                    RegionId = 49
                },
                new ServiceDeliveryArea
                {

                    Id = 192,
                    Name = "Khayelitsha 2",
                    //SystemName = "SDA21",
                    RegionId = 49
                },



                new ServiceDeliveryArea
                {

                    Id = 193,
                    Name = "Khayelitsha 3",
                    //SystemName = "SDA22",
                    RegionId = 49,

                },
                new ServiceDeliveryArea
                {

                    Id = 194,
                    Name = "Kraaifontein",
                    //SystemName = "SDA24",
                    RegionId = 49
                },
                new ServiceDeliveryArea
                {

                    Id = 195,
                    Name = "Langa",
                   // SystemName = "SDA26",
                    RegionId = 50
                },
                new ServiceDeliveryArea
                {
                    Id = 196,
                    Name = "Milnerton",
                    //SystemName = "SDA29",
                    RegionId = 50,

                },
                new ServiceDeliveryArea
                {

                    Id = 197,
                    Name = "Mitchell's Plain 1",
                    //SystemName = "SDA30",
                    RegionId = 51
                },
                new ServiceDeliveryArea
                {

                    Id = 198,
                    Name = "Mitchell's Plain 2",
                    //SystemName = "SDA31",
                    RegionId = 51
                },
                new ServiceDeliveryArea
                {

                    Id = 199,
                    Name = "Philippi",
                    //SystemName = "SDA35",
                    RegionId = 51
                },
                new ServiceDeliveryArea
                {
                    Id = 200,
                    Name = "Retreat",
                    //SystemName = "SDA37",
                    RegionId = 51,

                },
                new ServiceDeliveryArea
                {

                    Id = 201,
                    Name = "Somerset West",
                    //SystemName = "SDA39",
                    RegionId = 49
                },
                new ServiceDeliveryArea
                {
                    Id = 202,
                    Name = "Wynberg",
                    //SystemName = "SDA45",
                    RegionId = 51
                }

                #region Commented Code
             //#region Metro East
             //    new ServiceDeliveryArea
             //    {
             //        Id = 1,
             //        RegionId = 4,
             //        Name = "Khayelitsha 1 SDA"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 2,
             //        RegionId = 4,
             //        Name = "Kraaifontein"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 3,
             //        RegionId = 4,
             //        Name = "Khayelitsha 3  SDA"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 4,
             //        RegionId = 4,
             //        Name = "Somerset West"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 5,
             //        RegionId = 4,
             //        Name = "xxEersterivier"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 6,
             //        RegionId = 4,
             //        Name = "Khayelitsha"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 7,
             //        RegionId = 4,
             //        Name = "Blackheath"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 8,
             //        RegionId = 4,
             //        Name = "Eersteriver"
             //    },
             //#endregion

             //#region Metro North

             //    new ServiceDeliveryArea
             //    {
             //        Id = 9,
             //        RegionId = 7,
             //        Name = "Elsies River"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 10,
             //        RegionId = 7,
             //        Name = "Milnerton"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 11,
             //        RegionId = 7,
             //        Name = "Delft"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 12,
             //        RegionId = 7,
             //        Name = "Bellville"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 13,
             //        RegionId = 7,
             //        Name = "Atlantis"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 14,
             //        RegionId = 7,
             //        Name = "Langa"
             //    },



             //    new ServiceDeliveryArea
             //    {
             //        Id = 15,
             //        RegionId = 7,
             //        Name = "Cape Town"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 16,
             //        RegionId = 7,
             //        Name = "Parow"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 17,
             //        RegionId = 7,
             //        Name = "Athlone"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 18,
             //        RegionId = 7,
             //        Name = "xxElsies Rivier"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 19,
             //        RegionId = 7,
             //        Name = "Kraaifontein"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 20,
             //        RegionId = 7,
             //        Name = "Durbanville"
             //    },

             //    new ServiceDeliveryArea
             //    {
             //        Id = 21,
             //        RegionId = 7,
             //        Name = "Goodwood"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 22,
             //        RegionId = 7,
             //        Name = "Metro North"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 23,
             //        RegionId = 7,
             //        Name = "Tygerberg"
             //    },
             //#endregion

             //#region Metro South

             //    new ServiceDeliveryArea
             //    {
             //        Id = 24,
             //        RegionId = 25,
             //        Name = "Fish Hoek"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 25,
             //        RegionId = 25,
             //        Name = "Mitchells Plain 1"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 26,
             //        RegionId = 25,
             //        Name = "Mitchells Plain 2"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 27,
             //        RegionId = 25,
             //        Name = "Athlone"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 28,
             //        RegionId = 25,
             //        Name = "Gugulethu"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 29,
             //        RegionId = 25,
             //        Name = "Retreat"
             //    },



             //    new ServiceDeliveryArea
             //    {
             //        Id = 30,
             //        RegionId = 25,
             //        Name = "Philippi"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 31,
             //        RegionId = 25,
             //        Name = "Wynberg"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 32,
             //        RegionId = 25,
             //        Name = "Mowbray"
             //    },








             //    new ServiceDeliveryArea
             //    {
             //        Id = 33,
             //        RegionId = 25,
             //        Name = "Rondebosch"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 34,
             //        RegionId = 25,
             //        Name = "Plumstead"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 35,
             //        RegionId = 25,
             //        Name = "Wetton"
             //    },

             //    new ServiceDeliveryArea
             //    {
             //        Id = 36,
             //        RegionId = 25,
             //        Name = "Grassy Park"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 37,
             //        RegionId = 25,
             //        Name = "Mitchell's Plain"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 38,
             //        RegionId = 25,
             //        Name = "Nyanga"
             //    },







             //    new ServiceDeliveryArea
             //    {
             //        Id = 39,
             //        RegionId = 25,
             //        Name = "Claremont"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 40,
             //        RegionId = 25,
             //        Name = "Hout Bay"
             //    },

             //    new ServiceDeliveryArea
             //    {
             //        Id = 41,
             //        RegionId = 25,
             //        Name = "Khayelitsha"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 42,
             //        RegionId = 25,
             //        Name = "Lansdowne"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 43,
             //        RegionId = 25,
             //        Name = "Nyanga East"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 44,
             //        RegionId = 25,
             //        Name = "Ocean View"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 45,
             //        RegionId = 25,
             //        Name = "xxPhillipi"
             //    },
             //#endregion

             //#region West Coast
             //    new ServiceDeliveryArea
             //    {
             //        Id = 46,
             //        RegionId = 8,
             //        Name = "Matzikama"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 47,
             //        RegionId = 8,
             //        Name = "Vredenburg"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 48,
             //        RegionId = 8,
             //        Name = "Vredendal"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 49,
             //        RegionId = 8,
             //        Name = "Malmesbury"
             //    },
             //    new ServiceDeliveryArea
             //    {
             //        Id = 50,
             //        RegionId = 8,
             //        Name = "Veldrift"
             //    }
             //    #endregion
                #endregion


             );
        }

    }
}
