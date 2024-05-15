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
		RejectedOrganisationApproval = 18,
		WorkplanActualStatusChanged = 19,
		WorkplanActualPendingReview = 20,
		WorkplanActualPendingApproval = 21,
		StatusChanged = 22,
		StatusChangedPending = 23,
		NewFundingApplication = 24,
		StatusChangedApproved = 25,
		AccessRequestLogged = 26,
		StatusChangedSubmitted = 27,
		StatusChangedVerified = 28,
		StatusChangedPendingReviewerSatisfaction = 29,
		ScorecardSummary = 30,
        InitiateScorecard = 31,
        RejectedScorecard = 32,
        AmendedScorecard = 33
    }
}
