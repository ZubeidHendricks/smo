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
					Name = "Pending Review",
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
				}
			);
		}
	}
}
