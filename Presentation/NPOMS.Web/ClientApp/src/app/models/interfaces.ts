

import { FinancialMatters } from "./FinancialMatters";
import { EntityTypeEnum } from "./enums";


/* Core */
export interface IDepartment {
    id: number;
    name: string;
    abbreviation: string;
    denodoDepartmentName: string;
    isActive: boolean;
}

export interface IProgramBankDetails {
    id: number;
    programId: number;
    subProgrammeId: number;
    subProgrammeTypeId: number;
    bankId: number;
    branchId: number;
    accountTypeId: number;
    accountNumber: string;
    isActive: boolean;
    isSelected: boolean;
    isSubmitted: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId?: number;
    updatedDateTime?: Date;
    branchCode: string;
    approvalStatus: IAccessStatus;
    bank: IBank;
    branch: IBranch;
    accountType: IAccountType;
    npoProfileId: number;
}

export interface IProgrammeServiceDelivery {
    id: number;
    programId: number;
    subProgrammeId: number;
    subProgrammeTypeId: number;
    npoProfileId: number;
    isActive: boolean;
    isSelected: boolean;
    isSubmitted: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId?: number;
    updatedDateTime?: Date;
    regionId?: number;
    districtCouncilId?: number;
    localMunicipalityId?: number;
    regions?: IRegion[];
    districtCouncil?: IDistrictCouncil;
    localMunicipality?: ILocalMunicipality;
    serviceDeliveryAreas?: ISDA[];
    approvalStatus: IAccessStatus;
}

export interface IProgramContactInformation {
    id: number;
    programmeId: number;
    subProgrammeId: number;
    subProgrammeTypeId: number;
    npoProfileId: number;
    titleId: number;
    raceId: number;
    languageId: number;
    genderId: number;
    firstName: string;
    lastName: string;
    rsaIdNumber: boolean;
    idNumber: string;
    passportNumber: string;
    emailAddress: string;
    telephone: string;
    cellphone: string;
    positionId: number;
    comments: string;
    qualifications: string;
    addressInformation: string;
    isPrimaryContact: boolean;
    isDisabled: boolean;
    isSubmitted: boolean;
    isSignatory: boolean;
    isWrittenAgreementSignatory: boolean;
    isBoardMember: boolean;
    yearsOfExperience: number;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;
    dateOfEmployment: Date;
    title: ITitle;
    position: IPosition;
    gender: IGender;
    race: IRace;
    language: ILanguage;
    approvalStatus: IAccessStatus;
}

export interface IDocumentStore {
    id: number,
    documentTypeId: number;
    entityType: EntityTypeEnum,
    entityId: number,
    name: string,
    resourceId: string,
    fileSize: string,
    createdUserId: any,
    createdDateTime: Date,
    isActive: boolean,
    typeOfEvent: string;
    entity: string;

    documentType: IDocumentType,
}

export interface IDocumentType {
    id: number,
    name: string,
    description: string,
    isCompulsory: boolean;
    isActive: boolean;
    location: string;
}

export interface IFinancialYear {
    id: number;
    name: string;
    year: number;
    startDate: Date;
    endDate: Date;
    isActive: boolean;
}

export interface IQuarterlyPeriod {
    id: number;
    abbreviation: string;
    name: string;
    isActive: boolean;
}

export interface IPermission {
    id: number,
    name: string,
    systemName: string,
    categoryName: string,
    isActive: boolean
}

export interface IRole {
    id: number;
    name: string;
    systemName: string,
    isActive: boolean;
    tempId: string; // generated client side
    departmentCode: string;
}

export interface IUser {
    id: number;
    email: string;
    userName: string;
    firstName: string;
    lastName: string;
    fullName: string;
    isActive: boolean;
    isB2C: boolean;

    roles: IRole[];
    departments: IDepartment[];
    permissions: IPermission[];
    userNpos: IUserNpo[];
    userPrograms: IProgramme[];
}

export interface IUtility {
    id: number,
    name: string;
    description: string;
    angularRedirectUrl: string;
    systemAdminUtility: boolean;
    isActive: boolean;
}

export interface IEmbeddedReport {
    id: number,
    name: string,
    description: string,
    reportId: string,
    workspaceId: string,
    categoryName: string,
    isActive: boolean
}

