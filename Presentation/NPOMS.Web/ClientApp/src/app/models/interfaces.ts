import { EntityTypeEnum } from "./enums";

/* Core */
export interface IDepartment {
    id: number;
    name: string;
    abbreviation: string;
    isActive: boolean;
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

    documentType: IDocumentType,
}

export interface IDocumentType {
    id: number,
    name: string,
    description: string,
    isCompulsory: boolean;
    isActive: boolean;
}

export interface IFinancialYear {
    id: number;
    name: string;
    year: number;
    startDate: Date;
    endDate: Date;
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
}

export interface IFacilitySubDistrict {
    id: number;
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

export interface IProgramme {
    id: number;
    name: string;
    systemName: string;
    departmentId: number;
    isActive: boolean;
    department: IDepartment;
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
    systemName: string;
    programmeId: number;
    isActive: boolean;
    programme: IProgramme;
}

export interface ITitle {
    id: number;
    name: string;
    isActive: boolean;
}

/* Entities */
export interface IAccessStatus {
    id: number;
    name: string;
    systemName: string;
    isActive: boolean;
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

    objective: IObjective;
    activityType: IActivityType;
    activitySubProgrammes: IActivitySubProgramme[];
    activityList: IActivityList;
    activityFacilityLists: IActivityFacilityList[];
}

export interface IAddressInformation {
    id: number;
    npoProfileId: number;
    physicalAddress: string;
    postalSameAsPhysical: boolean;
    postalAddress: string;
    createdUserId: number;
    createdDateTime: Date;
}

export interface IApplication {
    id: number;
    refNo: string;
    npoId: number;
    applicationPeriodId: number;
    statusId: number;
    isActive: boolean;

    applicationPeriod: IApplicationPeriod;
    status: IStatus;
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
    applicationTypeId: number;
    name: string;
    description: string;
    financialYearId: number;
    openingDate: Date;
    closingDate: Date;
    status: string;

    department: IDepartment;
    programme: IProgramme;
    subProgramme: ISubProgramme;
    financialYear: IFinancialYear;
    applicationType: IApplicationType;
}

export interface IContactInformation {
    id: number;
    npoId: number;
    titleId: number;
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
    isPrimaryContact: boolean;
    isActive: boolean;
    createdUserId: number;
    createdDateTime: Date;
    updatedUserId: number;
    updatedDateTime: Date;

    title: ITitle;
    position: IPosition;
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

    organisationType: IOrganisationType;
    approvalStatus: IAccessStatus;
    contactInformation: IContactInformation[];
    createdUser: IUser;
    approvalUser: IUser;
}

export interface INpoProfile {
    id: number;
    npoId: number;
    npoName: string;
    refNo: string;

    addressInformation: IAddressInformation;
    npoProfileFacilityLists: INpoProfileFacilityList[];
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

    recipientType: IRecipientType;
    objectiveProgrammes: IObjectiveProgramme[];
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

/* Lookup */
export interface IActivityList {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
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

    activity: IActivity;
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

    activity: IActivity;
    facilityList: IFacilityList;
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