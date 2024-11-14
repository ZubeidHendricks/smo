import { EditorModule } from 'primeng/editor';
import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, NgModule } from '@angular/core';
import { MessageService, ConfirmationService } from 'primeng/api';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastModule } from 'primeng/toast';
import { PanelModule } from 'primeng/panel';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenubarModule } from 'primeng/menubar';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { TabViewModule } from 'primeng/tabview';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { MessagesModule } from 'primeng/messages';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { InputNumberModule } from 'primeng/inputnumber';
import { SelectButtonModule } from 'primeng/selectbutton';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputTextModule } from 'primeng/inputtext';
import { MessageModule } from 'primeng/message';
import { MultiSelectModule } from 'primeng/multiselect';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { PanelMenuModule } from 'primeng/panelmenu';
import { SidebarModule } from 'primeng/sidebar';
import { CheckboxModule } from 'primeng/checkbox';
import { TooltipModule } from 'primeng/tooltip';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { StepsModule } from 'primeng/steps';
import { DatePipe, HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FileUploadModule } from 'primeng/fileupload';
import { MegaMenuModule } from 'primeng/megamenu';
import { CardModule } from 'primeng/card';
import { AccordionModule } from 'primeng/accordion';
import { MenuModule } from 'primeng/menu';
import { ScrollTopModule } from 'primeng/scrolltop';
import { ToggleButtonModule } from 'primeng/togglebutton';
import {RadioButtonModule} from 'primeng/radiobutton';