/* Dropdown */
export interface IActivityType {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

export interface IAllocationType {
    id: number;
    name: string;
    systemName: string,
    isActive: boolean;
}

export interface IApplicationType {
    id: number;
    name: string;
    systemName: string,
    isActive: boolean;
}

export interface IFacilityClass {
    id: number;
    name: string;
    isActive: boolean;
}

export interface IFacilityDistrict {
    id: number;
    name: string;
    isActive: boolean;
    activityId: number;
}

export interface IFacilitySubDistrict {
    id: number;
    facilityDistrictId: number;
    name: string;
    isActive: boolean;
    activityId: number;
    facilityDistrict: IFacilityDistrict;
}


export interface IDistrictDemographic {
    id: number;
    name: string;
    isActive: boolean;
    isSubParent: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId?: number | null;
    updatedDateTime?: Date | null;
}

export interface IManicipalityDemographic {
    id: number;
    districtDemographicId: number;
    subParentiId: number;
    name: string;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId?: number | null;
    updatedDateTime?: Date | null;
    districtDemographic: IDistrictDemographic;
}

export interface ISubstructureDemographic {
    id: number;
    manicipalityDemographicId: number;
    name: string;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId?: number | null;
    updatedDateTime?: Date | null;
    manicipalityDemographic: IManicipalityDemographic;
}

export interface IArea {
    id: number;
    districtId: number;
    name: string;
    isActive: boolean;
    activityId: number;
    demographicDistrictId: number;
}


export interface ISubDistrictDemographic {
    id: number;
    subSctrcureDemographicId: number;
    areaId: number;
    name: string;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId?: number | null;
    updatedDateTime?: Date | null;
    subSctrcureDemographic: ISubstructureDemographic;
}


export interface IFacilitySubStructure {
    id: number;
    activityId: number;
    facilityDistrictId: number;
    name: string;
    isActive: boolean;
    facilityDistrict: IFacilityDistrict;
}

export interface IFacilityType {
    id: number;
    name: string;
    isActive: boolean;
}

export interface IOrganisationType {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
}

export interface IPosition {
    id: number;
    name: string;
    isActive: boolean;
}

export interface IRace {
    id: number;
    name: string;
    isActive: boolean;
}

export interface IGender {
    id: number;
    name: string;
    isActive: boolean;
}

export interface ILanguage {
    id: number;
    name: string;
    isActive: boolean;
}

export interface IProgrammes {
    id: number;
    name: string;
    departmentId: number;
    isActive: boolean;
}

export interface IProgramme {
    id: number;
    name: string;
    description: string;
    departmentId: number;
    directorateId: number;
    isActive: boolean;
    department: IDepartment;
    directorate: IDirectorate;
}

export interface IProvisionType {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

export interface IRecipientType {
    id: number;
    name: string;
    systemName: string,
    isActive: boolean;
}

export interface IResourceType {
    id: number;
    name: string;
    systemName: string,
    isActive: boolean;
}

export interface IServiceType {
    id: number;
    name: string;
    systemName: string,
    isActive: boolean;
}

export interface ISubProgramme {
    id: number;
    name: string;
    description: string;
    programmeId: number;
    isActive: boolean;
    programme: IProgramme;
}

export interface ITitle {
    id: number;
    name: string;
    isActive: boolean;
}

export interface IFrequency {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
    frequencyNumber: number;
}

export interface IFrequencyPeriod {
    id: number;
    frequencyId: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

export interface ISubProgrammeType {
    id: number;
    name: string;
    description: string;
    subProgrammeId: number;
    isActive: boolean;
    subProgramme: ISubProgramme;
}

export interface IServiceSubProgramme {
    id: number;
    servicesRenderedId: number;
    subProgrammeId: number;
    isActive: boolean;
    subProgramme: ISubProgramme;
}
export interface IServiceProgrammeType {
    id: number;
    servicesRenderedId: number;
    subProgrammeTypeId: number;
    isActive: boolean;
    subProgrammeType: ISubProgrammeType;
}

export interface IStaffCategory {
    id: number;
    name: string;
    isActive: boolean;
}

export interface IDirectorate {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
}

export interface IBank {
    id: number;
    name: string;
    code: string;
    isActive: boolean;
}

export interface IBranch {
    id: number;
    name: string;
    branchCode: string;
    bankId: number;
    isActive: boolean;

    bank: IBank;
}

export interface IAccountType {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

export interface IRegistrationStatus {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

/* Entities */
export interface IAccessStatus {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

export interface IIndicator {
    id: number;
    year: string;
    subProgrammeTypeId: number;
    indicatorValue: string;
    indicatorDesc : string;
    outputTitle : string;
    annualTarget: number;
    q1: string;
    q2: string;
    q3: string;
    q4: string;
    shortDefinition: string;
    purpose: string;
    keyBeneficiaries: string;
    sourceOfData: string;
    dataLimitations: string;
    assumptions: string;
    meansOfVerification: string;
    methodOfCalculation: string;
    calculationType: string;
    reportingCycle: string;
    desiredPerformance: string;
    typeOfIndicatorServiceDelivery: string;
    typeOfIndicatorDemandDriven: string;
    typeOfIndicatorStandard: string;
    spatialLocationOfIndicator: string;
    indicatorResponsibility: string;
    spatialTransformation: string;
    disaggregationOfBeneficiaries: string;
    psip: string;
    implementationData: string;
  }

  export interface INPOIndicator {
    id: number;
    year: string;
    ccode: string;
    organisationName : string;
    outputTitle : string;
    annualTarget: number;
    q1: number;
    q2: number;
    q3: number;
    q4: number;
    programme: string;
    subprogrammeType: string;
    indicatorId: string;
  }

  export interface IActuals {
    id: number;
    programmeId: number;
    subProgrammeId: number;
    group: number;
    subProgrammeTypeId: number;
    serviceDeliveryArea : string;
    outputTitle : string;
    targets: number;
    financialYear: number;
    indicatorId: number;
    indicatorValue: string;
    variance: number;
    deviationReason: string;
    adjustedActual: number;
    adjustedVariance: number;
    applicationId: number;
    qaurterId: number;
    actual: number;
    documents: IDocumentStore[];
    isActive: boolean;
    statusId: number;
    status: IStatus;
  }

 
  export interface IPosts {
    id: number;
    staffCategory: IStaffCategory,
    numberOfPosts: number;
    numberFilled : number;
    monthsFilled: string;
    vacant : string;
    dateofVacancies : string;
    vacancyReasons: string;
    plans: string;
    applicationId: number;
    isActive: boolean;
    statusId: number;
    status: IStatus;
    staffCategoryId: number;
  }
    
  export interface IGovernance {
    id: number;
    lastMeetingDate: string;
    lastSubmissionDateWC : string;
    lastSubmissionDateNat:string;
    comments: string;
    applicationId: number;
    isActive: boolean;
    statusId: number;
    status: IStatus;
  }

  export interface IOtherInfor {
    id: number;
    highlights: string;
    challenges: string;
    applicationId: number;
    isActive: boolean;
    statusId: number;
    status: IStatus;
  }

  export interface IExpenditure {
    id: number;
    costDrivers: string;
    income : number;
    expenditure:number;
    surplus: number;
    total: number;
    applicationId: number;
    isActive: boolean;
    statusId: number;
    status: IStatus;
  }

