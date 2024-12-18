import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { PermissionsEnum, QCStepsEnum, StatusEnum, QuickCaptureFundedStepsEnum, QCStepsFundedEnum, RoleEnum, DropdownTypeEnum, DepartmentEnum } from 'src/app/models/enums';
import { IUser, INpo, IContactInformation, IApplicationPeriod, IApplication, IDistrictCouncil, ILocalMunicipality, IRegion, ISDA, IFundingApplicationDetails, IFundAppSDADetail, IApplicationDetails, IObjective, IActivity, IProjectInformation, IProgrammeServiceDelivery, IDepartment } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { MenuItem, Message, MessageService } from 'primeng/api';
import { CreateQuickCaptureComponent } from '../create-quick-capture/create-quick-capture.component';
import { IAffiliatedOrganisation, ISourceOfInformation } from 'src/app/models/FinancialMatters';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { FundingApplicationService } from 'src/app/services/api-services/funding-application/funding-application.service';
import { NpoProfileService } from 'src/app/services/api-services/npo-profile/npo-profile.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { DepartmentService } from 'src/app/services/Department/department.service';

@Component({
  selector: 'app-quick-capture-list',
  templateUrl: './quick-capture-list.component.html',
  styleUrls: ['./quick-capture-list.component.css']
})
export class QuickCaptureListComponent implements OnInit {
  
  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }

    const roles = this.profile.roles || [];
    const permissions = this.profile.permissions || [];
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get QCStepsEnum(): typeof QCStepsEnum {
    return QCStepsEnum;
  }

  public get QCStepsFundedEnum(): typeof QCStepsFundedEnum {
    return QCStepsFundedEnum;
  }

  profile: IUser;

  npo: INpo = {
    section18Receipts: false,
    contactInformation: [] as IContactInformation[]
  } as INpo;

  applicationPeriod: IApplicationPeriod;
  application: IApplication;

  objectives: IObjective[] = [];
  activities: IActivity[] = [];

  districtCouncil: IDistrictCouncil;
  localMunicipality: ILocalMunicipality;
  regions: IRegion[];
  sdas: ISDA[];
  purposeQuestion: string;
  menuActions: MenuItem[];
  validationErrors: Message[];
  qcItems: MenuItem[];
  qcItemsFunded: MenuItem[];

  qcFunded: number;

  amount: number;

  departments: IDepartment[];
  selectedDepartment: IDepartment;
  selectedProfileDepartment: any;
  departments1: IDepartment[];
  displayDepartmentDialog: boolean;
  sourceOfInformation: ISourceOfInformation[];
  affliatedOrganisationInfo: IAffiliatedOrganisation[];
  programDeliveryDetails : IProgrammeServiceDelivery[];
  selectedProgramDeliveryDetails : IProgrammeServiceDelivery[];
  selectedDepartmentId: number;
  isSystemAdmin: boolean;
  isDepartmentAdmin: boolean;
  isAdmin: boolean;
  isApplicant: boolean;
  step: number;
  fundingApplicationDetails: IFundingApplicationDetails = {
    applicationDetails: {
      fundAppSDADetail: {
        districtCouncil: {} as IDistrictCouncil,
        localMunicipality: {} as ILocalMunicipality,
        regions: [],
        serviceDeliveryAreas: [],
      } as IFundAppSDADetail
    } as IApplicationDetails,
    projectInformation: {} as IProjectInformation
  } as IFundingApplicationDetails;

  activeStep: number = 0;

  @ViewChild(CreateQuickCaptureComponent) organisationDetails: CreateQuickCaptureComponent;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _npoProfile: NpoProfileService,
    private _applicationRepo: ApplicationService,
    private _messageService: MessageService,
    private _dropdownRepo: DropdownService,
    private _departmentService: DepartmentService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.AddApplication))
          this._router.navigate(['401']);
        if(this.profile.departments[0].name === 'Health and Wellness')
        {
          this.qCStepsFunded();
          this.qcFunded = 1;
        }
        else{
          this.qCSteps();
          this.qcFunded = 0;
        }

        this.isSystemAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
        this.isDepartmentAdmin = profile.roles.some(function (role) { return role.id === RoleEnum.Admin });
        this.isApplicant = profile.roles.some(function (role) { return role.id === RoleEnum.Applicant });

        if(this.isSystemAdmin)
        {
          this.displayDepartmentDialog = true;
        }

        this.buildMenu();
      }
    });
    this.loadDepartments1();
    if(this.qcFunded === 0)
    {
      this.getProgrammeDeliveryDetails();
    }  
    
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        {
          label: 'Validate',
          icon: 'fa fa-check',
          command: () => {
            // this.formValidate();
          },
          visible: false
        },
        {
          label: 'Clear Messages',
          icon: 'fa fa-undo',
          command: () => {
            this.clearMessages();
          },
          visible: false
        },
        {
          label: 'Save',
          icon: 'fa fa-floppy-o',
          command: () => {
            this.bidForm(StatusEnum.Saved);
          }
        },
        // {
        //   label: 'Submit',
        //   icon: 'fa fa-thumbs-o-up',
        //   command: () => {
        //     this.bidForm(StatusEnum.PendingReview);
        //   }
        // },
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            //this._router.navigateByUrl('application-periods');
            this._router.navigateByUrl('/');
          }
        }
      ];
    }
  }

  selectedDept(id: number = 0)
  {
    this.selectedDepartmentId = id;
    this._departmentService.selectedDept(id);
  }

  onSelectedDepartment() {   
    if(this.selectedDepartmentId === Number(DepartmentEnum.DSD))
    {
      this.qCSteps();
      this.qcFunded = 0;
    }
    else{
      this.qCStepsFunded();
      this.qcFunded = 1;
    }
    this.displayDepartmentDialog = false;
  }

  onCloseDialog()
  {
    this._router.navigateByUrl('/');
  }

  private loadDepartments1() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Departments, false).subscribe(
      (results) => {
        this.departments1 = results;
        this.departments1 = results.filter(x => x.id != DepartmentEnum.ALL && x.id != DepartmentEnum.NONE);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
 
  disableButton()
 {
  if (!this.selectedDepartment)
    return true;

  return false;
 }
  private getProgrammeDeliveryDetails() {
    this._npoProfile.getProgrammeDeliveryDetailsQC(Number(this.npo.id)).subscribe(
      (results) => {
        if (results != null) {
         this.programDeliveryDetails =  results.filter(deliveryDetail => deliveryDetail.isActive && deliveryDetail.programId === this.applicationPeriod.programmeId && deliveryDetail.subProgrammeId === this.applicationPeriod.subProgrammeId && deliveryDetail.subProgrammeTypeId === this.applicationPeriod.subProgrammeTypeId);
         this.selectedProgramDeliveryDetails = results.filter(deliveryDetail => deliveryDetail.isActive && deliveryDetail.programId === this.applicationPeriod.programmeId && deliveryDetail.subProgrammeId === this.applicationPeriod.subProgrammeId && deliveryDetail.subProgrammeTypeId === this.applicationPeriod.subProgrammeTypeId && deliveryDetail.isSelected === true);
        } 
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
      });
  }

  private bidForm(status: StatusEnum) {

    if(this.application === undefined)
    {
      this._messageService.add({ severity: 'error', summary: 'missing compulsory steps', detail: 'Complete Applications, Organisation Details, Application Detail steps' });
      return false;
    }
    
    switch (this.activeStep) {
      case 0:
          case 1:
            case 2: {
              this._messageService.add({ severity: 'error', summary: 'missing compulsory steps', detail: 'Click on next button before saving the data' });
              return false;
      }
    }

    if (this.bidCanContinue(status)) {
      this._spinner.show();     
          this.application.statusId = status;
          this.application.isQuickCapture = true;
          this.applicationPeriod = this.applicationPeriod;
          this._applicationRepo.updateApplication(this.application).subscribe(
            (resp) => {
              this._spinner.hide();

              if (status === StatusEnum.Saved)
                this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });

            //  if (status === StatusEnum.PendingReview)
                this._router.navigateByUrl('applications');
            },   
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }


  private bidCanContinue(status: StatusEnum) {
    
    this.validationErrors = [];
    if (status === StatusEnum.Saved)
    {
      var orgDetailsError = this.validateOrganisationDetails();

     }
      
    if (status === StatusEnum.PendingReview) {
      var applicationError = this.validateApplications();
      var orgDetailsError = this.validateOrganisationDetails();

    }

    if (orgDetailsError.length > 0) {
      this.validationErrors.push({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });
      this.organisationDetails.setValidated(true);
    }


    if (status === StatusEnum.PendingReview) {
      if (applicationError.length > 0) {
        this.validationErrors.push({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });
      }

     }

    if (this.validationErrors.length > 0)
      this._messageService.add({ severity: 'error', summary: 'Error', detail: 'Please scroll to top to view errors.' });

    this.menuActions[1].visible = this.validationErrors.length > 0 ? true : false;
    return this.validationErrors.length === 0 ? true : false;
  }

  private validateOrganisationDetails() {
    let data = this.npo;
    let orgDetailsError: string[] = [];

    if (!data.name || !data.organisationTypeId || !data.registrationStatusId)
      orgDetailsError.push("Organisation detail missing");

    return orgDetailsError;
  }

  private validateApplications() {
    let data = this.applicationPeriod;
    let applicationError: string[] = [];

    if (!data)
      applicationError.push("Please select a programme from the list provided");

    return applicationError;
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
    this.organisationDetails.setValidated(false);
  }
  private qCSteps() {
    this.qcItems = [
      { label: 'Applications'},
      { label: 'Organisation Details'},      
      { label: 'Application Details'},
      { label: 'Document Link'}
    ];
  }

  private qCStepsFunded() {
    this.qcItemsFunded = [   
      { label: 'Applications' },    
      { label: 'Organisation Details' },             
      { label: 'Application Detail' },
      { label: 'Objectives' },
      { label: 'Activities' },
      { label: 'Application Document' }
    ];
  }

  public validateStep(goToStep: number, currentStep: number) {
    if (goToStep > currentStep) {
      switch (currentStep) {
        case QCStepsEnum.Applications: {
          var orgDetailsError = this.validateOrganisationDetails();
          var applicationError = this.validateApplications();

          if (orgDetailsError.length > 0 || applicationError.length > 0) {

            if (orgDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });

            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsEnum.NpoCreate: {
          var orgDetailsError = this.validateOrganisationDetails();

          if (orgDetailsError.length > 0) {
            this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });
            this.organisationDetails.setValidated(true);
            break;
          }

          this.activeStep = goToStep;
          break;
        }       
        case QCStepsEnum.AmountYouApplyingFor: {
          var orgDetailsError = this.validateOrganisationDetails();
          var applicationError = this.validateApplications();

            if (orgDetailsError.length > 0 || applicationError.length > 0) {

            if (orgDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });

            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsEnum.ApplicationDocument: {
          this.activeStep = goToStep;
          break;
        }
      }
    }
    else
      this.activeStep = goToStep;
  }

  public validateStepFunded(goToStep: number, currentStep: number) {
    this.step = currentStep;
    if (goToStep > currentStep) {
      switch (currentStep) {
        case QCStepsFundedEnum.Applications: {
         
          var applicationError = this.validateApplications();

          if (orgDetailsError.length > 0 || applicationError.length > 0) {

           if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });           
            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.NpoCreate: {
        
          var orgDetailsError = this.validateOrganisationDetails();
          var orgDetailsError = this.validateOrganisationDetails();

          if (orgDetailsError.length > 0) {
            this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            this.organisationDetails.setValidated(true);
            break;
          }

          this.activeStep = goToStep;
          break;
        }      
        case QCStepsFundedEnum.ApplicationDetail: {
          var applicationError = this.validateApplications();
          var orgDetailsError = this.validateOrganisationDetails();         

          if (orgDetailsError.length > 0 || applicationError.length > 0) {

            if (orgDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });
            
            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Objectives: {
          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.Activities: {
          var applicationError = this.validateApplications();
          var orgDetailsError = this.validateOrganisationDetails();         

          if (applicationError.length > 0 || orgDetailsError.length > 0) {

            if (applicationError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Applications:", detail: applicationError.join('; ') });
           
            if (orgDetailsError.length > 0)
              this._messageService.add({ severity: 'error', summary: "Organisation Details:", detail: orgDetailsError.join('; ') });

            
            break;
          }

          this.activeStep = goToStep;
          break;
        }
        case QCStepsFundedEnum.ApplicationFundedDocument: {
          this.activeStep = goToStep;
          break;
        }
      }
    }
    else
      this.activeStep = goToStep;
  }

  public loadObjectives() {
    this._applicationRepo.getAllObjectives(this.application).subscribe(
      (results) => {
        this.objectives = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  public loadActivities() {
    this._applicationRepo.getAllActivities(this.application).subscribe(
      (results) => {
        this.activities = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
