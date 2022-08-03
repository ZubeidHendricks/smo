using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class EmbeddedReportConfiguration : IEntityTypeConfiguration<EmbeddedReport>
	{
		public void Configure(EntityTypeBuilder<EmbeddedReport> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new EmbeddedReport
				{
					Id = 1,
					Name = "Dashboard",
					Description = "Dashboard view everything on the system",
					ReportId = "270ec198-88c7-4e9b-b429-b6b99ace164f",
					WorkspaceId = "38cbb1ed-23d8-4c7d-830a-4f7a39086eca",
					CategoryName = "Dashboard",
				}
			);
		}
	}
}
