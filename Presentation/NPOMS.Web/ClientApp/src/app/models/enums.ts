export enum AccessStatusEnum {
    AllStatuses = 0,
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    New = 4
}

export enum QuestionCategoryEnum {
    PreEvaluation,
    Adjudication,
    Evaluation,
    Approval,
    Engagement,
    TimelyWorkPlanSubmission,
    Impact,
    RiskMitigation,
    AppropriationofResources,
    Adjudication2
}

export enum ApplicationTypeEnum {
    FA = 1,
    SP = 2,
    QC = 3,
    BP = 4
}

export enum DocumentTypeEnum {
    SLA = 1,
    SignedSLA = 2
}

export enum DropdownTypeEnum {
    Roles = 1,
    Departments = 2,
    OrganisationTypes = 3,
    Titles = 4,
    Positions = 5,
    AccessStatuses = 6,
    Programmes = 7,
    SubProgramme = 8,
    FinancialYears = 9,
    ApplicationTypes = 10,
    RecipientTypes = 11,
    ActivityTypes = 12,
    ResourceTypes = 13,
    ServiceTypes = 14,
    AllocationTypes = 15,
    FacilityDistricts = 16,
    FacilitySubDistricts = 17,
    FacilityClasses = 18,
    FacilityList = 19,
    DocumentTypes = 20,
    FacilityTypes = 21,
    Statuses = 22,
    ActivityList = 23,
    ResourceList = 24,
    ProvisionTypes = 25,
    Utilities = 26,
    TrainingMaterial = 27,
    Frequencies = 28,
    FrequencyPeriods = 29,
    SubProgrammeTypes = 30,
    Directorates = 31,
    Banks = 32,
    Branches = 33,
    AccountTypes = 34,
    CompliantCycleRules = 35,
    DistrictCouncil = 36,
    LocalMunicipality = 37,
    Region = 38,
    ServiceDeliveryArea = 39,
    PropertyType = 40,
    PropertySubType = 41,
    Places = 42,
    SubPlaces = 43,
    Race = 44,
    Gender = 45,
    Languages = 46,
    RegistrationStatus = 47,
    StaffCategory = 48,
    FundingTemplateType = 49,
    QuestionCategory = 50,
    QuestionSection = 51,
    ResponseType = 52,
    Question = 53,
    ResponseOption = 54,
    WorkflowAssessment = 55,
    QuarterlyPeriod = 56,
    FilteredProgrammesByDepartment = 57,
    FilteredRolesByDepartment = 58,
    SegmentCode = 59,
    FacilitySubStructure = 60,
    DemographicSubStructure = 61,
    DemographicDistrict = 62,
    DemographicManicipality = 63,
    DemographicSubDistrict = 64,
    Area=65,
    Indicator = 66,
    HighLevelNPO = 67,
}

export enum EntityTypeEnum {
    SupportingDocuments = 1,
    SLA = 2,
    WorkplanActuals = 3,
    ReportActuals = 4,
}

export enum EntityEnum {
    NpoProfile = 'NpoProfile',
    Application = 'Application',
    WorkplanIndicators = 'WorkplanIndicators',
    FundingApplicationDetails = 'FundingApplicationDetails',
    FundedNpo = 'FundedNpo',
    IndicatorReports = 'IndicatorReports'
}

export enum ResponseTypeEnum {
    CloseEnded = 2,
    Score = 3,
    CloseEnded2 = 4,
    CloseEnded3 = 5,
    CloseEnded4 = 6,
    Score2 = 7,
    Score3 = 8
}

export enum DeclarationTypeEnum {
    Bidders1 = "Bidders 1",
    Bidders2 = "Bidders 2",
    Bidders3 = "Bidders 3",
    Bidders4 = "Bidders 4"
}

export enum FacilityTypeEnum {
    Facility = 1,
    Community = 2
}

export enum RoleEnum {
    SystemAdmin = 1,
    Admin = 2,
    Applicant = 3,
    Reviewer = 4,
    MainReviewer = 5,
    PreEvaluator = 6,
    Evaluator = 7,
    Adjudicator = 8,
    Approver = 9,
    ViewOnly = 10,
    ProgrammeCapturer = 11,
    ProgrammeApprover = 12,
    ProgrammeViewOnly = 13,
    DOHApprover = 15
}

export enum ServiceProvisionStepsEnum {
    NpoConfirmation = 0,
    Objectives = 1,
    Activities = 2,
    Sustainability = 3,
    Resourcing = 4,
    ApplicationConfirmation = 5,
    OverallWorkplan = 6
}

export enum NPOReportingStepsEnum {
    IndicatorReport = 0,
    PostReport = 1,
    DetailsOfIncomeAndAndExpenditure = 2,
    Governance = 3,
    AnyOtherInformation = 4,
    QuarterlySDIP = 5,

}

