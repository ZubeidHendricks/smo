import { PrintFundingApplicatonComponent } from './components/application/application-steps/funding-application/print-funding-applicaton/print-funding-applicaton.component';
import { PrintWorkflowApplicationComponent } from './components/application/application-steps/funding-application/print-workflow-component/print-workflow-application.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PermissionsComponent } from './components/admin/permissions/permissions.component';
import { UsersComponent } from './components/admin/users/users.component';
import { AccessStatusComponent } from './components/admin/utilities/access-status/access-status.component';
import { ActivityTypeComponent } from './components/admin/utilities/activity-type/activity-type.component';
import { AllocationTypeComponent } from './components/admin/utilities/allocation-type/allocation-type.component';
import { ApplicationTypeComponent } from './components/admin/utilities/application-type/application-type.component';
import { DepartmentComponent } from './components/admin/utilities/department/department.component';
import { DocumentTypeComponent } from './components/admin/utilities/document-type/document-type.component';
import { EmailAccountComponent } from './components/admin/utilities/email-account/email-account.component';
import { FacilityClassComponent } from './components/admin/utilities/facility-class/facility-class.component';
import { FacilityDistrictComponent } from './components/admin/utilities/facility-district/facility-district.component';
import { FacilitySubDistrictComponent } from './components/admin/utilities/facility-sub-district/facility-sub-district.component';
import { FacilityTypeComponent } from './components/admin/utilities/facility-type/facility-type.component';
import { FinancialYearComponent } from './components/admin/utilities/financial-year/financial-year.component';
import { OrganisationTypeComponent } from './components/admin/utilities/organisation-type/organisation-type.component';
import { PositionComponent } from './components/admin/utilities/position/position.component';
import { ProgrammeComponent } from './components/admin/utilities/programme/programme.component';
import { ProvisionTypeComponent } from './components/admin/utilities/provision-type/provision-type.component';
import { RecipientTypeComponent } from './components/admin/utilities/recipient-type/recipient-type.component';
import { ResourceTypeComponent } from './components/admin/utilities/resource-type/resource-type.component';
import { RoleComponent } from './components/admin/utilities/role/role.component';
import { ServiceTypeComponent } from './components/admin/utilities/service-type/service-type.component';
import { StatusComponent } from './components/admin/utilities/status/status.component';
import { SubProgrammeComponent } from './components/admin/utilities/sub-programme/sub-programme.component';
import { TitleComponent } from './components/admin/utilities/title/title.component';
import { UtilitiesComponent } from './components/admin/utilities/utilities.component';
import { UtilityManagementComponent } from './components/admin/utilities/utility-management/utility-management.component';
import { ApplicationPeriodListComponent } from './components/application-period/application-period-list/application-period-list.component';
import { CreateApplicationPeriodComponent } from './components/application-period/create-application-period/create-application-period.component';
import { EditApplicationPeriodComponent } from './components/application-period/edit-application-period/edit-application-period.component';
import { ApplicationListComponent } from './components/application/application-list/application-list.component';
import { ApproveApplicationComponent } from './components/application/approve-application/approve-application.component';
import { CreateApplicationComponent } from './components/application/create-application/create-application.component';
import { EditApplicationComponent } from './components/application/edit-application/edit-application.component';
import { ReviewApplicationComponent } from './components/application/review-application/review-application.component';
import { UploadSLAComponent } from './components/application/upload-sla/upload-sla.component';
import { ViewApplicationComponent } from './components/application/view-application/view-application.component';
import { Page401Component } from './components/error-pages/page401/page401.component';
import { Page403Component } from './components/error-pages/page403/page403.component';
import { HomeComponent } from './components/home/home.component';
import { NpoApprovalComponent } from './components/npo-approval/npo-approval.component';
import { EditProfileComponent } from './components/npo-profile/edit-profile/edit-profile.component';
import { ProfileListComponent } from './components/npo-profile/profile-list/profile-list.component';
import { CreateNpoComponent } from './components/npo/create-npo/create-npo.component';
import { EditNpoComponent } from './components/npo/edit-npo/edit-npo.component';
import { NpoListComponent } from './components/npo/npo-list/npo-list.component';
import { PowerbiDashboardComponent } from './components/powerbi-dashboard/powerbi-dashboard.component';
import { AccessRequestComponent } from './components/user-access/access-request/access-request.component';
import { AccessReviewComponent } from './components/user-access/access-review/access-review.component';
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
import { BankComponent } from './components/admin/utilities/bank/bank.component';
import { BranchComponent } from './components/admin/utilities/branch/branch.component';
import { AccountTypeComponent } from './components/admin/utilities/account-type/account-type.component';
import { CompliantCyclesComponent } from './components/admin/compliant-cycles/compliant-cycles.component';
import { PaymentSchedulesComponent } from './components/admin/payment-schedules/payment-schedules.component';
import { QuickCaptureListComponent } from './components/quick-capture/quick-capture-list/quick-capture-list.component';
import { CreateQuickCaptureComponent } from './components/quick-capture/create-quick-capture/create-quick-capture.component';
import { EditQuickCaptureComponent } from './components/quick-capture/edit-quick-capture/edit-quick-capture.component';
import { ApplicationDetailsComponent } from './components/application/application-steps/funding-application/application-details/application-details.component';
import { QcApplicationPeriodsComponent } from './components/application/application-steps/quick-capture/qc-application-periods/qc-application-periods.component';
import { QcApplicationPeriodsDohComponent } from './components/application/application-steps/quick-capture/qc-application-periods-doh/qc-application-periods-doh.component';
import { QcApplicationPeriodsDohViewComponent } from './components/application/application-steps/quick-capture-view/qc-application-periods-doh-view/qc-application-periods-doh-view.component';

