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
                },
                new DocumentType
                {
                    Id = 8,
                    Name = "NPO Reg Cert",
                    Description = "NPO Registration Certificate (copy)",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                },

                new DocumentType
                {
                    Id = 9,
                    Name = "Org Registration Certificate",
                    Description = "NPC/ Trust / PBO Registration Certificate (copies of all applicable)",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                },
                new DocumentType
                {
                    Id = 10,
                    Name = "Constitution",
                    Description = "Organisation Constitution (most recent copy)",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                },
                new DocumentType
                {
                    Id = 11,
                    Name = "Supporting",
                    Description = "Statutory Registration Certificates (copies of all applicable)",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                },
                new DocumentType
                {
                    Id = 12,
                    Name = "Bank Letter",
                    Description = "Bank details confirmation letter (New applicants only)",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                },
                new DocumentType
                {
                    Id = 13,
                    Name = "Audited Annual Financial",
                    Description = "A copy of the Organisations’ most recent",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                },
                new DocumentType
                {
                    Id = 14,
                    Name = "Certified Financial Statement",
                    Description = "A copy of the Organisations’ most recent Certified Financial Statements by a registered accountant, if income is less than R600 000.00 per annum",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                },
                new DocumentType
                {
                    Id = 15,
                    Name = "PFMA",
                    Description = "Written assurance in terms of Section 38 of the PFMA",
                    Location = "FundApp",
                    IsActive = true,
                    IsCompulsory = false
                }
            );
		}
	}
}
