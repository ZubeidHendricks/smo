import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem, Message, MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { DropdownTypeEnum, FrequencyEnum, PermissionsEnum } from 'src/app/models/enums';
import { IActivity, IFinancialYear, IFrequency, IUser, IWorkplanTarget } from 'src/app/models/interfaces';
import { ApplicationService } from 'src/app/services/api-services/application/application.service';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
import { IndicatorService } from 'src/app/services/api-services/indicator/indicator.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-targets',
  templateUrl: './targets.component.html',
  styleUrls: ['./targets.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class TargetsComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  public get FrequencyEnum(): typeof FrequencyEnum {
    return FrequencyEnum;
  }

  profile: IUser;
  validationErrors: Message[];

  menuActions: MenuItem[];
  paramSubcriptions: Subscription;
  id: string;

  activity: IActivity;
  isDataAvailable: boolean;

  financialYears: IFinancialYear[];
  selectedFinancialYear: IFinancialYear;

  frequencies: IFrequency[];
  selectedFrequency: IFrequency;

  workplanTargets: IWorkplanTarget[];
  selectedWorkplanTarget: IWorkplanTarget;

  // Highlight required fields on save click
  validated: boolean = false;

  constructor(
    private _spinner: NgxSpinnerService,
    private _applicationRepo: ApplicationService,
    private _activeRouter: ActivatedRoute,
    private _router: Router,
    private _authService: AuthService,
    private _dropdownRepo: DropdownService,
    private _indicatorRepo: IndicatorService,
    private _messageService: MessageService
  ) { }

  ngOnInit(): void {
    this.paramSubcriptions = this._activeRouter.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.loadActivity();
    });

    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        /*if (!this.IsAuthorized(PermissionsEnum.AddApplicationPeriod))
          this._router.navigate(['401']);*/

        this.loadFinancialYears();
        this.loadFrequencies();
        this.buildMenu();
      }
    });
  }

  private loadActivity() {
    this._spinner.show();
    this._applicationRepo.getActivityById(Number(this.id)).subscribe(
      (results) => {
        this.activity = results;
        this.loadTargets();
        this.isDataAvailable = true;
      },
      (err) => this._spinner.hide()
    );
  }

  private loadTargets() {
    this._indicatorRepo.getTargetsByActivityId(this.activity.id).subscribe(
      (results) => {
        this.workplanTargets = results;
        this._spinner.hide();
      },
      (error) => this._spinner.hide()
    );
  }

  private loadFinancialYears() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
      (results) => {
        this.financialYears = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private loadFrequencies() {
    this._spinner.show();
    this._dropdownRepo.getEntities(DropdownTypeEnum.Frequencies, false).subscribe(
      (results) => {
        this.frequencies = results;
        this._spinner.hide();
      },
      (err) => this._spinner.hide()
    );
  }

  private buildMenu() {
    this.menuActions = [
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
          this.saveItems();
        }
      },
      {
        label: 'Go Back',
        icon: 'fa fa-step-backward',
        command: () => {
          this._router.navigateByUrl('workplan-indicator/manage/' + this.activity.applicationId);
        }
      }
    ];
  }

  private clearMessages() {
    this.validated = false;
    this.validationErrors = [];
    this.menuActions[0].visible = false;
  }

  private saveItems() {
    if (this.canContinue()) {
      this._spinner.show();

      this._indicatorRepo.manageTarget(this.selectedWorkplanTarget).subscribe(resp => {
        this.loadTargets();
        this._messageService.add({ severity: 'success', summary: 'Successful', detail: 'Information successfully saved.' });
      });      
    }
  }

  private canContinue() {
    this.validationErrors = [];
    this.formValidate();

    if (this.validationErrors.length == 0) {
      this.validated = false;
      return true;
    }

    return false;
  }

  private formValidate() {
    this.validated = true;
    this.validationErrors = [];

    let hasTargetErrors: boolean[] = [];

    if (!this.selectedFinancialYear || !this.selectedFrequency)
      hasTargetErrors.push(true);

    if (this.selectedFrequency && this.selectedFrequency.id == FrequencyEnum.Annually) {
      if (this.selectedWorkplanTarget.annual == null)
        hasTargetErrors.push(true);
    }

    if (this.selectedFrequency && this.selectedFrequency.id == FrequencyEnum.Monthly) {
      if (this.selectedWorkplanTarget.apr == null || this.selectedWorkplanTarget.may == null || this.selectedWorkplanTarget.jun == null || this.selectedWorkplanTarget.jul == null || this.selectedWorkplanTarget.aug == null || this.selectedWorkplanTarget.sep == null || this.selectedWorkplanTarget.oct == null || this.selectedWorkplanTarget.nov == null || this.selectedWorkplanTarget.dec == null || this.selectedWorkplanTarget.jan == null || this.selectedWorkplanTarget.feb == null || this.selectedWorkplanTarget.mar == null)
        hasTargetErrors.push(true);
    }

    if (this.selectedFrequency && this.selectedFrequency.id == FrequencyEnum.Quarterly) {
      if (this.selectedWorkplanTarget.quarter1 == null || this.selectedWorkplanTarget.quarter2 == null || this.selectedWorkplanTarget.quarter3 == null || this.selectedWorkplanTarget.quarter4 == null)
        hasTargetErrors.push(true);
    }

    if (hasTargetErrors.includes(true))
      this.validationErrors.push({ severity: 'error', summary: "Targets:", detail: "Missing detail required." });

    if (this.validationErrors.length == 0)
      this.menuActions[0].visible = false;
    else
      this.menuActions[0].visible = true;
  }

  financialYearChange() {
    this.findTarget();
  }

  frequencyChange() {
    this.findTarget();
  }

  private findTarget() {
    if (this.selectedFinancialYear && this.selectedFrequency) {
      this.selectedWorkplanTarget = this.getSelectedTarget();

      if (!this.selectedWorkplanTarget) {
        let target = {
          activityId: this.activity.id,
          financialYearId: this.selectedFinancialYear.id,
          frequencyId: this.selectedFrequency.id
        } as IWorkplanTarget;

        this.selectedWorkplanTarget = target;
      }
    }
  }

  private getSelectedTarget(): IWorkplanTarget {
    let selectedWorkplanTarget = this.workplanTargets.find(x => x.activityId == this.activity.id && x.financialYearId == this.selectedFinancialYear.id && x.frequencyId == this.selectedFrequency.id);
    return selectedWorkplanTarget;
  }
}