export enum StatusEnum {
    // New = 1,
    // Saved = 2,
    // PendingReview = 3,
    // AmendmentsRequired = 4,
    // PendingApproval = 5,
    // Rejected = 6,
    // PendingSLA = 7,
    // PendingSignedSLA = 8,
    // AcceptedSLA = 9,
    // ApprovalInProgress = 10,
    // DeptComments = 11,
    // OrgComments = 12,
    // InProgress = 13,
    // Approved = 14,
    // Reviewed = 15,
    // Cancelled = 16,
    // OnHold = 17,
    // Declined = 18,
    // ConditionalAccepted = 19,
    // StronglyRecommended = 20,
    // EvaluationDecline = 21,
    // Evaluated = 22,
    // EvaluationApproved = 23,
    // Submitted = 24,
    // Pending = 23,
    // Verified = 24,
    // PreEvaluationInProgress = 25,
    // PreEvaluated = 26,
    // EvaluationInProgress = 27,
    // EvaluationRecommended = 28,
    // EvaluationNotRecommended = 29,
    // AdjudicationInProgress = 30,
    // AdjudicationApproved = 31,
    // AdjudicationNotApproved = 32,
    // Adjudicated = 33,
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
    Verified = 14,
    Evaluated = 15,
    EvaluationInProgress = 16,
    AdjudicationInProgress = 17,
    Adjudicated = 18,
    Submitted = 19,
    Recommended = 20,
    StronglyRecommended = 21,
    NonCompliance = 22,
    PendingReviewerSatisfaction = 23
}

export enum AuditorOrAffiliationEntityTypeEnum {
    Auditor = "Auditor",
    Affiliation = "Affiliation"
}

export enum AuditorOrAffiliationEntityNameEnum {
    NpoProfile = "NpoProfile",
    FundingApplication = "FundingApplication"
}

export enum PermissionsEnum {
    //This needs to be mapped in the permission table as well.

    /* TOP NAVIGATION */
    ViewAdminMenu = "TN.VAM",
    ViewProfileMenu = "TN.VPM",
    ViewApplyForAccessMenu = "TN.VAAM",
    ViewAccessReviewMenu = "TN.VARM",
    ViewNpoMenu = "TN.VNM",
    ViewApplicationPeriodMenu = "TN.VAPM",
    ViewApplicationMenu = "TN.VAppM",
    ViewNpoApprovalMenu = "TN.VNA",
    ViewDashboardMenu = "TN.VDM",
    ViewTrainingMenu = "TN.VTM",
    ViewFundingMenu = "TN.VFM",
    ViewFundingCaptureMenu = "TN.VFCM",

    /* USER ADMINISTRATION */
    AddUsers = "UA.AU",
    ViewUsers = "UA.VU",
    EditUsers = "UA.EU",
    ShowUserActions = "UA.SUA",

    /* UTILITIES MANAGEMENT */
    AddUtilities = "UM.AU",
    ViewUtilities = "UM.VU",
    EditUtilities = "UM.EU",
    ShowUtilitiesActions = "UM.SUA",

    /* PERMISSION MANAGEMENT */
    ViewPermissions = "PM.VP",
    EditPermissions = "PM.EP",

    /* NPO PROFILE */
    AddNpoProfile = "NP.ANP",
    EditNpoProfile = "NP.ENP",
    ViewNpoProfiles = "NP.VNP",
    ShowProfileActions = "NP.SPA",

    /* USER ACCESS MANAGEMENT */
    AddUserRequests = "UAM.AUR",
    EditUserRequests = "UAM.EUR",
    ViewUserRequests = "UAM.VUR",

    /* NPO */
    AddNpo = "NPO.Add",
    EditNpo = "NPO.Edit",
    ViewNpo = "NPO.View",
    ShowNpoActions = "NPO.SNA",

    /* APPLICATION PERIOD (Programme Selection) */
    AddApplicationPeriod = "AP.Add",
    EditApplicationPeriod = "AP.Edit",
    ViewApplicationPeriods = "AP.View",
    ShowApplicationPeriodActions = "AP.SAPA",

    /* APPLICATION */
    AddApplication = "App.Add",
    EditApplication = "App.Edit",
    ViewApplications = "App.View",
    ShowApplicationActions = "App.SAA",
    ReviewApplication = "App.Review",
    ApproveApplication = "App.Approve",
    UploadSLA = "App.Upload",
    ViewAcceptedApplication = "App.VAA",
    UpdateApplicationProgramme = "App.UAP",

    /* NPO APPROVAL MANAGEMENT */
    EditNpoRequests = "NAM.ENR",
    ViewNpoRequests = "NAM.VNR",

    /* PowerBi Dashboard */
    ViewDashboard = "PBI.VD",

