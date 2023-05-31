using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
	{
		public void Configure(EntityTypeBuilder<DocumentType> builder)
		{
			builder.Property("IsCompulsory").HasDefaultValueSql("1");
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new DocumentType
				{
					Id = 1,
					Name = "SLA",
					Location = "Workplan"
				},
				new DocumentType
				{
					Id = 2,
					Name = "Signed SLA",
					Location = "Workplan"
				},
                new DocumentType
                {
                    Id = 7,
                    Name = "Signed Declaration of Interest",
					Description = "Signed Declaration of Interest",
					IsActive = true,
					IsCompulsory = false,
                    Location = "FundApp"
                }
            );
		}
	}
}
