using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class TitleConfiguration : IEntityTypeConfiguration<Title>
	{
		public void Configure(EntityTypeBuilder<Title> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Title
				{
					Id = 1,
					Name = "Mr"
				},
				new Title
				{
					Id = 2,
					Name = "Mrs"
				},
				new Title
				{
					Id = 3,
					Name = "Miss"
				},
				new Title
				{
					Id = 4,
					Name = "Dr"
				},
				new Title
				{
					Id = 5,
					Name = "Prof"
				},
				new Title
				{
					Id = 6,
					Name = "Ms"
				},
				new Title
				{
					Id = 7,
					Name = "Other"
				}
			);
		}
	}
}
