import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MessageService } from 'primeng/api';
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
import { DatePipe } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FileUploadModule } from 'primeng/fileupload';

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

// B2B / B2C
import { IPublicClientApplication, PublicClientApplication, InteractionType, BrowserCacheLocation, LogLevel } from '@azure/msal-browser';
import { MsalInterceptor, MsalBroadcastService, MsalInterceptorConfiguration, MsalModule, MsalService, MSAL_INSTANCE, MSAL_INTERCEPTOR_CONFIG } from '@azure/msal-angular';
import { PowerbiDashboardComponent } from './components/powerbi-dashboard/powerbi-dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { TrainingMaterialComponent } from './components/training-material/training-material.component';

const isIE = window.navigator.userAgent.indexOf("MSIE ") > -1 || window.navigator.userAgent.indexOf("Trident/") > -1;

export function loggerCallback(logLevel: LogLevel, message: string) {
  // console.log(message);
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
    TrainingMaterialComponent
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
    FileUploadModule
  ],
  providers: [
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
    MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