  export interface ISDIP {
    id: number;
    standardPerformanceArea: string;
    correctiveAction : string;
    responsibility:string;
    targetDate: string;
    meansOfVerification: string;
    applicationId: number;
    isActive: boolean;
    progress: string;
    statusId: number;
    status: IStatus;
  }

export interface IActivity {
    id: number;
    applicationId: number;
    objectiveId: number;
    activityListId: number;
    activityTypeId: number;
    timelineStartDate: string;
    timelineEndDate: string;
    target: number;
    successIndicator: string;
    isActive: boolean;
    changesRequired: boolean;
    name: string;
    description: string;
    facilityListText: string;
    isNew: boolean;
    financialYear: string;
    quarter: string;
    objective: IObjective;
    activityType: IActivityType;
    activitySubProgrammes: IActivitySubProgramme[];
    activityList: IActivityList;
    activityFacilityLists: IActivityFacilityList[];
    activityRecipients: IActivityRecipient[];
    activityDistrict: IActivityDistrict[];
    activitySubDistrict: IActivitySubDistrict[];
    activitySubStructure: IActivitySubStructure[];
    activityManicipality: IActivityManicipality[];
    activityArea: IArea[];

    mappedDistrict?: any;
    mappedSubdistrict?: any;
    mappedSubstructure?: any;
    mappedManicipality?: any;
    mappedArea?: any;
}

export interface IActivityDistrict {
    id: number;
    demographicDistrictId: number;
    name: string;
    isActive: boolean;
    activityId: number;
}

export interface IActivityManicipality {
    id: number;
    demographicDistrictId: number;
    name: string;
    isActive: boolean;
    activityId: number;
}

export interface IActivitySubDistrict {
    id: number;
    name: string;
    substructureId: number;
    isActive: boolean;
    activityId: number;
    areaId: number;
}

export interface IActivitySubStructure {
    id: number;
    name: string;
    municipalityId: number;
    isActive: boolean;
    activityId: number;
}

export interface IAddressInformation {
    id: number;
    npoProfileId: number;
    physicalAddress: string;
    postalSameAsPhysical: boolean;
    postalAddress: string;
}

export interface ApplicationWithUsers {
    application: IApplication;
    userVM: any;
}

export interface IApplication {
    id: number;
    refNo: string;
    npoId: number;
    applicationPeriodId: number;
    statusId: number;
    step: number;
    isActive: boolean;
    isCloned: boolean;
    isQuickCapture: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;
    closeScorecard: number;
    initiateScorecard: number;
    scorecardCount: number;
    rejectedScorecard: number;
    submittedScorecard: number;
    programmeId: number;
    subProgrammeId: number;
    subProgrammeTypeId: number;
    applicationPeriod: IApplicationPeriod;
    status: IStatus;
    createdUser: IUser;
    updatedUser: IUser;
    npoUserTrackings: INpoUserTracking[];
    npoUserSatisfactionTrackings: INpoUserTracking[];
    npoWorkPlanApproverTrackings: INpoUserTracking[];
    message: string;
    npoWorkPlanReviewerTrackings: INpoUserTracking[];
}
export interface IUserSatisfactionTracking {
    id: number;
    applicationId: number;
    userId: number;
}
export interface IWorkPlanApproverTracking {
    id: number;
    applicationId: number;
    userId: number;
}
export interface INpoUserTracking {
    id: number;
    applicationId: number;
    userId: number;
}
export interface FinYear {
    id: number;
    name: string;
    next: number;
}
export interface FinYearBudget {
    id: number;
    finYear: FinYear;
    budget: number;
}

export interface Budget {
    id: number;
    description: string;
    finYear1: FinYearBudget;
    finYear2: FinYearBudget;
    finYear3: FinYearBudget;
    category: string;
}


export interface FinYear {
    id: number;
    name: string;
    next: number;
}

export interface IFinancialYear {
    id: number;
    name: string;
    year: number;
    startDate: Date;
    endDate: Date;
    isActive: boolean;
}


export interface IApplicationApproval {
    id: number;
    applicationId: number;
    statusId: number;
    approvedFrom: string;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;

    createdUser: IUser;
}

export interface IApplicationAudit {
    id: number;
    applicationId: number;
    statusId: number;
    createdUserId: number;
    createdDateTime: Date;

    status: IStatus;
    createdUser: IUser;
}

export interface IApplicationComment {
    id: number;
    applicationId: number;
    serviceProvisionStepId: number;
    entityId: number;
    comment: string;
    createdUserId: number;
    createdDateTime: Date;

    createdUser: IUser;
}

export interface IApplicationPeriod {
    id: number;
    refNo: string;
    departmentId: number;
    programmeId: number;
    subProgrammeId: number;
    subProgrammeTypeId: number;
    applicationTypeId: number;
    name: string;
    description: string;
    financialYearId: number;
    openingDate: Date;
    closingDate: Date;
    status: string;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;

    department: IDepartment;
    programme: IProgramme;
    subProgramme: ISubProgramme;
    subProgrammeType: ISubProgrammeType
    financialYear: IFinancialYear;
    applicationType: IApplicationType;
    createdUser: IUser;
    updatedUser: IUser;
}

export interface IApplicationReviewerSatisfaction {
    id: number;
    applicationId: number;
    serviceProvisionStepId: number;
    entityId: number;
    isSatisfied: boolean;
    createdUserId: number;
    createdDateTime: Date;

    createdUser: IUser;
}

export interface IContactInformation {
    id: number;
    npoId: number;
    titleId: number;
    raceId: number;
    languageId: number;
    genderId: number;
    firstName: string;
    lastName: string;
    rsaIdNumber: boolean;
    idNumber: string;
    passportNumber: string;
    emailAddress: string;
    telephone: string;
    cellphone: string;
    positionId: number;
    comments: string;
    qualifications: string;
    addressInformation: string;
    isPrimaryContact: boolean;
    isDisabled: boolean;
    isSignatory: boolean;
    isWrittenAgreementSignatory: boolean;
    isBoardMember: boolean;
    yearsOfExperience: number;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;
    dateOfEmployment: Date;
    title: ITitle;
    position: IPosition;
    gender: IGender;
    race: IRace;
    language: ILanguage;
}

export interface INpo {
    id: number;
    refNo: string;
    name: string;
    organisationTypeId: number;
    registrationNumber: string;
    yearRegistered: string;
    website: string;
    isNew: boolean;
    isActive: boolean;
    approvalStatusId: number;
    approvalUserId: number;
    approvalDateTime: Date;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;

