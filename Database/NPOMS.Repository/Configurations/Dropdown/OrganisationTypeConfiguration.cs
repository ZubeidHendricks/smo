using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class OrganisationTypeConfiguration : IEntityTypeConfiguration<OrganisationType>
	{
		public void Configure(EntityTypeBuilder<OrganisationType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new OrganisationType
				{
					Id = 1,
					Name = "NPO",
					Description = "Non Profit Organisation"
				},
				new OrganisationType
				{
					Id = 2,
					Name = "NPO/NPC",
					Description = "Non Profit Company registered as NPO"
				},
				new OrganisationType
				{
					Id = 3,
					Name = "NPO/Trust",
					Description = "Trust registered as NPO"
				},
				new OrganisationType
				{
					Id = 4,
					Name = "NPO/VA",
					Description = "Voluntary organization registered as NPO"
				},
				new OrganisationType
				{
					Id = 5,
					Name = "Others",
					Description = "Other Description"
				},
				new OrganisationType
				{
					Id = 6,
					Name = "Section 21 Company",
					Description = "Section 21 Company"
				},
				new OrganisationType
				{
					Id = 7,
					Name = "Sport",
					Description = "Sport Description"
				},
				new OrganisationType
				{
					Id = 8,
					Name = "Trust",
					Description = "Trust Description"
				},
				new OrganisationType
				{
					Id = 9,
					Name = "Pty Ltd",
					Description = "Pty Ltd"
				},
				new OrganisationType
				{
					Id = 10,
					Name = "CC",
					Description = "Close Corporation"
				},
				new OrganisationType
				{
					Id = 11,
					Name = "Reg-ECD",
					Description = "In Process of ECD Registration"
				},
				new OrganisationType
				{
					Id = 12,
					Name = "Reg-Old Person",
					Description = "In Progress of Older Person Registration"
				},
				new OrganisationType
				{
					Id = 13,
					Name = "NGO",
					Description = "Non Governmental Organisation"
				}
			);
		}
	}
}
