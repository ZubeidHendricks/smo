using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using System;

namespace NPOMS.Repository.Configurations.Entities
{
    public class AffiliatedOrganisationInformationConfiguration : IEntityTypeConfiguration<AffiliatedOrganisationInformation>
    {
        public void Configure(EntityTypeBuilder<AffiliatedOrganisationInformation> builder)
        {
        }
    }
}