    registrationStatusId: number;
    pboNumber: string;
    section18Receipts: boolean;
    cCode: string;

    organisationType: IOrganisationType;
    approvalStatus: IAccessStatus;
    contactInformation: IContactInformation[];
    createdUser: IUser;
    approvalUser: IUser;
    registrationStatus: IRegistrationStatus;
    updatedUser: IUser;
}

export interface INpoProfile {
    id: number;
    npoId: number;
    npoName: string;
    refNo: string;
    createdUserId: number;
    updatedUserId: number;
    approvalStatusId: number;
    addressInformation: IAddressInformation;
    accessStatus: IAccessStatus;
    /*npoProfileFacilityLists: INpoProfileFacilityList[];
    servicesRendered: IServicesRendered[];
    bankDetails: IBankDetail[];*/
    createdUser: IUser;
    createdDateTime: Date;
    updatedUser: IUser;
    updatedDateTime: Date;
}

export interface IObjective {
    id: number;
    applicationId: number;
    name: string;
    description: string;
    fundingSource: string;
    fundingPeriodStartDate: string;
    fundingPeriodEndDate: string;
    recipientTypeId: number;
    budget: number;
    isActive: boolean;
    changesRequired: boolean;
    isNew: boolean;
    financialYear: string;
    quarter: string;

    recipientType: IRecipientType;
    objectiveProgrammes: IObjectiveProgramme[];
    subRecipients: ISubRecipient[];
}


export interface IFundingApplicationDetails {
    id: number;
    applicationId: number;
    programmeId: number;
    applicationPeriodId: number;
    projectInformation: IProjectInformation;
    monitoringEvaluation: IMonitoringAndEvaluation;
    implementations: IProjectImplementation[];
    applicationPeriod: IApplicationPeriod;
    incomes: Budget[],
    expenses: Budget[],
    financialMatters: FinancialMatters[];
    applicationDetails: IApplicationDetails;
    programId: number;
    subProgramId: number;
    subProgramTypeId: number;
    //fundAppDeclaration :IFundAppDeclaration;     
}

export interface IQuickCaptureDetails {
    id: number;
    applicationId: number;
    applicationPeriodId: number;
    applicationPeriod: IApplicationPeriod;
    //applicationDetails: IApplicationDetails;  
    fundingApplicationDetails: IFundingApplicationDetails;
    npo: INpo;
}

export interface IProjectInformation {
    id: number;
    applicationId: number;
    isActive: boolean;
    changeRequired: boolean;
    isNew: boolean;
    initiatedQuestion: string;
    considerQuestion: string;
    purposeQuestion: string;
}
export interface IMonitoringAndEvaluation {
    id: number;
    applicationId: number;
    isActive: boolean;
    changeRequired: boolean;
    isNew: boolean;
    monEvalDescription: string;
    createdUserId: number;
}
export interface IResource {
    id: number;
    applicationId: number;
    activityId: number;
    resourceTypeId: number;
    serviceTypeId: number;
    allocationTypeId: number;
    name: string;
    description: string;
    provisionTypeId: number;
    resourceListId: number;
    numberOfResources: number;
    isActive: boolean;
    changesRequired: boolean;
    isNew: boolean;
    activity: IActivity;
    resourceType: IResourceType;
    serviceType: IServiceType;
    allocationType: IAllocationType;
    provisionType: IProvisionType;
    resourceList: IResourceList;
}

export interface IStatus {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

export interface ISustainabilityPlan {
    id: number;
    applicationId: number;
    activityId: number;
    description: string;
    risk: string;
    mitigation: string;
    isActive: boolean;
    changesRequired: boolean;
    isNew: boolean;
    activity: IActivity;
}

export interface ITrainingMaterial {
    id: number;
    name: string;
    description: string;
    link: string;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;
}

// export interface IServicesRendered {
//     id: number;
//     npoProfileId: number;
//     programmeId: number;
//     subProgrammeId: number;
//     subProgrammeTypeId: number;
//     isActive: boolean;

//     programme: IProgramme;
//     // selectedServiceSubProgrammeTypes: ISubProgrammeType[];			  
//     // selectedServiceSubProgrammes: ISubProgramme[];
//     subProgramme: ISubProgramme[];
//     subProgrammeType: ISubProgrammeType[];
// }

export interface IServicesRendered {
    id: number;
    npoProfileId: number;
    departmentId: number;
    programmeId: number;
    subProgrammeId: number;
    subProgrammeTypeId: number;
    isActive: boolean;
    entityTypeNumber: number;
    entitySystemNumber: number;

    department: IDepartment;
    programme: IProgramme;
    subProgramme: ISubProgramme;
    subProgrammeType: ISubProgrammeType;
}

export interface IBankDetail {
    id: number;
    npoProfileId: number;
    bankId: number;
    branchId: number;
    accountTypeId: number;
    accountNumber: string;
    isActive: boolean;
    branchCode: string;

    bank: IBank;
    branch: IBranch;
    accountType: IAccountType;
}

export interface ICompliantCycleRule {
    id: number;
    cycleNumber: number;
    isActive: boolean;
}

export interface ICompliantCycle {
    id: number;
    compliantCycleRuleId: number;
    departmentId: number;
    financialYearId: number;
    startDate: Date;
    endDate: Date;
    hasSignedTPA: boolean;
    hasProgressReport: boolean;
    hasFinancialStatement: boolean;
    isActive: boolean;
    name: string;