import { QuestionComponent } from './components/admin/utilities/question/question.component';
import { ResponseTypeComponent } from './components/admin/utilities/response-type/response-type.component';
import { WorkflowAssessmentComponent } from './components/admin/utilities/workflow-assessment/workflow-assessment.component';
import { ResponseOptionComponent } from './components/admin/utilities/response-option/response-option.component';
import { QuestionSectionComponent } from './components/admin/utilities/question-section/question-section.component';
import { QuestionCategoryComponent } from './components/admin/utilities/question-category/question-category.component';
import  {WorkflowApplicationComponent} from './components/application/workflow-component/workflow-application.component';
import  {ScorecardComponent} from './components/application/scorecard/scorecard.component';
import  {ReviewScorecardComponent} from './components/application/review-scorecard/review-scorecard.component';
import  {PrintScorecardComponent} from './components/application/application-steps/funding-application/print-scorecard/print-scorecard.component';
import { QuickCaptureEditListComponent } from './components/quick-capture/quick-capture-edit-list/quick-capture-edit-list.component';
import { EditQuickCaptureDohListComponent } from './components/quick-capture/edit-quick-capture-doh-list/edit-quick-capture-doh-list.component';
import { ReviewQuickCaptureDohComponent } from './components/quick-capture/review-quick-capture-doh/review-quick-capture-doh.component';
import { ViewQuickCaptureDohComponent } from './components/quick-capture/view-quick-capture-doh/view-quick-capture-doh.component';
import { ScorecardQuestionComponent } from './components/admin/utilities/scorecard-question/scorecard-question.component';
import { ViewNpoDetailsComponent } from './components/npo/view-npo-details/view-npo-details.component';
import { ViewProfileDetailsComponent } from './components/npo-profile/view-profile-details/view-profile-details.component';
import{DownloadQuickCaptureDohComponent} from './components/quick-capture/download-quick-capture-doh/download-quick-capture-doh.component';
import { ScorecardActionComponent } from './components/application/scorecard-action/scorecard-action.component';
import { AdjudicateNpoComponent } from './components/application/adjudicate-npo/adjudicate-npo.component';
import { ReviewAdjudicatedNpoComponent } from './components/application/review-adjudicated-npo/review-adjudicated-npo.component';

import { BudgetSummaryComponent } from './components/admin/budgets/budget-summary/budget-summary.component';
import { UploadBudgetComponent } from './components/admin/budgets/upload-budget/upload-budget.component';
import { DownloadWorkplanComponent } from './components/application/download-workplan/download-workplan.component';
import { FundingCaptureListComponent } from './components/funding-capture/funding-capture-list/funding-capture-list.component';
import { EditFundingCaptureComponent } from './components/funding-capture/edit-funding-capture/edit-funding-capture.component';
import { ApproveFundingCaptureComponent } from './components/funding-capture/approve-funding-capture/approve-funding-capture.component';
import { ViewFundingCaptureComponent } from './components/funding-capture/view-funding-capture/view-funding-capture.component';
import { NpoReportCaptureComponent } from './reporting/npo-report-capture/npo-report-capture.component';
import { ReportReviewComponent } from './reporting/report-review/report-review.component';
import { IndicatorImportComponent } from './reporting/indicator-import/indicator-import.component';
import { ReportDownloadComponent } from './reporting/report-download/report-download.component';
import { FundingAssessmentListComponent } from './components/funding-assessment/funding-assessment-list/funding-assessment-list.component';
import { ProgramSummaryComponent } from './reporting/program-summary/program-summary.component';
import { SubprogrammetypeSummaryComponent } from './reporting/subprogrammetype-summary/subprogrammetype-summary.component';