    /* Training Material */
    ViewTrainingMaterial = "TM.VTM",

    /* BUDGETS */
    AddDepartmentBudget = "Bud.Add",
    EditDepartmentBudget = "Bud.Edit",
    ViewDepartmentBudget = "Bud.View",
    AddDirectorateBudget = "Bud.ADB",
    EditDirectorateBudget = "Bud.EDB",
    ViewDirectorateBudget = "Bud.VDB",
    AddProgrammeBudget = "Bud.APB",
    EditProgrammeBudget = "Bud.EPB",
    ViewProgrammeBudget = "Bud.VPB",
    ViewBudgetSummary = "Bud.VBS",
    UploadBudget = "Bud.UB",

    //Program
    ApproveProgram = "Programme.Edit",
    EditProgram = "Programme.Approve",
    ViewProgram = "Programme.Viewer",

    /* Side Navigation */
    ViewSecurityMenu = "SN.Security",
    ViewUsersSubMenu = "SN.Users",
    ViewPermissionsSubMenu = "SN.Permissions",

    ViewSettingsMenu = "SN.Settings",
    ViewUtilitiesSubMenu = "SN.Utilities",
    ViewCompliantCycleSubMenu = "SN.CompliantCycle",
    ViewPaymentScheduleSubMenu = "SN.PaymentSchedule",

    ViewBudgetsMenu = "SN.Budgets",
    ViewDepartmentBudgetSubMenu = "SN.DeptBudget",
    ViewDirectorateBudgetSubMenu = "SN.DirectorateBudget",
    ViewProgrammeBudgetSubMenu = "SN.ProgBudget",
    ViewBudgetSummarySubMenu = "SN.BudgetSummary",

    /* Funding */
    AddNpoFunding = "Fund.ANF",
    EditNpoFunding = "Fund.ENF",
    ViewNpoFunding = "Fund.VNF",
    DeleteNpoFunding = "Fund.DNF",
    ViewPaymentSchedule = "Fund.VPS",
    ComplianceCheck = "Fund.CC",
    ShowNpoFundingActions = "Fund.SNFA",

    /* Compliant Cycle */
    AddCompliantCycles = "CC.Add",
    ViewCompliantCycles = "CC.View",
    EditCompliantCycles = "CC.Edit",
    DeleteCompliantCycles = "CC.Delete",

    /* Payment Schedule */
    AddPaymentSchedules = "PS.Add",
    ViewPaymentSchedules = "PS.View",
    EditPaymentSchedules = "PS.Edit",
    DeletePaymentSchedules = "PS.Delete",

    /* Workplan Indicators */
    ViewOptions = "Indicators.Options",

    ViewManageIndicatorsOption = "Indicators.Manage",
    CaptureWorkplanTarget = "Indicators.CaptureTarget",
    ShowWorkplanTargetActions = "Indicators.SWTA",

    CaptureWorkplanActual = "Indicators.CaptureActual",
    ReviewWorkplanActual = "Indicators.ReviewActual",
    ApproveWorkplanActual = "Indicators.ApproveActual",

    ViewSummaryOption = "Indicators.Summary",
    ExportSummary = "Indicators.ExportSummary",

    /* Workflow Action */
    ViewOption = "WFA.View",
    EditOption = "WFA.Edit",
    DownloadOption = "WFA.Download",
    DownloadAssessmentOption = "WFA.DownloadAssessment",
    DeleteOption = "WFA.Delete",

    PendingPreEvaluateOption = "WFA.PendingPreEvaluation",
    PreEvaluateOption = "WFA.PreEvaluate",
    PendingAdjudicateOption = "WFA.PendingAdjudication",
    AdjudicateOption = "WFA.Adjudicate",
    PendingEvaluationOption = "WFA.PendingEvaluation",
    EvaluateOption = "WFA.Evaluate",
    PendingApprovalOption = "WFA.PendingApproval",
    ApproveOption = "WFA.Approve",
    AddScorecard = "WFA.AddScorecard",
    ReviewScorecard = "WFA.ReviewScorecard",
    ViewScorecard = "WFA.ViewScorecard",
    InitiateScorecard = "WFA.InitiateScorecard",
    CloseScorecard = "WFA.CloseScorecard",
    AdjudicateFundedNpo = "WFA.AdjudicateFundedNpo",
    ReviewAdjudicatedFundedNpo = "WFA.ReviewAdjudicatedFundedNpo",

    /* Quick Capture*/
    ViewQC = "QC.View",
    EditQC = "QC.Edit",
    DownloadQC = "QC.Download",

    /* Funding Capture */
    AddFundingCapture = "FC.Add",
    EditFundingCapture = "FC.Edit",
    ViewFundingCapture = "FC.View",
    ApproveFundingCapture = "FC.Approve",
    DownloadFundingCapture = "FC.Download",
    ShowFundingCaptureActions = "FC.SFCA",
    DeleteFundingCapture = "FC.Delete"
}

