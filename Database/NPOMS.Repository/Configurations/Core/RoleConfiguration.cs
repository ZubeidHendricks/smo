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
					SystemName = "SystemAdmin",
					DepartmentCode = "ALL"
				},
				new Role
				{
					Id = 2,
					Name = "Administrator",
					SystemName = "Admin",
                    DepartmentCode = "ALL"
                },
				new Role
				{
					Id = 3,
					Name = "Applicant",
					SystemName = "Applicant",
                    DepartmentCode = "ALL"
                },
				new Role
				{
					Id = 4,
					Name = "Reviewer",
					SystemName = "Reviewer",
                    DepartmentCode = "DOH"
                },
				new Role
				{
					Id = 5,
					Name = "Main Reviewer",
					SystemName = "MainReviewer",
                    DepartmentCode = "DOH"
                },
				new Role
				{
					Id = 6,
					Name = "PreEvaluator",
					SystemName = "PreEvaluator",
                    DepartmentCode = "DSD"
                },
                new Role
                {
                    Id = 7,
                    Name = "Evaluator",
                    SystemName = "Evaluator",
                    DepartmentCode = "DSD"
                },
                new Role
                {
                    Id = 8,
                    Name = "Adjudicator",
                    SystemName = "Adjudicator",
                    DepartmentCode = "DSD"
                },
                new Role
                {
                    Id = 9,
                    Name = "Approver",
                    SystemName = "Approver",
                    DepartmentCode = "DSD"
                },
				new Role
				{
					Id = 10,
					Name = "View Only",
					SystemName = "ViewOnly",
                    DepartmentCode = "DOH"
                },
                new Role
                {
                    Id = 11,
                    Name = "Programme Capturer",
                    SystemName = "ProgrammeCapturer",
                    DepartmentCode = "DSD"
                },
                new Role
                {
                    Id = 12,
                    Name = "Programme Approver",
                    SystemName = "ProgrammeApprover",
                    DepartmentCode = "DSD"
                },
                new Role
                {
                    Id = 13,
                    Name = "Programme viewer",
                    SystemName = "ProgrammeViewOnly",
                    DepartmentCode = "DSD"
                },
                new Role
                {
                    Id = 14,
                    Name = "DHW Approver",
                    SystemName = "DOHApprover",
                    DepartmentCode = "DOH"
                }
            );
		}
	}
}