const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'admin/users', component: UsersComponent },
  { path: 'admin/utilities', component: UtilitiesComponent },
  { path: 'admin/permissions', component: PermissionsComponent },

  { path: 'npo-profiles', component: ProfileListComponent },
  { path: 'npo-profile/edit/:id', component: EditProfileComponent },
  { path: 'npo-profile/view/:id', component: ViewProfileDetailsComponent },
  { path: 'print/:id/0', outlet: 'print', component: PrintFundingApplicatonComponent },
  { path: 'print/:id/1', outlet: 'print', component: PrintWorkflowApplicationComponent },
  { path: 'print/:id/2', outlet: 'print', component: PrintScorecardComponent },
  { path: 'print/:id/3', outlet: 'print', component: DownloadQuickCaptureDohComponent },
  { path: 'print/:id/4', outlet: 'print', component: DownloadWorkplanComponent },
  { 
    path: 'print/:id/:year/:qtr/:sda/5', 
    outlet: 'print', 
    component: ReportDownloadComponent 
  },

  { path: 'access-request', component: AccessRequestComponent },
  { path: 'access-review', component: AccessReviewComponent },

  { path: 'quick-captures', component: QuickCaptureListComponent },
  { path: 'quick-captures-editList/edit/:id/:activeStep', component: QuickCaptureEditListComponent },
  { path: 'quick-captures-editList-doh/edit/:id', component: EditQuickCaptureDohListComponent },
  { path: 'quick-captures-doh/review/:id', component: ReviewQuickCaptureDohComponent },
  { path: 'quick-captures-doh/view/:id', component: ViewQuickCaptureDohComponent },

  { path: 'quick-capture/create', component: CreateQuickCaptureComponent },
  { path: 'quick-capture/edit/:id', component: EditQuickCaptureComponent },

  { path: 'quick-captures/:id', component: QuickCaptureListComponent },

  { path: 'npos', component: NpoListComponent },
  { path: 'npo/create', component: CreateNpoComponent },
  { path: 'npo/edit/:id', component: EditNpoComponent },
  { path: 'npo/view/:id', component: ViewNpoDetailsComponent },

  { path: 'applications', component: ApplicationListComponent },
  { path: 'applicationDetails/:id', component: ApplicationDetailsComponent },
  { path: 'qcOpenApplicationList', component: QcApplicationPeriodsComponent },
  { path: 'qcOpenApplicationDohList', component: QcApplicationPeriodsDohComponent },

  { path: 'reports/:id', component: NpoReportCaptureComponent },
  { path: 'programsummary/:id/:programid', component: ProgramSummaryComponent },
  { path: 'subprogramsummary/:id/:programid', component: SubprogrammetypeSummaryComponent },
  
  { path: 'reviewReports/:id', component: ReportReviewComponent },
  { path: 'utilities/importReports', component: IndicatorImportComponent },
  { path: 'application/create/:id', component: CreateApplicationComponent },
  { path: 'application/edit/:id/:activeStep', component: EditApplicationComponent },
  { path: 'application/review/:id', component: ReviewApplicationComponent },
  { path: 'application/approve/:id', component: ApproveApplicationComponent },
  { path: 'application/upload-sla/:id', component: UploadSLAComponent },
  { path: 'scorecard/:id', component: ScorecardComponent },
  { path: 'adjudicateNpo/:id', component: AdjudicateNpoComponent},
  { path: 'reviewAdjudicatedNpo/:id', component: ReviewAdjudicatedNpoComponent},
  { path: 'initiate/:id', component: ScorecardActionComponent },
  { path: 'close/:id', component: ScorecardActionComponent },
  { path: 'reviewScorecard/:id', component: ReviewScorecardComponent },
  { path: 'application-periods', component: ApplicationPeriodListComponent },
  { path: 'application-period/create', component: CreateApplicationPeriodComponent },
  { path: 'application-period/edit/:id', component: EditApplicationPeriodComponent },
  { path: 'sp-application/view/:id', component: ViewApplicationComponent },
  { path: 'fa-application/view/:id', component: WorkflowApplicationComponent },
  { path: 'application/pre-evaluate/:id', component: WorkflowApplicationComponent },
  { path: 'application/evaluate/:id', component: WorkflowApplicationComponent },
  { path: 'application/adjudicate/:id', component: WorkflowApplicationComponent },
  { path: 'application/approval/:id', component: WorkflowApplicationComponent },
  { path: 'npo-approval', component: NpoApprovalComponent },
  { path: 'pbi-dashboard', component: PowerbiDashboardComponent },
  { path: 'training-material', component: TrainingMaterialComponent },

  // Utilities
  { path: 'utilities/department', component: DepartmentComponent },
  { path: 'utilities/document-type', component: DocumentTypeComponent },
  { path: 'utilities/email-account', component: EmailAccountComponent },
  { path: 'utilities/financial-year', component: FinancialYearComponent },
  { path: 'utilities/role', component: RoleComponent },
  { path: 'utilities/access-status', component: AccessStatusComponent },
  { path: 'utilities/status', component: StatusComponent },
  { path: 'utilities/activity-type', component: ActivityTypeComponent },
  { path: 'utilities/allocation-type', component: AllocationTypeComponent },
  { path: 'utilities/application-type', component: ApplicationTypeComponent },
  { path: 'utilities/facility-class', component: FacilityClassComponent },
  { path: 'utilities/facility-district', component: FacilityDistrictComponent },
  { path: 'utilities/facility-sub-district', component: FacilitySubDistrictComponent },
  { path: 'utilities/facility-type', component: FacilityTypeComponent },
  { path: 'utilities/organisation-type', component: OrganisationTypeComponent },
  { path: 'utilities/position', component: PositionComponent },
  { path: 'utilities/programme', component: ProgrammeComponent },
  { path: 'utilities/provision-type', component: ProvisionTypeComponent },
  { path: 'utilities/recipient-type', component: RecipientTypeComponent },
  { path: 'utilities/resource-type', component: ResourceTypeComponent },
  { path: 'utilities/service-type', component: ServiceTypeComponent },
  { path: 'utilities/sub-programme', component: SubProgrammeComponent },
  { path: 'utilities/title', component: TitleComponent },
  { path: 'utilities/management', component: UtilityManagementComponent },
  { path: 'utilities/sub-programme-type', component: SubProgrammeTypeComponent },
  { path: 'utilities/directorate', component: DirectorateComponent },
  { path: 'utilities/bank', component: BankComponent },
  { path: 'utilities/branch', component: BranchComponent },
  { path: 'utilities/account-type', component: AccountTypeComponent },
  { path: 'utilities/question', component: QuestionComponent },
  { path: 'utilities/question-category', component: QuestionCategoryComponent },
  { path: 'utilities/question-section', component: QuestionSectionComponent },
  { path: 'utilities/response-option', component: ResponseOptionComponent },
  { path: 'utilities/response-type', component: ResponseTypeComponent },
  { path: 'utilities/workflow-assessment', component: WorkflowAssessmentComponent },
  { path: 'utilities/scorecard-question', component: ScorecardQuestionComponent },

  // Error Pages
  { path: '401', component: Page401Component },
  { path: '403', component: Page403Component },

  // Workplan Indicators
  { path: 'workplan-indicator/manage/:npoId', component: ManageComponent },
  { path: 'workplan-indicator/actuals/:id', component: ActualsComponent },
  { path: 'workplan-indicator/targets/:id/financial-year/:financialYearId', component: TargetsComponent },
  { path: 'workplan-indicator/summary/:npoId', component: SummaryComponent },

   // businessplan Indicators
   { path: 'businessplan-indicator/manage/:npoId', component: ManageBusinessPlanComponent },
   { path: 'businessplan-indicator/actuals/:id', component: ActualsBusinessPlanComponent },
   { path: 'businessplan-indicator/targets/:id/financial-year/:financialYearId', component: TargetsBusinessPlanComponent },
   { path: 'businessplan-indicator/summary/:npoId', component: SummaryBusinessPlanComponent },

  // Budgets
  { path: 'admin/department-budget', component: DepartmentBudgetComponent },
  { path: 'admin/directorate-budget', component: DirectorateBudgetComponent },
  { path: 'admin/programme-budget', component: ProgrammeBudgetComponent },
  { path: 'admin/budget-summary', component: BudgetSummaryComponent },
  { path: 'admin/upload-budget', component: UploadBudgetComponent },

  // Funding
  { path: 'npo-funding', component: FundingListComponent },
  { path: 'npo-funding/create', component: CreateFundingComponent },
  { path: 'npo-funding/edit/:id', component: EditFundingComponent },

  // Compliant Cycle
  { path: 'admin/compliant-cycle', component: CompliantCyclesComponent },

  // Payment Schedule
  { path: 'admin/payment-schedule', component: PaymentSchedulesComponent },

  // Funding Capture
  { path: 'funding-capture', component: FundingCaptureListComponent },
  { path: 'funding-capture/addendum/:id', component: EditFundingCaptureComponent },
  { path: 'funding-capture/edit/:id', component: EditFundingCaptureComponent },
  { path: 'funding-capture/approve/:id', component: ApproveFundingCaptureComponent },
  { path: 'funding-capture/view/:id', component: ViewFundingCaptureComponent },
  { path: 'funding-capture/compliance/:id', component: ViewFundingCaptureComponent },
  //{ path: 'funding-capture', component: EditFundingCaptureComponent },
  // { path: 'funding-capture/download/:id', component: DownloadFundingCaptureComponent }

    // Funding Assessment
    { path: 'funding-assessment', component: FundingAssessmentListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
