namespace NPOMS.Domain.Enumerations
{
	public enum StatusEnum
	{
		New = 1,
		Saved = 2,
		PendingReview = 3,
		AmendmentsRequired = 4,
		PendingApproval = 5,
        Declined = 6,
		PendingSLA = 7,
		PendingSignedSLA = 8,
		AcceptedSLA = 9,
		ApprovalInProgress = 10,
		DeptComments = 11,
		OrgComments = 12,
		Approved = 13,
        Reviewed = 14,
        Evaluated = 15,
        EvaluationInProgress = 16,       
        AdjudicationInProgress = 17,
        Adjudicated = 18,
        Submitted = 19,
        Recommended = 20,
        StronglyRecommended = 21,
		NonCompliance = 22

    }
}
