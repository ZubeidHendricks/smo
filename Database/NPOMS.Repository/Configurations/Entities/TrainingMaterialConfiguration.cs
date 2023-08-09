using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Configurations.Entities
{
	public class TrainingMaterialConfiguration : IEntityTypeConfiguration<TrainingMaterial>
	{
		public void Configure(EntityTypeBuilder<TrainingMaterial> builder)
		{
			builder.HasIndex(x => x.Name).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				//new TrainingMaterial
				//{
				//	Id = 1,
				//	Name = "Applicant Guide",
				//	Description = "This guide illustrates how to capture workplans",
				//	Link = "https://www.westerncape.gov.za/dept/health",
				//	IsActive= false
				//},
				//new TrainingMaterial
				//{
				//	Id = 2,
				//	Name = "Reviewer Guide",
				//	Description = "This guide illustrates how to review workplans",
				//	Link = "https://www.westerncape.gov.za/dept/health",
				//	IsActive= false
				//},
                new TrainingMaterial
                {
                    Id = 3,
                    Name = "Programme Specifications",
                    Description = "DSD Programme Specifications",
                    Link = "https://www.westerncape.gov.za/site-page/call-proposals-2024-25-programme-specifications",
					IsActive= true
                },
                new TrainingMaterial
                {
                    Id = 4,
                    Name = "NPO Circular",
                    Description = "UFC 2024-25 NPO Circular",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/ufc_2024-25_npo_circular.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 5,
                    Name = "Basic Eligibility Criteria and Conditions ",
                    Description = "UFC 2024-25 Basic Eligibility Criteria and Conditions ",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/ufc_2024-25_basic_eligibility_criteria_and_conditions.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 6,
                    Name = "NPO Application Form Guide ",
                    Description = "DSD NPO Application Form Guide",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form_guide.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 7,
                    Name = "Online Application User Guide ",
                    Description = "DSD Call for Proposals -  Online Application User Guide",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/call_for_proposals_-_online_application_user_guide.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 8,
                    Name = "Application Form with Annexures (collated)",
                    Description = "DSD NPO Application Form with Annexures (collated)",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form_with_annexures.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 9,
                    Name = "DSD NPO Application Form",
                    Description = "DSD NPO Application Form with Annexures (collated)",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/dsd_npo_application_form.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 10,
                    Name = "Application Form - Declaration of interest",
                    Description = "DSD NPO Application Form - Declaration of interest",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_declaration_of_interest.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 11,
                    Name = "Application Form - BAS entity bank details form",
                    Description = "DSD NPO Application Form - BAS entity bank details form",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_dsd_bas_entity_bank_details_form.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 12,
                    Name = "Application Form - Schedule A Enrolment form (After School Care only)",
                    Description = "DSD NPO Application Form - Schedule A Enrolment form (After School Care only)",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_schedule_a_enrolment_form_-_afterschool_care_only.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 13,
                    Name = "Application Form - Written Assurance",
                    Description = "DSD NPO Application Form - Written Assurance",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/npo_application_form_-_written_assurance.pdf",
                    IsActive = true
                },
                new TrainingMaterial
                {
                    Id = 14,
                    Name = "Application Declaration - Online Applications only",
                    Description = "DSD NPO Application Declaration - Online Applications only",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/dsd_npo_application_declaration_-_online_applications_only.pdf",
                    IsActive = true
                },

                new TrainingMaterial
                {
                    Id = 15,
                    Name = "Frequently Asked Questions",
                    Description = "DSD Call For Proposal Frequently Asked Questions",
                    Link = "https://www.westerncape.gov.za/assets/departments/social-development/CFP/frequently_asked_questions_-_2023_call_for_proposals.pdf",
                    IsActive = true
                }
      
            );
		}
	}
}