// B2B / B2C
import { IPublicClientApplication, PublicClientApplication, InteractionType, BrowserCacheLocation, LogLevel } from '@azure/msal-browser';
import { MsalInterceptor, MsalBroadcastService, MsalInterceptorConfiguration, MsalModule, MsalService, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG } from '@azure/msal-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from "./app.component";
import { FooterComponent } from "./components/layout/footer/footer.component";
import { HeaderComponent } from "./components/layout/header/header.component";
import { NavigationComponent } from "./components/layout/navigation/navigation.component";
import { environment } from 'src/environments/environment';
import { Page401Component } from './components/error-pages/page401/page401.component';
import { Page403Component } from './components/error-pages/page403/page403.component';
import { PermissionsComponent } from './components/admin/permissions/permissions.component';
import { UsersComponent } from './components/admin/users/users.component';
import { UtilitiesComponent } from './components/admin/utilities/utilities.component';
import { ApplicationListComponent } from './components/application/application-list/application-list.component';
import { ApproveApplicationComponent } from './components/application/approve-application/approve-application.component';
import { CreateApplicationComponent } from './components/application/create-application/create-application.component';
import { EditApplicationComponent } from './components/application/edit-application/edit-application.component';
import { ReviewApplicationComponent } from './components/application/review-application/review-application.component';
import { UploadSLAComponent } from './components/application/upload-sla/upload-sla.component';
import { ViewApplicationComponent } from './components/application/view-application/view-application.component';
import { ApplicationPeriodListComponent } from './components/application-period/application-period-list/application-period-list.component';
import { CreateApplicationPeriodComponent } from './components/application-period/create-application-period/create-application-period.component';
import { EditApplicationPeriodComponent } from './components/application-period/edit-application-period/edit-application-period.component';
import { CreateNpoComponent } from './components/npo/create-npo/create-npo.component';
import { EditNpoComponent } from './components/npo/edit-npo/edit-npo.component';
import { NpoListComponent } from './components/npo/npo-list/npo-list.component';
import { ViewNpoComponent } from './components/npo/view-npo/view-npo.component';
import { EditProfileComponent } from './components/npo-profile/edit-profile/edit-profile.component';
import { ProfileListComponent } from './components/npo-profile/profile-list/profile-list.component';
import { ViewProfileComponent } from './components/npo-profile/view-profile/view-profile.component';
import { ActivitiesComponent } from './components/application/application-steps/service-provision/activities/activities.component';
import { ObjectivesComponent } from './components/application/application-steps/service-provision/objectives/objectives.component';
import { ResourcingComponent } from './components/application/application-steps/service-provision/resourcing/resourcing.component';
import { SustainabilityComponent } from './components/application/application-steps/service-provision/sustainability/sustainability.component';
import { ConfirmationComponent } from './components/application/application-steps/service-provision/confirmation/confirmation.component';
import { NpoDetailsComponent } from './components/application/application-steps/service-provision/npo-details/npo-details.component';
import { AccessRequestComponent } from './components/user-access/access-request/access-request.component';
import { AccessReviewComponent } from './components/user-access/access-review/access-review.component';
import { NpoApprovalComponent } from './components/npo-approval/npo-approval.component';
import { DepartmentComponent } from './components/admin/utilities/department/department.component';
import { DocumentTypeComponent } from './components/admin/utilities/document-type/document-type.component';
import { EmailAccountComponent } from './components/admin/utilities/email-account/email-account.component';
import { FinancialYearComponent } from './components/admin/utilities/financial-year/financial-year.component';
import { RoleComponent } from './components/admin/utilities/role/role.component';
import { AccessStatusComponent } from './components/admin/utilities/access-status/access-status.component';
import { StatusComponent } from './components/admin/utilities/status/status.component';
import { ActivityTypeComponent } from './components/admin/utilities/activity-type/activity-type.component';
import { AllocationTypeComponent } from './components/admin/utilities/allocation-type/allocation-type.component';
import { ApplicationTypeComponent } from './components/admin/utilities/application-type/application-type.component';
import { FacilityClassComponent } from './components/admin/utilities/facility-class/facility-class.component';
import { FacilityDistrictComponent } from './components/admin/utilities/facility-district/facility-district.component';
import { FacilitySubDistrictComponent } from './components/admin/utilities/facility-sub-district/facility-sub-district.component';
import { FacilityTypeComponent } from './components/admin/utilities/facility-type/facility-type.component';
import { OrganisationTypeComponent } from './components/admin/utilities/organisation-type/organisation-type.component';
import { PositionComponent } from './components/admin/utilities/position/position.component';
import { ProgrammeComponent } from './components/admin/utilities/programme/programme.component';
import { ProvisionTypeComponent } from './components/admin/utilities/provision-type/provision-type.component';
import { RecipientTypeComponent } from './components/admin/utilities/recipient-type/recipient-type.component';
import { ResourceTypeComponent } from './components/admin/utilities/resource-type/resource-type.component';
import { ServiceTypeComponent } from './components/admin/utilities/service-type/service-type.component';
import { SubProgrammeComponent } from './components/admin/utilities/sub-programme/sub-programme.component';
import { TitleComponent } from './components/admin/utilities/title/title.component';
import { UtilityManagementComponent } from './components/admin/utilities/utility-management/utility-management.component';
import { PowerbiDashboardComponent } from './components/powerbi-dashboard/powerbi-dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { TrainingMaterialComponent } from './components/training-material/training-material.component';
import { ManageComponent } from './components/indicators/workplan/manage/manage.component';
import { ActualsComponent } from './components/indicators/workplan/actuals/actuals.component';
import { TargetsComponent } from './components/indicators/workplan/targets/targets.component';
import { SummaryComponent } from './components/indicators/workplan/summary/summary.component';
import { ManageBusinessPlanComponent } from './components/indicators/businessplan/manage-businessplan/manage-businessplan.component';
import { ActualsBusinessPlanComponent } from './components/indicators/businessplan/actuals-businessplan/actuals-businessplan.component';
import { TargetsBusinessPlanComponent } from './components/indicators/businessplan/targets-businessplan/targets-businessplan.component';
import { SummaryBusinessPlanComponent } from './components/indicators/businessplan/summary-businessplan/summary-businessplan.component';
import { SubProgrammeTypeComponent } from './components/admin/utilities/sub-programme-type/sub-programme-type.component';
import { DepartmentBudgetComponent } from './components/admin/budgets/department-budget/department-budget.component';
import { DirectorateBudgetComponent } from './components/admin/budgets/directorate-budget/directorate-budget.component';
import { ProgrammeBudgetComponent } from './components/admin/budgets/programme-budget/programme-budget.component';
import { DirectorateComponent } from './components/admin/utilities/directorate/directorate.component';
import { FundingListComponent } from './components/funding/funding-list/funding-list.component';
import { CreateFundingComponent } from './components/funding/create-funding/create-funding.component';
import { EditFundingComponent } from './components/funding/edit-funding/edit-funding.component';
import { FundingDetailComponent } from './components/funding/funding-steps/funding-detail/funding-detail.component';
import { ServiceDeliveryAreaComponent } from './components/funding/funding-steps/service-delivery-area/service-delivery-area.component';
import { PaymentScheduleComponent } from './components/funding/funding-steps/payment-schedule/payment-schedule.component';
import { BankDetailComponent } from './components/funding/funding-steps/bank-detail/bank-detail.component';
import { DocumentsComponent } from './components/funding/funding-steps/documents/documents.component';
import { BankComponent } from './components/admin/utilities/bank/bank.component';
import { BranchComponent } from './components/admin/utilities/branch/branch.component';
import { AccountTypeComponent } from './components/admin/utilities/account-type/account-type.component';
import { PaymentSchedulesComponent } from './components/admin/payment-schedules/payment-schedules.component';
import { CompliantCyclesComponent } from './components/admin/compliant-cycles/compliant-cycles.component';
import { ApplicationDetailsComponent } from './components/application/application-steps/funding-application/application-details/application-details.component';
import { ProjectInformationComponent } from './components/application/application-steps/funding-application/project-information/project-information.component';
import { MonitoringEvaluationPlanComponent } from './components/application/application-steps/funding-application/monitoring-evaluation-plan/monitoring-evaluation-plan.component';
import { ProjectImplementationComponent } from './components/application/application-steps/funding-application/project-implementation/project-implementation.component';
import { DocumentUploadComponent } from './components/application/application-steps/funding-application/document-upload/document-upload.component';
import { DeclarationComponent } from './components/application/application-steps/funding-application/declaration/declaration.component';
import { FinancialMattersComponent } from './components/application/application-steps/funding-application/financial-matters/financial-matters.component';
import { QuickCaptureListComponent } from './components/quick-capture/quick-capture-list/quick-capture-list.component';
import { CreateQuickCaptureComponent } from './components/quick-capture/create-quick-capture/create-quick-capture.component';
import { EditQuickCaptureComponent } from './components/quick-capture/edit-quick-capture/edit-quick-capture.component';
import { QcApplicationDetailsComponent } from './components/application/application-steps/quick-capture/qc-application-details/qc-application-details.component';
import { QcDocumentUploadComponent } from './components/application/application-steps/quick-capture/qc-document-upload/qc-document-upload.component';
import { QcFundedDocumentUploadComponent } from './components/application/application-steps/quick-capture/qc-funded-document-upload/qc-funded-document-upload.component';
import { QcApplicationPeriodsComponent } from './components/application/application-steps/quick-capture/qc-application-periods/qc-application-periods.component';
import { QcApplicationPeriodsDohComponent } from './components/application/application-steps/quick-capture/qc-application-periods-doh/qc-application-periods-doh.component';
import { QcApplicationPeriodsDohViewComponent } from './components/application/application-steps/quick-capture-view/qc-application-periods-doh-view/qc-application-periods-doh-view.component';
import { QcApplicationDetailComponent } from './components/application/application-steps/quick-capture/qc-application-detail/qc-application-detail.component';
import { QcApplicationDetailEditComponent } from './components/application/application-steps/quick-capture/qc-application-detail-edit/qc-application-detail-edit.component';
import { QCActivitiesComponent } from './components/application/application-steps/quick-capture/qc-activities/qc-activities.component';
import { QcObjectivesComponent } from './components/application/application-steps/quick-capture/qc-objectives/qc-objectives.component';
import { QCActivitiesEditComponent } from './components/application/application-steps/quick-capture/qc-activities-edit/qc-activities-edit.component';
import { QcObjectivesEditComponent } from './components/application/application-steps/quick-capture/qc-objectives-edit/qc-objectives-edit.component';

