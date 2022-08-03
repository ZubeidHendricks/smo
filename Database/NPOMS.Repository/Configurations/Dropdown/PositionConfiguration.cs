using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class PositionConfiguration : IEntityTypeConfiguration<Position>
	{
		public void Configure(EntityTypeBuilder<Position> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Position
				{
					Id = 1,
					Name = "Admin Assistant"
				},
				new Position
				{
					Id = 2,
					Name = "Administrative Manager"
				},
				new Position
				{
					Id = 3,
					Name = "Board Member"
				},
				new Position
				{
					Id = 4,
					Name = "CEO"
				},
				new Position
				{
					Id = 5,
					Name = "COO"
				},
				new Position
				{
					Id = 6,
					Name = "Director"
				},
				new Position
				{
					Id = 7,
					Name = "Finance Officer"
				},
				new Position
				{
					Id = 8,
					Name = "Fundraising Officer"
				},
				new Position
				{
					Id = 9,
					Name = "Grants Manager"
				},
				new Position
				{
					Id = 10,
					Name = "Manager"
				},
				new Position
				{
					Id = 11,
					Name = "Operations Director"
				},
				new Position
				{
					Id = 12,
					Name = "Supervisor"
				},
				new Position
				{
					Id = 13,
					Name = "Other"
				},
				new Position
				{
					Id = 14,
					Name = "Principal"
				},
				new Position
				{
					Id = 15,
					Name = "ECD Learner"
				},
				new Position
				{
					Id = 16,
					Name = "Chairperson"
				},
				new Position
				{
					Id = 17,
					Name = "Deputy Chairperson"
				},
				new Position
				{
					Id = 18,
					Name = "Secretary"
				},
				new Position
				{
					Id = 19,
					Name = "Treasurer"
				},
				new Position
				{
					Id = 20,
					Name = "Additional Member"
				},
				new Position
				{
					Id = 21,
					Name = "Social Service Clerk"
				},
				new Position
				{
					Id = 22,
					Name = "Project Manager"
				},
				new Position
				{
					Id = 23,
					Name = "Programme Manager"
				}
			);
		}
	}
}
