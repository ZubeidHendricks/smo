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

const routes: Routes = [
  { path: '', component: HomeComponent },

  { path: 'admin/users', component: UsersComponent },
  { path: 'admin/utilities', component: UtilitiesComponent },
  { path: 'admin/permissions', component: PermissionsComponent },

  { path: 'npo-profiles', component: ProfileListComponent },
  { path: 'npo-profile/edit/:id', component: EditProfileComponent },

  { path: 'access-request', component: AccessRequestComponent },
  { path: 'access-review', component: AccessReviewComponent },

  { path: 'npos', component: NpoListComponent },
  { path: 'npo/create', component: CreateNpoComponent },
  { path: 'npo/edit/:id', component: EditNpoComponent },

  { path: 'applications', component: ApplicationListComponent },
  { path: 'application/create/:id', component: CreateApplicationComponent },
  { path: 'application/edit/:id', component: EditApplicationComponent },
  { path: 'application/review/:id', component: ReviewApplicationComponent },
  { path: 'application/approve/:id', component: ApproveApplicationComponent },
  { path: 'application/upload-sla/:id', component: UploadSLAComponent },
  { path: 'application/view/:id', component: ViewApplicationComponent },
  { path: 'application-periods', component: ApplicationPeriodListComponent },
  { path: 'application-period/create', component: CreateApplicationPeriodComponent },
  { path: 'application-period/edit/:id', component: EditApplicationPeriodComponent },

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

  // Error Pages
  { path: '401', component: Page401Component },
  { path: '403', component: Page403Component }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
