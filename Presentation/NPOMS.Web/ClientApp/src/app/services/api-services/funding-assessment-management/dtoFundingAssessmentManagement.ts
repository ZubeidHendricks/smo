export interface dtoFundingAssessmentApplicationGet{
    applicationId : number;
    organisationI: number;
    refNo: string;
    organisationName: string;
    organisationType: string;
    applicationName: string;
    subProgrammeName: string;
    financialYearName : string;
    closingDate : string;
    fundingAssessmentStatusName: string;
}

export interface dtoFundingAssessmentApplicationFormGet{
    id: number,
    applicationId: number,
    organisationName: string,
    continueWithAssessment: boolean,
    serviceDeliveries: dtoServiceDeliveryAreaGet[]
    questions: dtoQuestionGet[]
    summaryItems: dtoFundingAssessmentApplicationFormSummaryItemGet[],
    finalApprovalItem: dtoFundingAssessmentApplicationFormFinalApproverItemGet
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

export interface dtoServiceDeliveryAreaGet{
    id: number,
    name: string,
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