    financialYear: IFinancialYear;
}

export interface IPaymentSchedule {
    id: number;
    compliantCycleId: number;
    startDate: Date;
    releaseDate: Date;
    paymentDate: Date;
    isActive: boolean;

    compliantCycle: ICompliantCycle;
}

export interface IAuditorOrAffiliation {
    id: number;
    entityId: number; //Either NpoProfileId or FundingApplicationId
    entityName: string; //Either NpoProfile or FundingApplication
    entityType: string; //Either Auditor or Affiliation
    organisationName: string;
    registrationNumber: string;
    address: string;
    contactPerson: string;
    emailAddress: string;
    telephoneNumber: string;
    website: string;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;
}

export interface IStaffMemberProfile {
    id: number;
    npoProfileId: number;
    staffCategoryId: number;
    vacantPosts: number;
    filledPosts: number;
    consultantsAppointed: number;
    staffWithDisabilities: number;
    africanMale: number;
    africanFemale: number;
    indianMale: number;
    indianFemale: number;
    colouredMale: number;
    colouredFemale: number;
    whiteMale: number;
    whiteFemale: number;
    otherSpecify: string;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;

    staffCategory: IStaffCategory;
}

export interface ISubRecipient {
    id: number;
    objectiveId: number;
    organisationName: string;
    fundingPeriodStartDate: string;
    fundingPeriodEndDate: string;
    budget: number;
    recipientTypeId: number;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;

    subSubRecipients: ISubSubRecipient[];
    recipientType: IRecipientType;
}

export interface ISubSubRecipient {
    id: number;
    subRecipientId: number;
    organisationName: string;
    fundingPeriodStartDate: string;
    fundingPeriodEndDate: string;
    budget: number;
    recipientTypeId: number;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;

    recipientType: IRecipientType;
}

/* Lookup */
export interface IActivityList {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
}

export interface IndicatorReport {
    outputTitle: string;
    indicatorId: string;
    outputDescription: string;
    target: number;
    actuals: string;
    variance: string;
    deviationReason: string;
    adjustedActual: string;
    adjustedVariance: string;
    uploadedDocument: string;
  }
  

export interface IFacilityList {
    id: number;
    facilityTypeId: number;
    facilitySubDistrictId: number;
    name: string;
    facilityClassId: number;
    latitude: string;
    longitude: string;
    address: string;
    isNew: boolean;
    facilityFound: boolean;
    isActive: boolean;

    facilityType: IFacilityType;
    facilitySubDistrict: IFacilitySubDistrict;
    facilityClass: IFacilityClass;
}

export interface IResourceList {
    id: number;
    name: string;
    description: string;
    resourceTypeId: number;
    isActive: boolean;
}

export interface IAddressLookup {
    text: string;
    magicKey: string;
}

/* Mapping */
export interface IActivitySubProgramme {
    id: number;
    activityId: number;
    subProgrammeId: number;
    isActive: boolean;

    //activity: IActivity;
    subProgramme: ISubProgramme;
}

export interface INpoProfileFacilityList {
    id: number;
    npoProfileId: number;
    facilityListId: number;
    isActive: boolean;

    npoProfile: INpoProfile;
    facilityList: IFacilityList;
}

export interface IObjectiveProgramme {
    id: number;
    objectiveId: number;
    programmeId: number;
    subProgrammeId: number;
    isActive: boolean;

    programme: IProgramme;
    subProgramme: ISubProgramme;
}
export interface IUserDepartment {
    id: number;
    userId: number;
    departmentId: number;
}

export interface IUserNpo {
    id: number;
    userId: number;
    npoId: number;
    accessStatusId: number;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;

    npo: INpo;
    createdUser: IUser;
}

export interface IUserRole {
    id: number;
    userId: number;
    roleId: number;
    isActive: boolean;
}

export interface IActivityFacilityList {
    id: number;
    activityId: number;
    facilityListId: number;
    isActive: boolean;