import { QuestionComponent } from './components/admin/utilities/question/question.component';
import { ResponseTypeComponent } from './components/admin/utilities/response-type/response-type.component';
import { WorkflowAssessmentComponent } from './components/admin/utilities/workflow-assessment/workflow-assessment.component';
import { ResponseOptionComponent } from './components/admin/utilities/response-option/response-option.component';
import { QuestionSectionComponent } from './components/admin/utilities/question-section/question-section.component';
import { QuestionCategoryComponent } from './components/admin/utilities/question-category/question-category.component';
import { PrintFundingApplicatonComponent } from './components/application/application-steps/funding-application/print-funding-applicaton/print-funding-applicaton.component';
import { PrintWorkflowApplicationComponent } from './components/application/application-steps/funding-application/print-workflow-component/print-workflow-application.component';
import { ViewApplicationDetailsComponent } from './components/application/application-steps/funding-application/view-application-details/view-application-details.component';
import { ViewProjectInformationComponent } from './components/application/application-steps/funding-application/view-project-information/view-project-information.component';
import { ViewProjectImplementationComponent } from './components/application/application-steps/funding-application/view-project-implementation/view-project-implementation.component';
import { ViewDocumentUploadComponent } from './components/application/application-steps/funding-application/view-document-upload/view-document-upload.component';
import { ViewFundingApplicationComponent } from './components/application/application-steps/funding-application/view-funding-application/view-funding-application.component';
import { ViewMonitoringEvaluationComponent } from './components/application/application-steps/funding-application/view-monitoring-evaluation/view-monitoring-evaluation.component';
import { ViewFinancialMattersComponent } from './components/application/application-steps/funding-application/view-financial-matters/view-financial-matters.component';
import { FundingApplicationViewComponent } from './components/application/application-steps/funding-application/funding-application-view/funding-application-view.component';
import { WorkflowApplicationComponent } from './components/application/workflow-component/workflow-application.component';
//import { ScorecardComponent } from './components/application/scorecard-component/scorecard.component';
import { QuickCaptureEditListComponent } from './components/quick-capture/quick-capture-edit-list/quick-capture-edit-list.component';
import { EditQuickCaptureDohListComponent } from './components/quick-capture/edit-quick-capture-doh-list/edit-quick-capture-doh-list.component';
import { ReviewQuickCaptureDohComponent } from './components/quick-capture/review-quick-capture-doh/review-quick-capture-doh.component';
import { ViewQuickCaptureDohComponent } from './components/quick-capture/view-quick-capture-doh/view-quick-capture-doh.component';
import { DownloadQuickCaptureDohComponent} from './components/quick-capture/download-quick-capture-doh/download-quick-capture-doh.component';
import { QcApplicationDetailsEditComponent } from './components/application/application-steps/quick-capture/qc-application-details-edit/qc-application-details-edit.component';
import { QcDocumentUploadEditComponent } from './components/application/application-steps/quick-capture/qc-document-upload-edit/qc-document-upload-edit.component';
import { ScorecardComponent } from './components/application/scorecard/scorecard.component';
import { ScorecardActionComponent } from './components/application/scorecard-action/scorecard-action.component';
import { ScorecardQuestionComponent } from './components/admin/utilities/scorecard-question/scorecard-question.component';
import { ViewNpoDetailsComponent } from './components/npo/view-npo-details/view-npo-details.component';
import { ViewProfileDetailsComponent } from './components/npo-profile/view-profile-details/view-profile-details.component';
import { ReviewScorecardComponent } from './components/application/review-scorecard/review-scorecard.component';
import  {PrintScorecardComponent} from './components/application/application-steps/funding-application/print-scorecard/print-scorecard.component';
import { AdjudicateNpoComponent } from './components/application/adjudicate-npo/adjudicate-npo.component';
import { ReviewAdjudicatedNpoComponent } from './components/application/review-adjudicated-npo/review-adjudicated-npo.component';

