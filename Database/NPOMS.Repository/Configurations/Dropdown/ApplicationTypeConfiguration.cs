using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class ApplicationTypeConfiguration : IEntityTypeConfiguration<ApplicationType>
	{
		public void Configure(EntityTypeBuilder<ApplicationType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new ApplicationType
				{
					Id = 1,
					Name = "Funding Application",
					SystemName = "FA"
				},
				new ApplicationType
				{
					Id = 2,
					Name = "Service Provision",
					SystemName = "SP"
				},
                new ApplicationType
                {
                    Id = 3,
                    Name = "Quick Capture",
                    SystemName = "QC"
                },
                new ApplicationType
                {
                    Id = 4,
                    Name = "Business Plan",
                    SystemName = "BP"
                }, 
				new ApplicationType
                {
                    Id = 5,
                    Name = "Call For Proposal",
                    SystemName = "CFP"
                }
            );
		}
	}
}
