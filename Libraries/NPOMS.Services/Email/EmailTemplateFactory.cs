using NPOMS.Domain.Enumerations;
using NPOMS.Services.Email.EmailTemplates;

namespace NPOMS.Services.Email
{
	public static class EmailTemplateFactory
	{
		public static IEmailTemplate Create(EmailTemplateTypeEnum type)
		{
			IEmailTemplate _template;
			switch (type)
			{
				case EmailTemplateTypeEnum.NewAccessRequest:
					_template = new NewAccessRequestEmailTemplate();
					break;
				case EmailTemplateTypeEnum.AccessRequestPending:
					_template = new AccessRequestPendingEmailTemplate();
					break;
				case EmailTemplateTypeEnum.AccessRequestApproved:
					_template = new AccessRequestApprovedEmailTemplate();
					break;
				case EmailTemplateTypeEnum.AccessRequestRejected:
					_template = new AccessRequestRejectedEmailTemplate();
					break;
				case EmailTemplateTypeEnum.NewApplication:
					_template = new NewApplicationEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedPendingReview:
					_template = new StatusChangedPendingReviewEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedAmendmentsRequired:
					_template = new StatusChangedAmendmentsRequiredEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedPendingApproval:
					_template = new StatusChangedPendingApprovalEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedRejected:
					_template = new StatusChangedRejectedEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedPendingSLA:
					_template = new StatusChangedPendingSLAEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedPendingSignedSLA:
					_template = new StatusChangedPendingSignedSLAEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedAcceptedSLA:
					_template = new StatusChangedAcceptedSLAEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedDeptComments:
					_template = new StatusChangedDeptCommentsEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedOrgComments:
					_template = new StatusChangedOrgCommentsEmailTemplate();
					break;
				case EmailTemplateTypeEnum.NewOrganisationApproval:
					_template = new NewOrganisationApprovalEmailTemplate();
					break;
				case EmailTemplateTypeEnum.PendingOrganisationApproval:
					_template = new PendingOrganisationApprovalEmailTemplate();
					break;
				case EmailTemplateTypeEnum.ApprovedOrganisationApproval:
					_template = new ApprovedOrganisationApprovalEmailTemplate();
					break;
				case EmailTemplateTypeEnum.RejectedOrganisationApproval:
					_template = new RejectedOrganisationApprovalEmailTemplate();
					break;
				case EmailTemplateTypeEnum.WorkplanActualStatusChanged:
					_template = new WorkplanActualStatusChangedEmailTemplate();
					break;
				case EmailTemplateTypeEnum.WorkplanActualPendingReview:
					_template = new WorkplanActualPendingReviewEmailTemplate();
					break;
				case EmailTemplateTypeEnum.WorkplanActualPendingApproval:
					_template = new WorkplanActualPendingApprovalEmailTemplate();
					break;
				case EmailTemplateTypeEnum.StatusChangedPendingReviewerSatisfaction:
					_template = new StatusChangedPendingReviewerSatisfactionEmailTemplate();
					break;
                case EmailTemplateTypeEnum.ScorecardSummary:
                    _template = new ScorecardSummaryEmailTemplates();
                    break;
                case EmailTemplateTypeEnum.InitiateScorecard:
                    _template = new InitiateScorecardEmailTemplates();
                    break;
                case EmailTemplateTypeEnum.RejectedScorecard:
                    _template = new RejectedScorecardEmailTemplate();
                    break;
                default:
					_template = null;
					break;
			}

			return _template;
		}

		public static T Get<T>(this IEmailTemplate email)
		{
			return (T)email;
		}
	}
}
