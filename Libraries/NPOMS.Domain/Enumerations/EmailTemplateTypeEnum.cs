namespace NPOMS.Domain.Enumerations
{
	public enum EmailTemplateTypeEnum
	{
		NewAccessRequest = 1,
		AccessRequestPending = 2,
		AccessRequestApproved = 3,
		AccessRequestRejected = 4,
		NewApplication = 5,
		StatusChangedPendingReview = 6,
		StatusChangedAmendmentsRequired = 7,
		StatusChangedPendingApproval = 8,
		StatusChangedRejected = 9,
		StatusChangedPendingSLA = 10,
		StatusChangedPendingSignedSLA = 11,
		StatusChangedAcceptedSLA = 12,
		StatusChangedDeptComments = 13,
		StatusChangedOrgComments = 14,
		NewOrganisationApproval = 15,
		PendingOrganisationApproval = 16,
		ApprovedOrganisationApproval = 17,
		RejectedOrganisationApproval = 18
	}
}