export enum ReportTypeEnum {
    PowerBIDashboard = 1
}

export enum FrequencyEnum {
    Annually = 1,
    Monthly = 2,
    Quarterly = 3,
    Adhoc = 4
}

export enum FrequencyPeriodEnum {
    Annual = 1,
    Apr = 2,
    May = 3,
    Jun = 4,
    Jul = 5,
    Aug = 6,
    Sep = 7,
    Oct = 8,
    Nov = 9,
    Dec = 10,
    Jan = 11,
    Feb = 12,
    Mar = 13,
    Q1 = 14,
    Q2 = 15,
    Q3 = 16,
    Q4 = 17
}

export enum DepartmentEnum {
    ALL = 1,
    DEDAT = 2,
    WCMD = 3,
    WCED = 4,
    DOTP = 5,
    PT = 6,
    DSD = 7,
    DOA = 8,
    DOCS = 9,
    DCAS = 10,
    DOH = 11,
    DOI = 12,
    DLG = 13,
    WCPP = 14,
    DEADP = 15,
    NONE = 16
}

export enum FundingStepsEnum {
    FundingDetail = 0,
    ServiceDeliveryArea = 1,
    PaymentSchedule = 2,
    BankDetails = 3,
    Documents = 4
}

export enum FundingApplicationStepsEnum {
    NpoConfirmationDetails = 0,
    AmountYouApplyingFor = 1,
    FinancialMatters = 2,
    ProjectInformation = 3,
    Monitoring_And_Evaluation = 4,
    ProjectImplementationPlan = 5,
    ApplicationDocument = 6,
    Declaration = 7
}

export enum QuickCaptureStepsEnum {
    NpoConfirmationDetails = 0,
    AmountYouApplyingFor = 1,
    ApplicationDocument = 2
}

export enum QCStepsEnum {
    Applications = 0,
    NpoCreate = 1,   
    AmountYouApplyingFor = 2,
    ApplicationDocument = 3
}

export enum QuickCaptureFundedStepsEnum {
    NpoConfirmationDetails = 0,
    Applications = 1,
    Objectives = 2,
    Activities = 3,
    ApplicationDocument = 4
}

export enum QCStepsFundedEnum {
    Applications = 0,
    NpoCreate = 1,
    ApplicationDetail = 2,
    Objectives = 3,
    Activities = 4,
    ApplicationFundedDocument = 5,
    ApplicationConfirmation = 6
}


export enum DocumentUploadLocationsEnum {
    NpoProfile = 'NpoProfile',
    Workplan = 'Workplan',
    WorkplanActuals = 'WorkplanActuals',
    FundApp = "FundApp",
    QuickCapture = "QuickCapture",
    FundedNpo = "FundedNpo",
    ReportActuals = "ReportActuals"
}

//export enum FundingTemplateTypeEnum {
//    BoosterFundTemplate = 1,
//    EnergyFundTemplate = 2
//}

//export enum FoundationalEnergyStudiesEnum {
//    UpdatingOfElectricity = 1,
//    DevelopmentForNERSAApproval = 2,
//    MiniIRPsForMunicipality = 3,
//    OtherRenewableEnergy = 4
//}

export enum StaffCategoryEnum {
    Managers = 1,
    ProfessionalStaff = 2,
    AdminSupport = 3,
    PartTimeStaff = 4,
    Volunteers = 5,
    Other = 6
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
    responsesO: number[];
    sumOfResponse: number;
    responseOption: IResponseOption;
}

export interface IResponseType {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
}

export interface IResponseOption {
    id: number;
    responseTypeId: number;
    name: string;
    systemName: string;
    isActive: boolean;

    responseType: IResponseType;
}

export interface IResponses {
    id: number;
    fundingApplicationId: number;
    questionId: number;
    responseOptionId: number;
    comment: string;
    responseOption: IResponseOption;
}

export interface IResponseHistory {
    id: number;
    fundingApplicationId: number;
    questionId: number;
    responseOptionId: number;
    comment: string;
}

export enum RecipientTypeEnum {
    Primary = 1,
    SubRecipient = 2,
    SubSubRecipient = 3
}

export enum RecipientEntityEnum {
    Objective = 'Objective',
    SubRecipient = 'SubRecipient',
    SubSubRecipient = 'SubSubRecipient'
}

export enum FundingCaptureStepsEnum {
    Funding = 0,
    SDA = 1,
    PaymentSchedule = 2,
    BankDetail = 3,
    Document = 4
}

export enum FundingTypeEnum {
    Adhoc = 1,
    Annual = 2
}

export enum CalculationTypeEnum {
    Detailed = 1,
    Summary = 2
}