using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Configurations.Entities
{
	public class StatusConfiguration : IEntityTypeConfiguration<Status>
	{
		public void Configure(EntityTypeBuilder<Status> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Status
				{
					Id = 1,
					Name = "New",
					SystemName = "New"
				},
				new Status
				{
					Id = 2,
					Name = "Saved",
					SystemName = "Saved"
				},
				new Status
				{
					Id = 3,
					Name = "Submitted – Pending Review",
					SystemName = "PendingReview"
				},
				new Status
				{
					Id = 4,
					Name = "Amendments Required",
					SystemName = "AmendmentsRequired"
				},
				new Status
				{
					Id = 5,
					Name = "Pending Approval",
					SystemName = "PendingApproval"
				},
				new Status
				{
					Id = 6,
					Name = "Rejected",
					SystemName = "Rejected"
				},
				new Status
				{
					Id = 7,
					Name = "Pending SLA",
					SystemName = "PendingSLA"
				},
				new Status
				{
					Id = 8,
					Name = "Pending Signed SLA",
					SystemName = "PendingSignedSLA"
				},
				new Status
				{
					Id = 9,
					Name = "Accepted SLA",
					SystemName = "AcceptedSLA"
				},
				new Status
				{
					Id = 10,
					Name = "Approval In Progress",
					SystemName = "ApprovalInProgress"
				},
				new Status
				{
					Id = 11,
					Name = "SLA: Comments Submitted (Dept)",
					SystemName = "DeptComments"
				},
				new Status
				{
					Id = 12,
					Name = "SLA: Comments Submitted (Org)",
					SystemName = "OrgComments"
				},
				new Status
				{
					Id = 13,
					Name = "Approved",
					SystemName = "Approved"
				},
                new Status
                {
                    Id = 14,
                    Name = "Reviewed",
                    SystemName = "Reviewed"
                },
                 new Status
                 {
                     Id = 15,
                     Name = "Evaluated",
                     SystemName = "Evaluated"
                 },
                new Status
                {
                    Id = 16,
                    Name = "EvaluationInProgress",
                    SystemName = "EvaluationInProgress"
                },
                new Status
                {
                    Id = 17,
                    Name = "AdjudicationInProgress",
                    SystemName = "AdjudicationInProgress"
                },
                new Status
                {
                    Id = 18,
                    Name = "Adjudicated",
                    SystemName = "Adjudicated"
                },
                new Status
                {
                    Id = 19,
                    Name = "Submitted",
                    SystemName = "Submitted"
                },
                new Status
                {
                    Id = 20,
                    Name = "Evaluation Recommended",
                    SystemName = "EvaluationRecommended"
                },
                new Status
                {
                    Id = 21,
                    Name = "Evaluation Not Recommended",
                    SystemName = "EvaluationNotRecommended"
                }
            );
		}
	}
}
