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

}

export interface dtoServiceDeliveryAreaGet{
    id: number,
    name: string,
    isSelected: boolean
}

export interface dtoQuestionGet{
    id: number,
    name: string,
    questionSectionName: string,
    responseOptions: dtoResponseOptionGet[]
}

export interface dtoResponseOptionGet
{
    id: number,
    name: string,
    isSelected: boolean
}