    //activity: IActivity;
    facilityList: IFacilityList;
}

export interface IActivityRecipient {
    activityId: number;
    entity: string;
    entityId: number;
    recipientTypeId: number;
    recipientName: string;
}

/* Other */
export interface IRolePermissionMatrix {
    mappings: any[],
    availableRoles: IRole[],
    availablePermissions: IPermission[];
}

export interface IDenodoFacilityWrapper {
    name: string;
    elements: IDenodoFacility[];
}

export interface IDenodoFacility {
    name: string;
    code: string;
    datein: string;
    dateout: string;
    status_code: string;
    status: string;
    classification_id: string;
    classification: string;
    category_id: string;
    category: string;
    short_name: string;
    latitude: string;
    longitude: string;
    telno: string;
    email: string;
    contact_name: string;
    authority_id: string;
    authority: string;
    associated_facility: string;
    associated_facility_code: string;
    urban_code: string;
    urban: string;
    health_facility_short_code: string;
    date_modified: string;
    emis: string;
    dhis_uid: string;
    quintile_id: string;
    quintile_name: string;
    nat_code: string;
    tier: string;
    po_box_or_private_bag: string;
    postal_suburb_or_town: string;
    postal_code: string;
    address_type: string;
    street_number: string;
    street_name: string;
    district_id: string;
    district: string;
    district_status: string;
    sub_district_id: string;
    sub_district: string;
    suburb: string;
    town: string;
    province: string;
    street_postal_code: string;
    recordstatus_0: string;
    throughput_report_required: string;
    substruct: string;
    metro_rural: string;
    open_days: string;
    open_time: string;
}

export interface IDenodoBudgetWrapper {
    forEach(arg0: (application: any) => void): unknown;
    name: string;
    elements: IDenodoBudget[];
}

export interface IProgrammeBudgets {
    id: number;
    financialYearId: string;
    departmentId: number;
    departmentName: string;
    programmeId: number;
    programmeName: string;
    subProgrammeId: number;
    subProgrammeName: string;
    subProgrammeTypeId: number;
    subProgrammeTypeName: string;
    originalBudgetAmount: string;
    provisionalBudgetAmount: string;
    adjustedBudgetAmount: string;
    responsibilityCode: string;
    objectiveCode: string;
    isActive: number;
}

export interface IDenodoBudget {
    source: string;
    nationalprovincial: string;
    financialyear: string;
    departmentname: string;
    assetslowestlevelcode: string;
    assetslowestlevel: string;
    assetslevel1: string;
    assetslevel2: string;
    assetslevel3: string;
    assetslevel4: string;
    assetslevel5: string;
    assetslevel6: string;
    assetslevel7: string;
    assetslevel8: string;
    assetslevel9: string;
    assetslevel10: string;
    econclass: string;
    inconsistenteconclass: string;
    funcclasslevel1: string;
    funcclasslevel2: string;
    funcclasslowestlevel: string;
    fundlowestlevelcode: string;
    fundlowestlevel: string;
    fundlevel1: string;
    fundlevel2: string;
    fundlevel3: string;
    fundlevel4: string;
    fundlevel5: string;
    fundlevel6: string;
    fundlevel7: string;
    fundlevel8: string;
    fundlevel9: string;
    ictitem: string;
    ictresp: string;
    infrastructurelowestlevelcode: string;
    infrastructurelowestlevel: string;
    infrastructurelevel1: string;
    infrastructurelevel2: string;
    infrastructurelevel3: string;
    infrastructurelevel4: string;
    infrastructurelevel5: string;
    infrastructurelevel6: string;
    itemlowestlevelcode: string;
    itemlowestlevel: string;
    itemlevel1: string;
    itemlevel2: string;
    itemlevel3: string;
    itemlevel4: string;
    itemlevel5: string;
    itemlevel6: string;
    itemlevel7: string;
    itemlevel8: string;
    itemlevel9: string;
    itemlevel10: string;
    itemlevel11: string;
    programmelevel5: string;
    subprogrammelevel6: string;
    objectivelowestlevelcode: string;
    objectivelowestlevel: string;
    objectivelevel1: string;
    objectivelevel2: string;
    objectivelevel3: string;
    objectivelevel4: string;
    objectivelevel5: string;
    objectivelevel6: string;
    objectivelevel7: string;
    objectivelevel8: string;
    objectivelevel9: string;
    objectivelevel10: string;
    projectlowestlevelcode: string;
    projectlowestlevel: string;
    projectlevel1: string;
    projectlevel2: string;
    projectlevel3: string;
    projectlevel4: string;
    projectlevel5: string;
    projectlevel6: string;
    projectlevel7: string;
    projectlevel8: string;
    projectlevel9: string;
    projectlevel10: string;
    projectlevel11: string;
    regionalidlowestlevelcode: string;
    regionalidlowestlevel: string;
    regionalidlevel1: string;
    regionalidlevel2: string;
    regionalidlevel3: string;
    regionalidlevel4: string;
    regionalidlevel5: string;
    regionalidlevel6: string;
    regionalidlevel7: string;
    regionalidlevel8: string;
    researchanddevcode: string;
    researchanddevclassification: string;
    responsibilitylowestlevelcode: string;
    responsibilitylowestlevel: string;
    responsibilitylevel1: string;
    responsibilitylevel2: string;
    responsibilitylevel3: string;
    responsibilitylevel4: string;
    responsibilitylevel5: string;
    responsibilitylevel6: string;
    responsibilitylevel7: string;
    responsibilitylevel8: string;
    responsibilitylevel9: string;
    responsibilitylevel10: string;
    responsibilitylevel11: string;
    responsibilitylevel12: string;
    responsibilitylevel13: string;
    responsibilitylevel14: string;
    responsibilitylevel15: string;
    sonoprogramnumber: string;
    sonosubprogrevcode: string;
    originalbudget: string;
    availablebudget: string;
    currentbudget: string;
    commitment: string;
    virement: string;
    finalvirementshifts: string;
    fundshift: string;
    rollover: string;
    programme: string;
    subProgramme: string;
    subProgrammeType: string;
}

export interface ISegmentCode {
    id: number;
    programmeId: number;
    responsibilityCode: string;
    subProgrammeTypeId: number;
    objectiveCode: string;
}

export interface IBudgetAdjustment {
    id: number;
    programmeId: number;
    responsibilityCode: string;
    subProgrammeTypeId: number;
    objectiveCode: string;
    amount: string;
}

/* Indicator */
export interface IWorkplanTarget {
    id: number;
    activityId: number;
    financialYearId: number;
    frequencyId: number;
    annual: number;
    apr: number;
    may: number;
    jun: number;
    jul: number;
    aug: number;
    sep: number;
    oct: number;
    nov: number;
    dec: number;
    jan: number;
    feb: number;
    mar: number;
    quarter1: number;
    quarter2: number;
    quarter3: number;
    quarter4: number;

    frequency: IFrequency;
}

export interface IWorkplanActual {
    id: number;
    activityId: number;
    financialYearId: number;
    frequencyPeriodId: number;
    statusId: number;
    actual: number;
    statement: string;
    deviationReason: string;
    action: string;
    workplanTargetId: number;

    isUpdated: boolean;
    documents: IDocumentStore[];
    frequencyPeriod: IFrequencyPeriod;
    status: IStatus;
    isSubmitted: boolean; // Used for enabling/disabling fields
}

export interface IWorkplanIndicator {
    activity: IActivity;
    workplanTargets: IWorkplanTarget[];
    workplanActuals: IWorkplanActual[];
    totalTargets: number;
    totalActuals: number;
    targetMet: boolean;
    totalAvg: number;
    attentionRequired: boolean;
}

export interface IWorkplanIndicatorSummary {
    activity: IActivity;
    workplanTargets: IWorkplanTarget[];
    workplanActuals: IWorkplanActual[];
    totalTargets: number;
    totalActuals: number;
    objectiveTargets: number;
    objectiveActuals: number;
    targetMet: boolean;
    totalAvg: number;
    objectiveId: number;
    ObjectiveName: string;
    attentionRequired: boolean;
}

export interface IWorkplanComment {
    id: number;
    workplanActualId: number;
    comment: string;
    createdUserId: number;
    createdDateTime: Date;