import { QcConfirmationComponent } from './components/application/application-steps/quick-capture-view/qc-confirmation/qc-confirmation.component';
import { QCActivitiesViewComponent } from './components/application/application-steps/quick-capture-view/qc-activities-view/qc-activities-view.component';
import { QcApplicationDetailViewComponent } from './components/application/application-steps/quick-capture-view/qc-application-detail-view/qc-application-detail-view.component';
import { QcApplicationPeriodsViewComponent } from './components/application/application-steps/quick-capture-view/qc-application-periods-view/qc-application-periods-view.component';
import { QcFundedDocumentUploadViewComponent } from './components/application/application-steps/quick-capture-view/qc-funded-document-upload-view/qc-funded-document-upload-view.component';
import { QcObjectivesViewComponent } from './components/application/application-steps/quick-capture-view/qc-objectives-view/qc-objectives-view.component';
import { QcNpoDetailsViewComponent } from './components/application/application-steps/quick-capture-view/qc-npo-details-view/qc-npo-details-view.component';
import { BudgetSummaryComponent } from './components/admin/budgets/budget-summary/budget-summary.component';
import { UploadBudgetComponent } from './components/admin/budgets/upload-budget/upload-budget.component';
import { DownloadWorkplanComponent } from './components/application/download-workplan/download-workplan.component';
import { ApproveFundingCaptureComponent } from './components/funding-capture/approve-funding-capture/approve-funding-capture.component';
import { ViewFundingCaptureComponent } from './components/funding-capture/view-funding-capture/view-funding-capture.component';
import { DownloadFundingCaptureComponent } from './components/funding-capture/download-funding-capture/download-funding-capture.component';
import { FCSDAComponent } from './components/funding-capture/fc-steps/fc-sda/fc-sda.component';
import { FCPaymentScheduleComponent } from './components/funding-capture/fc-steps/fc-payment-schedule/fc-payment-schedule.component';
import { FCBankDetailComponent } from './components/funding-capture/fc-steps/fc-bank-detail/fc-bank-detail.component';
import { FCDocumentComponent } from './components/funding-capture/fc-steps/fc-document/fc-document.component';
import { FundingCaptureListComponent } from './components/funding-capture/funding-capture-list/funding-capture-list.component';
import { EditFundingCaptureComponent } from './components/funding-capture/edit-funding-capture/edit-funding-capture.component';
import { FCFundingDetailComponent } from './components/funding-capture/fc-steps/fc-funding-detail/fc-funding-detail.component';
import { FCApprovalComponent } from './components/funding-capture/fc-steps/fc-approval/fc-approval.component';
import { FundingAssessmentListComponent } from './components/funding-assessment/funding-assessment-list/funding-assessment-list.component';
import { FundingAssessmentFormComponent } from './components/funding-assessment/funding-assessment-form/funding-assessment-form.component';
import { FundingAssessmentFormQuestionSectionComponent } from './components/funding-assessment/funding-assessment-form-questionsection/funding-assessment-form-questionsection.component';

