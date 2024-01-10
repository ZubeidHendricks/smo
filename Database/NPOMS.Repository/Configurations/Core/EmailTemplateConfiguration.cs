using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
	{
		public void Configure(EntityTypeBuilder<EmailTemplate> builder)
		{
			builder.Property("EmailAccountId").HasDefaultValueSql("1");
			builder.Property("IsActive").HasDefaultValueSql("1");

			builder.HasData(
				new EmailTemplate
				{
					Id = 1,
					Name = "NewAccessRequest",
					Body = "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been sent to be reviewed.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Access Request Created"
				},
				new EmailTemplate
				{
					Id = 2,
					Name = "AccessRequestPending",
					Body = "<p>Dear {ToUserFullName},</p><p>Please review access for <span style=\"font-weight: bold;\">{UserAccessFullName}</span> to the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/#/access-review\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Access Request Submitted"
				},
				new EmailTemplate
				{
					Id = 3,
					Name = "AccessRequestApproved",
					Body = "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been approved.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Access Request Approved"
				},
				new EmailTemplate
				{
					Id = 4,
					Name = "AccessRequestRejected",
					Body = "<p>Dear {ToUserFullName},</p><p>Access to <span style=\"font-weight: bold;\">{NpoName}</span> has been rejected.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Access Request Rejected"
				},
				new EmailTemplate
				{
					Id = 5,
					Name = "NewApplication",
					Body = "<p>Dear {ToUserFullName},</p><p>The application for <span style=\"font-weight: bold;\">{NPO}</span> has been sent to be reviewed. The Reference Number is <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Submitted - {NPO}"
				},
				new EmailTemplate
				{
					Id = 6,
					Name = "StatusChangedPendingReview",
					Body = "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Pending Review - {NPO}"
				},
				new EmailTemplate
				{
					Id = 7,
					Name = "StatusChangedAmendmentsRequired",
					Body = "<p>Dear {ToUserFullName},</p><p>There are changes required to the application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Amendments Required - {NPO}"
				},
				new EmailTemplate
				{
					Id = 8,
					Name = "StatusChangedPendingApproval",
					Body = "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Pending Approval - {NPO}"
				},
				new EmailTemplate
				{
					Id = 9,
					Name = "StatusChangedRejected",
					Body = "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been rejected.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Rejected - {NPO}"
				},
				new EmailTemplate
				{
					Id = 10,
					Name = "StatusChangedPendingSLA",
					Body = "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please upload the SLA document.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Pending SLA - {NPO}"
				},
				new EmailTemplate
				{
					Id = 11,
					Name = "StatusChangedPendingSignedSLA",
					Body = "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been approved.</p><p>Please download the SLA document that requires your signature and upload the signed SLA document.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Pending Signed SLA - {NPO}"
				},
				new EmailTemplate
				{
					Id = 12,
					Name = "StatusChangedAcceptedSLA",
					Body = "<p>Dear {ToUserFullName},</p><p>The signed SLA document has been uploaded for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Accepted SLA - {NPO}"
				},
				new EmailTemplate
				{
					Id = 13,
					Name = "StatusChangedDeptComments",
					Body = "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Review SLA Comments by Department - {NPO}"
				},
				new EmailTemplate
				{
					Id = 14,
					Name = "StatusChangedOrgComments",
					Body = "<p>Dear {ToUserFullName},</p><p>Please review the comments regarding the SLA document for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span>.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Review SLA Comments by Organisation - {NPO}"
				},
				new EmailTemplate
				{
					Id = 15,
					Name = "NewOrganisationApproval",
					Body = "<p>Dear {ToUserFullName},</p><p>Organisation Profile for <span style=\"font-weight: bold;\">{NpoName}</span> has been updated and sent to be reviewed.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Organisation Profile Updated - {NpoName}"
				},
				new EmailTemplate
				{
					Id = 16,
					Name = "PendingOrganisationApproval",
					Body = "<p>Dear {ToUserFullName},</p><p>Please review the following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span>.</p><p>Please <a href=\"{url}/#/npo-approval\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Pending Organisation Approval - {NpoName}"
				},
				new EmailTemplate
				{
					Id = 17,
					Name = "ApprovedOrganisationApproval",
					Body = "<p>Dear {ToUserFullName},</p><p>The following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span> has been approved.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Organisation Approved - {NpoName}"
				},
				new EmailTemplate
				{
					Id = 18,
					Name = "RejectedOrganisationApproval",
					Body = "<p>Dear {ToUserFullName},</p><p>The following Organisation: <span style=\"font-weight: bold;\">{NpoName}</span> has been rejected.</p><p>Please <a href=\"{url}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Organisation Rejected - {NpoName}"
				},
				new EmailTemplate
				{
					Id = 19,
					Name = "WorkplanActualStatusChanged",
					Body = "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been updated with a status of <span style=\"font-weight: bold;\">{status}</span>.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Indicator Actuals {status} - {NPO}"
				},
				new EmailTemplate
				{
					Id = 20,
					Name = "WorkplanActualPendingReview",
					Body = "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been submitted for you to review.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Indicator Actuals Pending Review - {NPO}"
				},
				new EmailTemplate
				{
					Id = 21,
					Name = "WorkplanActualPendingApproval",
					Body = "<p>Dear {ToUserFullName},</p><p>The indicator actuals for application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent for you to approve.</p><p>The financial year and month is <span style=\"font-weight: bold;\">{financialYear}</span> and <span style=\"font-weight: bold;\">{frequencyPeriod}</span> respectively.</p><p>Please <a href=\"{url}/#/workplan-indicator/manage/{npoId}\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Indicator Actuals Pending Approval - {NPO}"
				},
				new EmailTemplate
				{
					Id = 22,
					Name = "StatusChangedPendingReviewerSatisfaction",
					Body = "<p>Dear {ToUserFullName},</p><p>The application with Reference Number <span style=\"font-weight: bold;\">{ApplicationRefNo}</span> has been sent to you to indicate your reviewer satisfaction.</p><p>Please ignore this email if you have indicated your reviewer satisfaction.</p><p>Please <a href=\"{url}/#/applications\">click here</a> to access the NPO MS application.</p><p>Kind Regards,<br>NPO MS Team</p>",
					Subject = "Application Pending Reviewer Satisfaction - {NPO}"
				},
                new EmailTemplate
                {
                    Id = 23,
                    Name = "ScorecardSummary",
                    Body = "<p>Dear {ToUserFullName}</p><p>The Scorecard for application with reference number</p><p><strong>{ApplicationRefNo}</strong> for financial year<strong> {financialYear} </strong> has been completed.</p><p>To view the scorecard summary please&nbsp;</p><p><a href=\"{url}/#/reviewScorecard/{npoId}(print:print/{npoId}/2)\">click here</a> to download a printable version.</p><p>Kind Regards,</p><p>NPO MS Team</p>",
                    Subject = "Scorecard Summary Review - {NPO}"
                },
                new EmailTemplate
                {
                    Id = 24,
                    Name = "InitiateScorecard",
                    Body = "<p>Dear {ToUserFullName}</p><p>The Scorecard for <strong>{organisationName}</strong> with reference number <strong>{ApplicationRefNo}</strong> is now available for rating.</p><p>If you are required to rate this workplan, please <a href=\"{url}/#/applications\">click here</a> to access.</p><p>Kind Regards,</p><p>NPO MS Team</p>",
                    Subject = "Scorecard Initiated Notification - {NPO}"
                }

            );
		}
	}
}
