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
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasData(
     new PropertyType
     {
         Id = 1,
         Code = "AdministrationFee",
         Name = "Administration Fee (%)",
         OnGeneralLevel = true,
         OnSubsidyLevel = false,
         CanDefineName = false,
         ValueOnGeneralLevel = false,
         ValueOnSybsidyLevel = true,
         HaveBreakDown = false,
         HaveRelatedProperty = false,
         HaveFrequency = false,
         IsBusinessRule = false,
         IsActive = true,
         IsDeleted = false,
         CreatedUserID = 3,
         CreatedDateTime = DateTime.Now,


     },
     new PropertyType
     {
         Id = 2,

         Code = "PostItem",
         Name = "Post Cost",
         OnGeneralLevel = true,
         OnSubsidyLevel = true,
         CanDefineName = false,
         ValueOnGeneralLevel = true,
         ValueOnSybsidyLevel = false,
         HaveBreakDown = true,
         HaveRelatedProperty = false,
         HaveFrequency = false,
         IsBusinessRule = false,
         IsActive = true,
         IsDeleted = false,
         CreatedUserID = 3,
         CreatedDateTime = DateTime.Now,
     },
     new PropertyType
     {
         Id = 3,

         Code = "UnitItem",
         Name = "Unit Cost",
         OnGeneralLevel = false,
         OnSubsidyLevel = true,
         CanDefineName = true,
         ValueOnGeneralLevel = false,
         ValueOnSybsidyLevel = true,
         HaveBreakDown = true,
         HaveRelatedProperty = false,
         HaveFrequency = true,
         IsBusinessRule = false,
         IsActive = true,
         IsDeleted = false,
         CreatedUserID = 3,
         CreatedDateTime = DateTime.Now,
     },

     new PropertyType
     {
         Id = 4,

         Code = "OperationalItem",
         Name = "Operational Cost (With Break Down)",
         OnGeneralLevel = false,
         OnSubsidyLevel = true,
         CanDefineName = false,
         ValueOnGeneralLevel = false,
         ValueOnSybsidyLevel = false,
         HaveBreakDown = true,
         HaveRelatedProperty = true,
         HaveFrequency = false,
         IsBusinessRule = false,
         IsActive = true,
         IsDeleted = false,
         CreatedUserID = 3,
         CreatedDateTime = DateTime.Now
     },

         new PropertyType
         {
             Id = 6,

             Code = "RuleForSocialWorkers",
             Name = "Rule For Social Workers",
             OnGeneralLevel = false,
             OnSubsidyLevel = true,
             CanDefineName = false,
             ValueOnGeneralLevel = false,
             ValueOnSybsidyLevel = false,
             HaveBreakDown = false,
             HaveRelatedProperty = true,
             HaveFrequency = false,
             IsBusinessRule = true,
             IsActive = true,
             IsDeleted = false,
             CreatedUserID = 3,
             CreatedDateTime = DateTime.Now

         },

     new PropertyType
     {
         Id = 7,

         Code = "UIFFee",
         Name = "UIF Fee (%)",
         OnGeneralLevel = true,
         OnSubsidyLevel = true,
         CanDefineName = false,
         ValueOnGeneralLevel = true,
         ValueOnSybsidyLevel = false,
         HaveBreakDown = false,
         HaveRelatedProperty = false,
         HaveFrequency = false,
         IsBusinessRule = false,
         IsActive = true,
         IsDeleted = false,
         CreatedUserID = 3,
         CreatedDateTime = DateTime.Now

     },
         new PropertyType
         {
             Id = 8,

             Code = "COIDAFee",
             Name = "COIDA Fee (%)",
             OnGeneralLevel = true,
             OnSubsidyLevel = false,
             CanDefineName = false,
             ValueOnGeneralLevel = true,
             ValueOnSybsidyLevel = false,
             HaveBreakDown = false,
             HaveRelatedProperty = false,
             HaveFrequency = false,
             IsBusinessRule = false,
             IsActive = true,
             IsDeleted = false,
             CreatedUserID = 3,
             CreatedDateTime = DateTime.Now

         });
        }
    }
}
