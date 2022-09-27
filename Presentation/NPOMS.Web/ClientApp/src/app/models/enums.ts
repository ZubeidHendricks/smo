export enum AccessStatusEnum {
    AllStatuses = 0,
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    New = 4
}

export enum ApplicationTypeEnum {
    FA = 1,
    SP = 2
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
    AccountTypes = 34
}

export enum EntityTypeEnum {
    SupportingDocuments = 1,
    SLA = 2,
    WorkplanActuals = 3
}

export enum EntityEnum {
    NpoProfile = 'NpoProfile',
    Application = 'Application',
    WorkplanIndicators = 'WorkplanIndicators'
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
    Approver = 6
}

export enum ServiceProvisionStepsEnum {
    NpoConfirmation = 0,
    Objectives = 1,
    Activities = 2,
    Sustainability = 3,
    Resourcing = 4,
    ApplicationConfirmation = 5
}

export enum StatusEnum {
    New = 1,
    Saved = 2,
    PendingReview = 3,
    AmendmentsRequired = 4,
    PendingApproval = 5,
    Rejected = 6,
    PendingSLA = 7,
    PendingSignedSLA = 8,
    AcceptedSLA = 9,
    ApprovalInProgress = 10,
    DeptComments = 11,
    OrgComments = 12
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

    /* Side Navigation */
    ViewSecurityMenu = "SN.Security",
    ViewUsersSubMenu = "SN.Users",
    ViewPermissionsSubMenu = "SN.Permissions",

    ViewSettingsMenu = "SN.Settings",
    ViewUtilitiesSubMenu = "SN.Utilities",

    ViewBudgetsMenu = "SN.Budgets",
    ViewDepartmentBudgetSubMenu = "SN.DeptBudget",
    ViewDirectorateBudgetSubMenu = "SN.DirectorateBudget",
    ViewProgrammeBudgetSubMenu = "SN.ProgBudget",

    /* Funding */
    AddNpoFunding = "Fund.ANF",
    EditNpoFunding = "Fund.ENF",
    ViewNpoFunding = "Fund.VNF",
    DeleteNpoFunding = "Fund.DNF",
    ViewPaymentSchedule = "Fund.VPS",
    ComplianceCheck = "Fund.CC",
    ShowNpoFundingActions = "Fund.SNFA"
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
    DTPW = 3,
    WCED = 4,
    DotP = 5,
    PT = 6,
    DSD = 7,
    DoA = 8,
    DCS = 9,
    DCAS = 10,
    DoH = 11,
    DHS = 12,
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

export enum DocumentUploadLocationsEnum {
    NpoProfile = 'NpoProfile',
    Workplan = 'Workplan',
    WorkplanActuals = 'WorkplanActuals'
}