import { NpoReportCaptureComponent } from './reporting/npo-report-capture/npo-report-capture.component';
import { IndicatorReportComponent } from './npo-reporting-steps/indicator-report/indicator-report.component';
import { PostReportComponent } from './npo-reporting-steps/post-report/post-report.component';
import { DetailsOfIncomeAndAndExpenditureReportComponent } from './npo-reporting-steps/details-of-income-and-and-expenditure-report/details-of-income-and-and-expenditure-report.component';
import { GovernanceReportComponent } from './npo-reporting-steps/governance-report/governance-report.component';
import { AnyOtherInformationReportComponent } from './npo-reporting-steps/any-other-information-report/any-other-information-report.component';
import { QuarterlySDIPReportingReportComponent } from './npo-reporting-steps/quarterly-sdip-reporting-report/quarterly-sdip-reporting-report.component';
import { IndicatorsComponent } from './reporting/indicators/indicators.component';
import { ReportReviewComponent } from './reporting/report-review/report-review.component';
import { IndicatorImportComponent } from './reporting/indicator-import/indicator-import.component';
import { ReportDownloadComponent } from './reporting/report-download/report-download.component';
import { ReportActualsComponent } from './reporting/report-actuals/report-actuals.component';
import { ProgramSummaryComponent } from './reporting/program-summary/program-summary.component';
const isIE = window.navigator.userAgent.indexOf("MSIE ") > -1 || window.navigator.userAgent.indexOf("Trident/") > -1;

export function loggerCallback(logLevel: LogLevel, message: string) {

}

