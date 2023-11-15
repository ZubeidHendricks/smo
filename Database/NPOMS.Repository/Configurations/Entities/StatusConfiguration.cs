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
					Name = "Declined",
					SystemName = "Declined"
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
                    Name = "Verified",
                    SystemName = "Verified"
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
                    Name = "Recommended",
                    SystemName = "Recommended"
                },
                new Status
                {
                    Id = 21,
                    Name = "StronglyRecommended",
                    SystemName = "Strongly Recommended"
                },
                new Status
                {
                    Id = 22,
                    Name = "NonCompliance",
                    SystemName = "Non Compliance"
                },
				new Status
				{
					Id = 23,
					Name = "Pending Reviewer Satisfaction",
					SystemName = "PendingReviewerSatisfaction"
				}
            );
		}
	}
}
