import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ApplicationTypeEnum, PermissionsEnum, RoleEnum, ServiceProvisionStepsEnum, StatusEnum } from 'src/app/models/enums';
import { ApplicationWithUsers, IActivity, IApplication, IApplicationApproval, IApplicationPeriod, IObjective, IResource, ISustainabilityPlan, IUser } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { UserService } from 'src/app/services/api-services/user/user.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-approve-application',
  templateUrl: './approve-application.component.html',
  styleUrls: ['./approve-application.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class ApproveApplicationComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get ApplicationTypeEnum(): typeof ApplicationTypeEnum {
    return ApplicationTypeEnum;
  }

  public get ServiceProvisionStepsEnum(): typeof ServiceProvisionStepsEnum {
    return ServiceProvisionStepsEnum;
  }

  paramSubcriptions: Subscription;
  id: string;

  menuActions: MenuItem[];
  profile: IUser;
  validationErrors: Message[];

  items: MenuItem[] = [];

  activeStep: number = 0;
  application: IApplication;
  isApplicationAvailable: boolean;
  isStepsAvailable: boolean;
  applicationWithUsers = {} as ApplicationWithUsers;

  objectives: IObjective[] = [];
  activities: IActivity[] = [];
  sustainabilityPlans: ISustainabilityPlan[] = [];
  resources: IResource[] = [];

  status: StatusEnum;
  approvalFrom: string;
  isApprover: boolean;
  isSystemAdmin: boolean;
  isAdmin: boolean;
  canReviewOrApprove: boolean;
  selectedReviewers: { fullName: string, email: string, id: number }[] = [];

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _spinner: NgxSpinnerService,
    private _activeRouter: ActivatedRoute,
    private _applicationRepo: ApplicationService,
    private _loggerService: LoggerService,
    private _userRepo: UserService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadApplication();
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ApproveApplication))
          this._router.navigate(['401']);

        this.updateSteps();
        this.buildMenu();
      }
    });
  }

  onSelectedReviewersChange(reviewers: { fullName: string, email: string, id: number }[]) {
    this.selectedReviewers = reviewers;
  }

  private loadApplication() {
    this._spinner.show();
    this._applicationRepo.getApplicationById(Number(this.id)).subscribe(
      (results) => {
        if (results != null) {
          this.application = results;
          this.buildSteps(results.applicationPeriod);
          this.loadObjectives();
          this.loadActivities();
          this.loadSustainabilityPlans();
          this.loadResources();
          this.loadCreatedUser();
          this.isApplicationAvailable = true;
        }

        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadCreatedUser() {
    this._userRepo.getUserById(this.application.createdUserId).subscribe(
      (results) => {
        this.application.createdUser = results;
        this.loadUpdatedUser();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadUpdatedUser() {
    if (this.application.updatedUserId) {
      this._userRepo.getUserById(this.application.updatedUserId).subscribe(
        (results) => {
          this.application.updatedUser = results;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
    else {
      this.application.updatedUser = {} as IUser;
      this._spinner.hide();
    }
  }

  private buildSteps(applicationPeriod: IApplicationPeriod) {
    if (applicationPeriod != null) {
      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.SP) {
        this.items = [
          { label: 'Organisation Details' },
          { label: 'Objectives' },
          { label: 'Activities' },
          { label: 'Sustainability' },
          { label: 'Resourcing' }
        ];

        this.updateSteps();
      }

      if (applicationPeriod.applicationTypeId === ApplicationTypeEnum.FA) {
        this.items = [
          { label: 'Organisation Details' }
        ];
      }
    }
  }

  private updateSteps() {
    if (this.profile != null) {
      this.isSystemAdmin = this.profile.roles.some(function (role) { return role.id === RoleEnum.SystemAdmin });
      this.isAdmin = this.profile.roles.some(function (role) { return role.id === RoleEnum.Admin });
      this.isApprover = this.profile.roles.some(function (role) { return role.id === RoleEnum.Approver });

      // Add confirmation step if Approver
      if (this.isSystemAdmin || this.isAdmin || this.isApprover) {
        this.items.push({ label: 'Confirmation' });
        this.canReviewOrApprove = true;
      }

      this.isStepsAvailable = true;
    }
  }

  private loadObjectives() {
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

  private loadActivities() {
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

  private loadSustainabilityPlans() {
    this._applicationRepo.getAllSustainabilityPlans(this.application).subscribe(
      (results) => {
        this.sustainabilityPlans = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private loadResources() {
    this._applicationRepo.getAllResources(this.application).subscribe(
      (results) => {
        this.resources = results.filter(x => x.isActive === true);
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private buildMenu() {
    if (this.profile) {
      this.menuActions = [
        {
          label: 'Validate',
          icon: 'fa fa-check',
          command: () => {
            this.formValidate();
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
            this._router.navigateByUrl('applications');
          },
          visible: false
        },
        {
          label: 'Submit',
          icon: 'fa fa-thumbs-o-up',
          command: () => {
            if (this.status) {
              this.saveItems(this.status,this.selectedReviewers);
            }
          }
        },
        {
          label: 'Go Back',
          icon: 'fa fa-step-backward',
          command: () => {
            this._router.navigateByUrl('applications');
          }
        }
      ];
    }
  }

  private formValidate() {
    this.validationErrors = [];

    if (!this.status || !this.approvalFrom)
      this.validationErrors.push({ severity: 'error', summary: "Confirmation:", detail: "Please select an option." });

    if (this.validationErrors.length == 0)
      this.menuActions[1].visible = false;
    else
      this.menuActions[1].visible = true;
  }

  private clearMessages() {
    this.validationErrors = [];
    this.menuActions[1].visible = false;
  }

  private saveItems(status: StatusEnum, selectedReviewers: { fullName: string, email: string, id: number }[]) {
    if (this.canContinue()) {
      this._spinner.show();
      this.application.statusId = status;

      if (status === StatusEnum.PendingSLA) {
        this.application.statusId = StatusEnum.ApprovalInProgress;
      }

      let applicationApproval = {
        applicationId: this.application.id,
        statusId: status,
        approvedFrom: this.approvalFrom,
        isActive: status === StatusEnum.PendingSLA ? true : false
      } as IApplicationApproval;

      this._applicationRepo.createApplicationApproval(applicationApproval).subscribe(
        (resp) => {
          let approvedByCoCT = resp.some(function (approval) { return approval.approvedFrom === 'CoCT' });
          let approvedByDoH = resp.some(function (approval) { return approval.approvedFrom === 'DoH' });

          if (approvedByCoCT && approvedByDoH)
            this.application.statusId = StatusEnum.PendingSLA;
          // this._applicationRepo.updateApplication(this.application).subscribe(
          //   (resp) => {
          //     this._spinner.hide();
          //     this._router.navigateByUrl('applications');
          //   },
          //   (err) => {
          //     this._loggerService.logException(err);
          //     this._spinner.hide();
          //   }
          // );

          if(selectedReviewers.length > 0){
            this.applicationWithUsers.application = this.application;
            this.applicationWithUsers.userVM = selectedReviewers;
            this._applicationRepo.updateApplicationWithApprovers(this.applicationWithUsers).subscribe(
              (resp) => {
                this._spinner.hide();
                this._router.navigateByUrl('applications');
              },
              (err) => {
                this._loggerService.logException(err);
                this._spinner.hide();
              }
            );
          }
          else{
            this._applicationRepo.updateApplication(this.application).subscribe(
              (resp) => {
                this._spinner.hide();
                this._router.navigateByUrl('applications');
              },
              (err) => {
                this._loggerService.logException(err);
                this._spinner.hide();
              }
            );
          }
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private canContinue() {
    this.validationErrors = [];
    this.formValidate();

    if (this.validationErrors.length == 0)
      return true;

    return false;
  }
}
