using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Role
				{
					Id = 1,
					Name = "System Administrator",
					SystemName = "SystemAdmin"
				},
				new Role
				{
					Id = 2,
					Name = "Administrator",
					SystemName = "Admin"
				},
				new Role
				{
					Id = 3,
					Name = "Applicant",
					SystemName = "Applicant"
				},
				new Role
				{
					Id = 4,
					Name = "Reviewer",
					SystemName = "Reviewer"
				},
				new Role
				{
					Id = 5,
					Name = "Main Reviewer",
					SystemName = "MainReviewer"
				},
				new Role
				{
					Id = 6,
					Name = "PreEvaluator",
					SystemName = "PreEvaluator"
                },
                new Role
                {
                    Id = 7,
                    Name = "Evaluator",
                    SystemName = "Evaluator"
                },
                new Role
                {
                    Id = 8,
                    Name = "Adjudicator",
                    SystemName = "Adjudicator"
                },
                new Role
                {
                    Id = 9,
                    Name = "Approver",
                    SystemName = "Approver"
                }
            );
		}
	}
}