export function MSALInstanceFactory(): IPublicClientApplication {
  return new PublicClientApplication({
    auth: {
      clientId: environment.b2cConfig.clientId,
      authority: environment.b2cConfig.authorities.signUpSignIn.authority,
      redirectUri: environment.b2cConfig.redirectUrl,
      postLogoutRedirectUri: '/',
      knownAuthorities: [environment.b2cConfig.authorityDomain]
    },
    cache: {
      cacheLocation: BrowserCacheLocation.LocalStorage,
      storeAuthStateInCookie: isIE, // set to true for IE 11
    },
    system: {
      loggerOptions: {
        loggerCallback,
        logLevel: LogLevel.Info,
        piiLoggingEnabled: false
      }
    }
  });
}

export function MSALInterceptorConfigFactory(): MsalInterceptorConfiguration {
  const protectedResourceMap = new Map<string, Array<string>>();
  protectedResourceMap.set(environment.b2cConfig.resources.uri, environment.b2cConfig.resources.scopes);

  return {
    interactionType: InteractionType.Redirect,
    protectedResourceMap,
  };
}

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    NavigationComponent,
    Page401Component,
    Page403Component,
    PermissionsComponent,
    UsersComponent,
    UtilitiesComponent,
    ApplicationListComponent,
    ApproveApplicationComponent,
    CreateApplicationComponent,
    EditApplicationComponent,
    ReviewApplicationComponent,
    UploadSLAComponent,
    ViewApplicationComponent,
    ApplicationPeriodListComponent,
    CreateApplicationPeriodComponent,
    EditApplicationPeriodComponent,
    CreateNpoComponent,
    EditNpoComponent,
    NpoListComponent,
    ViewNpoComponent,
    EditProfileComponent,
    ProfileListComponent,
    ViewProfileComponent,
    ActivitiesComponent,
    ObjectivesComponent,
    ResourcingComponent,
    SustainabilityComponent,
    ConfirmationComponent,
    NpoDetailsComponent,
    AccessRequestComponent,
    AccessReviewComponent,
    NpoApprovalComponent,
    DepartmentComponent,
    DocumentTypeComponent,
    EmailAccountComponent,
    FinancialYearComponent,
    RoleComponent,
    AccessStatusComponent,
    StatusComponent,
    ActivityTypeComponent,
    AllocationTypeComponent,
    ApplicationTypeComponent,
    FacilityClassComponent,
    FacilityDistrictComponent,
    FacilitySubDistrictComponent,
    FacilityTypeComponent,
    OrganisationTypeComponent,
    PositionComponent,
    ProgrammeComponent,
    ProvisionTypeComponent,
    RecipientTypeComponent,
    ResourceTypeComponent,
    ServiceTypeComponent,
    SubProgrammeComponent,
    TitleComponent,
    UtilityManagementComponent,
    PowerbiDashboardComponent,
    HomeComponent,
    TrainingMaterialComponent,
    ManageComponent,
    ActualsComponent,
    TargetsComponent,
    SummaryComponent,
    ManageBusinessPlanComponent,
    ActualsBusinessPlanComponent,
    TargetsBusinessPlanComponent,
    SummaryBusinessPlanComponent,
    SubProgrammeTypeComponent,
    DirectorateBudgetComponent,
    DepartmentBudgetComponent,
    ProgrammeBudgetComponent,
    DirectorateComponent,
    FundingListComponent,
    CreateFundingComponent,
    EditFundingComponent,
    FundingDetailComponent,
    ServiceDeliveryAreaComponent,
    PaymentScheduleComponent,
    BankDetailComponent,
    DocumentsComponent,
    BankComponent,
    BranchComponent,
    AccountTypeComponent,
    PaymentSchedulesComponent,
    CompliantCyclesComponent,
    ApplicationDetailsComponent,
    ProjectInformationComponent,
    MonitoringEvaluationPlanComponent,
    ProjectImplementationComponent,
    DocumentUploadComponent,
    DeclarationComponent,
    FinancialMattersComponent,
    QuickCaptureListComponent,
    CreateQuickCaptureComponent,
    EditQuickCaptureComponent,
    QcApplicationDetailsComponent,
    QcDocumentUploadComponent,
    QcFundedDocumentUploadComponent,
    QcApplicationPeriodsComponent,
    QcApplicationDetailComponent,
    QuestionComponent,
    ResponseTypeComponent,
    WorkflowAssessmentComponent,
    ResponseOptionComponent,
    QuestionSectionComponent,
    QuestionCategoryComponent,
    PrintFundingApplicatonComponent,
    PrintWorkflowApplicationComponent,
    ViewApplicationDetailsComponent,
    ViewProjectInformationComponent,
    ViewProjectImplementationComponent,
    ViewDocumentUploadComponent,
    ViewFundingApplicationComponent,
    ViewMonitoringEvaluationComponent,
    ViewFinancialMattersComponent,
    FundingApplicationViewComponent,
    WorkflowApplicationComponent,
    QuickCaptureEditListComponent,
    EditQuickCaptureDohListComponent,
    ReviewQuickCaptureDohComponent,
    QcApplicationDetailsEditComponent,
    QcDocumentUploadEditComponent,
    ScorecardComponent,
    ScorecardQuestionComponent,
    ViewNpoDetailsComponent,
    ViewProfileDetailsComponent,
    ReviewScorecardComponent,
    PrintScorecardComponent,
    QCActivitiesComponent, 
    QcObjectivesComponent,
    QcConfirmationComponent, 
    QCActivitiesViewComponent, 
    QcApplicationDetailViewComponent, 
    QcApplicationPeriodsViewComponent,
    QcFundedDocumentUploadViewComponent, 
    QcObjectivesViewComponent,
    QcNpoDetailsViewComponent,
    ViewQuickCaptureDohComponent,
    DownloadQuickCaptureDohComponent,
    ScorecardActionComponent,
    AdjudicateNpoComponent,
    ReviewAdjudicatedNpoComponent,
    BudgetSummaryComponent,
    UploadBudgetComponent,
    DownloadWorkplanComponent,
    QcApplicationPeriodsDohComponent,
    QcApplicationPeriodsDohViewComponent,
    QcApplicationDetailEditComponent,
    QCActivitiesEditComponent,
    QcObjectivesEditComponent,
    DownloadWorkplanComponent,
    ApproveFundingCaptureComponent,
    ViewFundingCaptureComponent,
    DownloadFundingCaptureComponent,
    FCSDAComponent,
    FCPaymentScheduleComponent,
    FCBankDetailComponent,
    FCDocumentComponent,
    FundingCaptureListComponent,
    EditFundingCaptureComponent,
    FCFundingDetailComponent,
    FCApprovalComponent,
    NpoReportCaptureComponent,
    IndicatorReportComponent,
    PostReportComponent,
    DetailsOfIncomeAndAndExpenditureReportComponent,
    GovernanceReportComponent,
    AnyOtherInformationReportComponent,
    QuarterlySDIPReportingReportComponent,
    IndicatorsComponent,
    ReportReviewComponent,
    IndicatorImportComponent,
    ReportDownloadComponent,
    ReportActualsComponent,
    FCApprovalComponent,
    FundingAssessmentListComponent,
    FundingAssessmentFormComponent,
    FundingAssessmentFormQuestionSectionComponent,
    ProgramSummaryComponent
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxSpinnerModule,
    FormsModule,
    ReactiveFormsModule,
    ToastModule,
    PanelModule,
    BrowserAnimationsModule,
    MenubarModule,
    TableModule,
    ButtonModule,
    DialogModule,
    TabViewModule,
    DropdownModule,
    CalendarModule,
    MessagesModule,
    AutoCompleteModule,
    InputNumberModule,
    SelectButtonModule,
    InputTextareaModule,
    InputTextModule,
    MessageModule,
    MultiSelectModule,
    ConfirmDialogModule,
    PanelMenuModule,
    SidebarModule,
    CheckboxModule,
    TooltipModule,
    MsalModule,
    HttpClientModule,
    StepsModule,
    FileUploadModule,
    MegaMenuModule,
    CardModule,
    AccordionModule,
    MenuModule,
    ScrollTopModule,
    EditorModule,
    ToggleButtonModule,
    RadioButtonModule
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy 
    },
    DatePipe,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true
    },
    {
      provide: MSAL_INSTANCE,
      useFactory: MSALInstanceFactory
    },
    {
      provide: MSAL_INTERCEPTOR_CONFIG,
      useFactory: MSALInterceptorConfigFactory
    },
    MsalService,
    MsalBroadcastService,
    MessageService,
   ConfirmationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
