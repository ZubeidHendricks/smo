using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Configurations.Entities
{
	public class AccessStatusConfiguration : IEntityTypeConfiguration<AccessStatus>
	{
		public void Configure(EntityTypeBuilder<AccessStatus> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new AccessStatus
				{
					Id = 1,
					Name = "Pending",
					SystemName = "Pending"
				},
				new AccessStatus
				{
					Id = 2,
					Name = "Approved",
					SystemName = "Approved"
				},
				new AccessStatus
				{
					Id = 3,
					Name = "Rejected",
					SystemName = "Rejected"
				}
				,
				new AccessStatus
				{
					Id = 4,
					Name = "New",
					SystemName = "New"
				}
			);
		}
	}
}