    createdUser: IUser;
}

export interface IWorkplanActualAudit {
    id: number;
    workplanActualId: number;
    statusId: number;
    createdUserId: number;
    createdDateTime: Date;

    status: IStatus;
    createdUser: IUser;
}

/* Budget */
export interface IDepartmentBudget {
    id: number;
    departmentId: number;
    financialYearId: number;
    amount: number;
    isActive: boolean;

    financialYear: IFinancialYear;
}

export interface IDirectorateBudget {
    id: number;
    departmentId: number;
    financialYearId: number;
    departmentBudgetId: number;
    directorateId: number;
    amount: number;
    description: string;
    isActive: boolean;

    financialYear: IFinancialYear;
    directorate: IDirectorate;
}

export interface IProgrammeBudget {
    id: number;
    departmentId: number;
    financialYearId: number;
    directorateBudgetId: number;
    programmeId: number;
    amount: number;
    description: string;
    isActive: boolean;

    financialYear: IFinancialYear;
    directorate: IDirectorate;
    programme: IProgramme;
}

//FundingApplicationDetail
export interface IDistrictCouncil {
    id: number;
    name: string;
}

export interface ILocalMunicipality {
    id: number;
    districtCouncilId: number;
    name: string;
}

export interface IRegion {
    id: number;
    isActive: boolean;
    localMunicipalityId: number;
    name: string;
}

export interface IApplicationDetails {
    id: number;
    applicationId: number;
    amountApplyingFor: number;
    isSDASelected: boolean;
    programmeSDId: number;
    fundAppSDADetailId: number;
    fundAppSDADetail: IFundAppSDADetail;

}

export interface IFundAppSDADetail {
    id: number;
    districtCouncil: IDistrictCouncil;
    localMunicipality: ILocalMunicipality;
    regions: IRegion[];
    region: IRegion;
    serviceDeliveryAreas: ISDA[];
    serviceDeliveryArea: ISDA;
}

export interface ISubPlace {
    placeId: number;
    id: number;
    name: string;
    isActive: boolean;
}

export interface IPlace {
    id: number;
    name: string;
    serviceDeliveryAreaId: number;
    isActive: boolean;
}
export interface ISDA {
    id: number;
    name: string;
    isActive: boolean;
    regionId: number;
}
// export interface ILocalMunicipality {
//     id: number;
//     name: string;
//     districtCouncilId: number;
// }

export interface IDistrictCouncil {
    id: number;
    name: string;
}

export interface IProjectInformation {
    applicationId: number;
    isNew: boolean;
    isActive: boolean;
    purposeQuestion: string;
    createdUserId: number;
}

export interface Budget {
    id: number;
    description: string;
    finYear1: FinYearBudget;
    finYear2: FinYearBudget;
    finYear3: FinYearBudget;
    category: string;
}

export interface IProjectImplementation {
    id: number;
    description: string;
    projectObjective: string;
    beneficiaries: number;
    timeframe: Date[];
    timeframeFrom: string;
    timeframeTo: string;
    places: IPlace[];
    subPlaces: ISubPlace[];
    results: string;
    resources: string;
    budget: number;
    fundingApplicationDetailId;
    npoProfileId: number;
    applicationId: number;
}

export interface IFundAppDeclaration {
    id: number;
    applicationId: number;
    comments: string;
    statusId: number;
    isActive: boolean;
    createdDateTime: Date;
    declarationType: string;

    acceptDeclaration: boolean;
    createdUser: IUser;
    status: IStatus;
    createdUserId: number;
}

/* Evaluation */
export interface IQuestionCategory {
    id: number;
    fundingTemplateTypeId: number;
    name: string;
    isActive: boolean;

    fundingTemplateType: IFundingTemplateType;
}

export interface IQuestionSection {
    id: number;
    questionCategoryId: number;
    name: string;
    sortOrder: number;
    isActive: boolean;

    questionCategory: IQuestionCategory;
}

export interface IQuestion {
    id: number;
    questionSectionId: number;
    responseTypeId: number;
    name: string;
    sortOrder: number;
    isActive: boolean;

    questionSection: IQuestionSection;
    responseType: IResponseType;
    questionProperty: IQuestionProperty;
}

export interface IQuestionProperty {
    id: number;
    questionId: number;
    hasComment: boolean;
    commentRequired: boolean;
    hasDocument: boolean;
    documentRequired: boolean;
    weighting: number;
}
export interface IResponseType {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
}

export interface IFundingTemplateType {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
}

export interface IResponseOption {
    id: number;
    responseTypeId: number;
    name: string;
    systemName: string;
    isActive: boolean;
    rejectionComment: boolean;
    responseType: IResponseType;
    createdUserId: number;
}

export interface IWorkflowAssessment {
    id: number;
    questionCategoryId: number;
    numberOfAssessments: number;
    isActive: boolean;

    questionCategory: IQuestionCategory;
}

export interface ICapturedResponse {
    id: number;
    fundingApplicationId: number;
    questionCategoryId: number;
    statusId: number;
    comments: string;
    reviewerComment: string;
    reviewerUserId: number;
    isActive: boolean;
    isSignedOff: boolean;
    disableFlag: number;
    isDeclarationAccepted: boolean;
    createdDateTime: Date;
    selectedStatus: number;
    createdUser: IUser;
    questionnaires: IQuestionResponseViewModel[];
}

export interface IResponse {
    id: number;
    fundingApplicationId: number;
    questionId: number;
    responseOptionId: number;
    comment: string;
    reviewerCategoryComment: string;
    createdUserId: number;
}

export interface IQuestionResponseViewModel {
    questionCategoryId: number;
    questionCategoryName: string;
    questionSectionId: number;
    questionSectionName: string;
    responseTypeId: number;
    questionId: number;
    questionName: string;
    questionSortOrder: number;

