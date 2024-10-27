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
    serviceDeliveries: dtoServiceDeliveryAreaGet[]
    questions: dtoQuestionGet[]
    summaryItems: dtoFundingAssessmentApplicationFormSummaryItemGet[],
    finalApprovalItems: dtoFundingAssessmentApplicationFormFinalApproverItemGet[]
}

export interface dtoFundingAssessmentApplicationFormSummaryItemGet
{
    name: string,
    score: number,
    finalRating: number
    isApproved : number
}

export interface dtoServiceDeliveryAreaGet{
    id: number,
    name: string,
    isSelected: boolean
}

export interface dtoQuestionGet{
    id: number,
    name: string,
    selectedOption1: string,
    selectedOption2: string,
    questionSectionName: string,
    responseOptions: dtoResponseOptionGet[],
    responseRatings: dtoResponseOptionGet[],
    hasComment: boolean,
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
    name: string,
    recommendationOptionId: number,
    recommendationReason: string,
    sortOrder: number,
    isComment: boolean
}