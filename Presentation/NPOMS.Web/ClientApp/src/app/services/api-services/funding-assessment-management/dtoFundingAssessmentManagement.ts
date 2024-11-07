export interface dtoFundingAssessmentApplicationGet{
    id: number;
    applicationId : number;
    organisationI: number;
    organisationName: string;
    cCode: string;
    financialYearName : string;
    fundingAssessmentStatusName: string;
    isCompliant: boolean;
    preSelected: boolean;
    selectedAreaCount: number;
}

export interface dtoFundingAssessmentApplicationFormGet{
    id: number,
    applicationId: number,
    organisationName: string,
    cCode: string;
    approverSubmitted: boolean,
    capturerSubmitted: boolean,
    doiApproved: boolean,
    doiCaptured: boolean,

    canSubmit: boolean,
    serviceDeliverySelectionRequired: boolean,

    continueWithAssessment: boolean,
    questions: dtoQuestionGet[]
    summaryItems: dtoFundingAssessmentApplicationFormSummaryItemGet[],
    finalApprovalItem: dtoFundingAssessmentApplicationFormFinalApproverItemGet,
    serviceDeliveries: dtoFundingAssessmentApplicationFormSDAGet[],

    legislativeComplianceFinalCommentRequired: boolean
}

export interface dtoFundingAssessmentApplicationFormSummaryItemGet
{
    id: number,
    name: string,
    score: number,
    finalRating: number
    selectedResponseOptionId : number
    responseOptions: dtoResponseOptionGet[],
}

export interface dtoFundingAssessmentApplicationFormSDAUpsert
{
    id: number,
    fundingAssessmentFormId: number,
    programServiceDeliveryAreaId: number,
    isSelected: boolean

}

export interface dtoFundingAssessmentApplicationFormSDAGet
{
    id: number,
    programServiceDeliveryAreaId: number,
    regionName: string,
    districtCouncilName: string,
    localMunicipalityName: string,
    serviceDeliveryAreaName: string,
    isSelected: boolean
}


export interface dtoQuestionGet{
    id: number,
    name: string,
    selectedResponseOptionId: number,
    selectedResponseRatingId: number,
    questionSectionName: string,
    responseOptions: dtoResponseOptionGet[],
    responseRatings: dtoResponseOptionGet[],
    hasComment: boolean,
    comment: string
}

export interface dtoFundingAssessmentFormQuestionResponseUpsert
{
    id: number,
    assessmentApplicationFormId: number,
    selectedResponseOptionId: number,
    selectedResponseRatingId: number,
    comment: string
}

export interface dtoResponseOptionGet
{
    id: number,
    name: string,
    responseTypeName: string,
    isSelected: boolean
}

export interface dtoFundingAssessmentApplicationFormFinalApproverItemGet
{
    id: number,
    name: string,
    selectedResponseOptionId: number,
    responseOptions: dtoResponseOptionGet[],
    comment: string
}