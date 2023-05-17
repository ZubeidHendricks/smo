using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class PropertySubTypeConfiguration : IEntityTypeConfiguration<PropertySubType>
    {
        public void Configure(EntityTypeBuilder<PropertySubType> builder)
        {
            builder.HasData(
    new PropertySubType
    {
        Id = 1,
        PropertyTypeID = 3,
        Name = "Monthly",
        HaveComment = false,
        Repeatable = true,
        Frequency = 12,
        IsActive = true,
        IsDeleted = false,
        CreatedUserID = 3,
        CreatedDateTime = DateTime.Now,
    },
    new PropertySubType
    {
        Id = 2,
        PropertyTypeID = 3,
        Name = "Annually",
        HaveComment = false,
        Repeatable = true,
        Frequency = 1,

        IsActive = true,
        IsDeleted = false,
        CreatedUserID = 3,
        CreatedDateTime = DateTime.Now,
    },
                    new PropertySubType
                    {
                        Id = 3,
                        PropertyTypeID = 3,
                        Name = "264 Days",
                        HaveComment = false,
                        Repeatable = true,
                        Frequency = 264,

                        IsActive = true,
                        IsDeleted = false,
                        CreatedUserID = 3,
                        CreatedDateTime = DateTime.Now
                    },
         new PropertySubType
         {
             Id = 4,
             PropertyTypeID = 3,
             Name = "240 Days",
             HaveComment = false,
             Repeatable = true,
             Frequency = 240,

             IsActive = true,
             IsDeleted = false,
             CreatedUserID = 3,
             CreatedDateTime = DateTime.Now
         },

             new PropertySubType
             {
                 Id = 5,
                 PropertyTypeID = 2,
                 Name = "Social Worker",
                 HaveComment = false,
                 Repeatable = true,
                 Frequency = null,
                 IsActive = false,
                 IsDeleted = false,
                 CreatedUserID = 3,
                 CreatedDateTime = DateTime.Now
             },

             new PropertySubType
             {
                 Id = 6,
                 PropertyTypeID = 2,
                 Name = "Social Worker Supervisor",
                 HaveComment = false,
                 Repeatable = true,
                 Frequency = null,
                 IsActive = true,
                 IsDeleted = false,
                 CreatedUserID = 3,
                 CreatedDateTime = DateTime.Now
             },
                          new PropertySubType
                          {
                              Id = 7,
                              PropertyTypeID = 2,
                              Name = "Social Auxiliary Worker",
                              HaveComment = false,
                              Repeatable = true,
                              Frequency = null,
                              IsActive = true,
                              IsDeleted = false,
                              CreatedUserID = 3,
                              CreatedDateTime = DateTime.Now
                          },
                                                    new PropertySubType
                                                    {
                                                        Id = 8,
                                                        PropertyTypeID = 2,
                                                        Name = "Social Worker Manager",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 9,
                                                        PropertyTypeID = 2,
                                                        Name = "Community Development Practitioner",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 10,
                                                        PropertyTypeID = 2,
                                                        Name = "Community Development Assistant",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 11,
                                                        PropertyTypeID = 4,
                                                        Name = "Facilitator",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 12,
                                                        PropertyTypeID = 4,
                                                        Name = "Catering",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 13,
                                                        PropertyTypeID = 4,
                                                        Name = "Transport",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 14,
                                                        PropertyTypeID = 4,
                                                        Name = "Telephone",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 15,
                                                        PropertyTypeID = 4,
                                                        Name = "Venue Hire",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 16,
                                                        PropertyTypeID = 4,
                                                        Name = "Traveling",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 17,
                                                        PropertyTypeID = 4,
                                                        Name = "Accommodation",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 18,
                                                        PropertyTypeID = 4,
                                                        Name = "Training",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 19,
                                                        PropertyTypeID = 4,
                                                        Name = "Governance Norms and Standards",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 20,
                                                        PropertyTypeID = 4,
                                                        Name = "Management Fee",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 21,
                                                        PropertyTypeID = 4,
                                                        Name = "Other",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = false,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 22,
                                                        PropertyTypeID = 4,
                                                        Name = "Admin Fee",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 23,
                                                        PropertyTypeID = 4,
                                                        Name = "UIF & COIDA",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },


                                                    new PropertySubType
                                                    {
                                                        Id = 24,
                                                        PropertyTypeID = 4,
                                                        Name = "Social",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 25,
                                                        PropertyTypeID = 4,
                                                        Name = "AAA",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 26,
                                                        PropertyTypeID = 4,
                                                        Name = "Skill Development",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 27,
                                                        PropertyTypeID = 4,
                                                        Name = "Security Upgrade & OHS Compliance 1",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 28,
                                                        PropertyTypeID = 4,
                                                        Name = "Security Upgrade & OHS Compliance 2",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 29,
                                                        PropertyTypeID = 4,
                                                        Name = "Security Upgrade & OHS Compliance 3",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 30,
                                                        PropertyTypeID = 4,
                                                        Name = "Travel Cost",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 31,
                                                        PropertyTypeID = 4,
                                                        Name = "Specialized services",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    },
                                                    new PropertySubType
                                                    {
                                                        Id = 32,
                                                        PropertyTypeID = 4,
                                                        Name = "House Mothers",
                                                        HaveComment = false,
                                                        Repeatable = true,
                                                        Frequency = null,
                                                        IsActive = true,
                                                        IsDeleted = false,
                                                        CreatedUserID = 3,
                                                        CreatedDateTime = DateTime.Now
                                                    }

            );
        }
    }
}
