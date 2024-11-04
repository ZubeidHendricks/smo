import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { Table } from 'primeng/table';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { FundingAssessmentManagementService } from 'src/app/services/api-services/funding-assessment-management/funding-assessment-management.service';
import { PermissionsEnum } from 'src/app/models/enums';
import { IApplication, IUser } from 'src/app/models/interfaces';
import { dtoFundingAssessmentApplicationFormGet, dtoFundingAssessmentApplicationGet } from 'src/app/services/api-services/funding-assessment-management/dtoFundingAssessmentManagement';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FundingAssessmentUIEventsService } from '../funding-assessment-ui-events.service';

@Component({
  selector: 'app-funding-assessment-list',
  templateUrl: './funding-assessment-list.component.html',
  styleUrls: ['./funding-assessment-list.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class FundingAssessmentListComponent implements OnInit {

  /* Permission logic */
  public IsAuthorized(permission: PermissionsEnum): boolean {
    if (this.profile != null && this.profile.permissions.length > 0) {
      return this.profile.permissions.filter(x => x.systemName === permission).length > 0;
    }
  }

  public get PermissionsEnum(): typeof PermissionsEnum {
    return PermissionsEnum;
  }

  profile: IUser;
  _selectedApplicationId: number;

  _buttonItems: MenuItem[];
  _selectedAssessmentApplication: dtoFundingAssessmentApplicationGet;
  _fundingAssessments: dtoFundingAssessmentApplicationGet[];
  _fundingAssessmentForm: dtoFundingAssessmentApplicationFormGet;
  _showDOIDialog: boolean = false;
  _doiApprover: boolean = false;
  _showFundingAssessmentForm: boolean = false;


  npoForm: FormGroup;
  subPlaces: any[] = []; // Your subPlaces data
  question1: any; // Question1 data model
  question2: any; // Question2 data model
  doiApprover: boolean = false; // Declaration of Interest approver checkbox



  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;

  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _repo: FundingAssessmentManagementService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService,
    private _confirmationService: ConfirmationService,
    private _messageService: MessageService,
    private fb: FormBuilder,
    private uiEvents: FundingAssessmentUIEventsService
  ) { }

  ngOnInit(): void {
    this._authService.profile$.subscribe(profile => {
      if (profile != null && profile.isActive) {
        this.profile = profile;

        if (!this.IsAuthorized(PermissionsEnum.ViewFundingAssessmentMenu))
          this._router.navigate(['401']);
      }

      this.loadFundingAssessments();
      this.buildButtonItems();

    // Subscribe to the event from the service
    this.uiEvents.onResponseChanged$.subscribe(() => {
      // Code to execute when the event is triggered
      this._repo.getFundingAssessmentApplicationForm(this._selectedApplicationId).subscribe(
        (result) => {
          this._fundingAssessmentForm = result;
        },
        (err) => {
          this._loggerService.logException(err);
        }
      );
    });
  });
  }

  loadFundingAssessments() {
    this._spinner.show();
    this._repo.getFundingAssessmentApplications().subscribe(
      (result) => {
        this._fundingAssessments = result;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

  }

  applyFilterGlobal($event: any, stringVal: any) {
    this.dt!.filterGlobal(($event.target as HTMLInputElement).value, stringVal);
  }

  private buildButtonItems() {
    this._buttonItems = [];

    if (this.profile) {
      this._buttonItems = [{
        label: 'Actions',
        items: []
      }];


      this._buttonItems[0].items.push({
        label: 'Declaration Of Interest',
        icon: 'fa fa-pencil-square-o',
        command: () => {
            this._showDOIDialog = true;
        }
      });

      this._buttonItems[0].items.push({
        label: 'Funding Assessment',
        icon: 'fa fa-pencil-square-o',
        command: () => {
        
          this._spinner.show();
          this._repo.getFundingAssessmentApplicationForm(this._selectedApplicationId).subscribe(
            (result) => {
              this._fundingAssessmentForm = result;
              this._showFundingAssessmentForm = true;
              this._spinner.hide();
            },
            (err) => {
              this._loggerService.logException(err);
              this._spinner.hide();
            }
          );
        }
      });
    }
  }

  showDOIDialog(application: dtoFundingAssessmentApplicationGet)
  {
    this._selectedApplicationId = application.applicationId;
    this._selectedAssessmentApplication = application;
    this._showDOIDialog = true
  }

  showFundingAssessmentForm(application: dtoFundingAssessmentApplicationGet)
  {
    this._selectedApplicationId = application.applicationId;
    this._selectedAssessmentApplication = application;

    this._spinner.show();
    this._repo.getFundingAssessmentApplicationForm(this._selectedApplicationId).subscribe(
      (result) => {
        this._fundingAssessmentForm = result;
        this._showFundingAssessmentForm = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  onConfirmDOI()
  {
    this._spinner.show();
    this._repo.updateDOICapturer(this._selectedApplicationId).subscribe(
      (result) => {
        this._showDOIDialog = false;
        this._spinner.hide();

        this.showFundingAssessmentForm(this._selectedAssessmentApplication)
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
}