    hasComment: boolean;
    commentRequired: boolean;
    hasDocument: boolean;
    documentRequired: boolean;
    weighting: number;
    averageScore: number;

    responseId: number;
    fundingApplicationId: number;
    responseOptionId: number;
    comment: string;
    rejectionComment: string;
    rejectionFlag: number;
    reviewerCategoryComment: string;
    isSaved: boolean;
    createdUserId: number;
    responseOption: IResponseOption;
    responsesO: number[];
    sumOfResponse: number;
}

export interface IResponseOptions {
    id: number;
    fundingApplicationId: number;
    questionId: number;
    responseOptionId: number;
    comment: string;
    rejectionComment: string;
    rejectedByUserId: number;
    rejectionFlag: number;
    createdUserId: number;
    responseOption: IResponseOption;
}

export interface IGetResponseOptions {
    id: number;
    fundingApplicationId: number;
    questionId: number;
    responseOptionId: number;
    comment: string;
    rejectionComment: string;
    createdUserId: number;
    rejectedByUserId: number;
    reviewerUpdatedDateTime: string;
    responseOption: IResponseOption;
    createdUser: IUser;
}

export interface IGetResponseOption {
    id: number;
    fundingApplicationId: number;
    questionId: number;
    responseOptionId: number;
    responseOptionName: number;
    comment: string;
    initialComment: string;
    rejectionComment: string;
    createdUserId: number;
    rejectedByUserId: number;
    rejectedByUser: string;
    mainReviewerCategoryComment: string;
    reviewerCategoryComment: string;
    responseOption: IResponseOption;
    createdUser: IUser;
}

export interface IResponseHistory {
    id: number;
    fundingApplicationId: number;
    questionId: number;
    responseOptionId: number;
    comment: string;
    createdUserId: number;
}

//export interface IBudget {
//    id: number;
//    fundingApplicationId: number;
//    budgetItem: string;
//    description: string;
//    dedatFundingAmount: number;
//    ownFundingAmount: number;
//    otherFundingAmount: number;
//    totalProjectFundingAmount: number;
//    orderOfPriority: number;
//    requirementDescription: string;
//    projectBackground: string;
//    motivationForDEDATSupport: string;
//    createdDateTime: Date;
//    internalExternalFundingUtilised: string;
//}

//export interface IFoundationalEnergyStudy {
//    id: number;
//    name: string;
//    description: string;
//    isActive: boolean;

//    optionDisabled: boolean;
//}

export interface IMyContentLink {
    id: number;
    applicationId: number;
    documentTypeId: number;
    url: string;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;

    documentType: IDocumentType;
    createdUser: IUser;
}


/* Funding Management */
export interface INpoViewModel {
    id: number;
    refNo: string;
    name: string;
    cCode: string;
    organisationTypeId: number;
    organisationTypeName: string;
    isActive: boolean;
    npoProfileId: number;

    fundingCaptureViewModels: IFundingCaptureViewModel[];
}

export interface IFundingCaptureViewModel {
    id: number;
    refNo: string;
    npoId: number;
    financialYearId: number;
    financialYearName: string;
    statusId: number;
    statusName: string;
    isActive: boolean;

    approverComment: string;
    approverUserId: number;
    approverUserName: string;
    approvedDateTime: Date;
    approvedDate: string;

    fundingDetailViewModel: IFundingDetailViewModel;
    sdaViewModel: ISDAViewModel;
    paymentScheduleViewModel: IPaymentScheduleViewModel;
    bankDetailViewModel: IBankDetailViewModel;
    documentViewModel: IDocumentViewModel;
}

export interface IFundingDetailViewModel {
    id: number;
    fundingCaptureId: number;
    financialYearId: number;
    financialYearName: string;
    financialYearStartDate: Date;
    financialYearEndDate: Date;
    startDate: string;
    fundingTypeId: number;
    fundingTypeName: string;
    frequencyId: number;
    frequencyName: string;
    allowVariableFunding: boolean;
    allowClaims: boolean;
    programmeId: number;
    programmeName: string;
    subProgrammeId: number;
    subProgrammeName: string;
    subProgrammeTypeId: number;
    subProgrammeTypeName: string;
    amountAwarded: number;
    calculationTypeId: number;
    calculationTypeName: string;
    isActive: boolean;
    programmeBudget: number;
}

export interface ISDAViewModel {
    id: number;
    fundingCaptureId: number;
    serviceDeliveryAreaId: number;
    serviceDeliveryAreaName: string;
    placeId: number;
    placeName: string;
    isActive: boolean;
}

export interface IPaymentScheduleViewModel {
    id: number;
    fundingCaptureId: number;
    allocatedAmountTotal: string;
    approvedAmountTotal: string;
    paidAmountTotal: string;
    allocatedAmountBalance: string;
    approvedAmountBalance: string;
    paidAmountBalance: string;
    isActive: boolean;

    paymentScheduleItemViewModels: IPaymentScheduleItemViewModel[];
}

export interface IPaymentScheduleItemViewModel {
    id: number;
    paymentScheduleId: number;
    compliantCycleId: number;
    cycleNumber: number;
    paymentDate: string;
    paymentStatus: string;
    allocatedAmount: string;
    approvedAmount: string;
    paidAmount: string;
    isActive: boolean;
}

export interface IBankDetailViewModel {
    id: number;
    fundingCaptureId: number;
    programBankDetailsId: number;
    bankName: string;
    branchName: string;
    accountTypeName: string;
    accountNumber: string;
    isActive: boolean;
}

export interface IDocumentViewModel {
    id: number;
    fundingCaptureId: number;
    tpaLink: string;
    isActive: boolean;
}