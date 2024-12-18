import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthService } from 'src/app/services/auth/auth.service';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { Table } from 'primeng/table';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { FundingAssessmentManagementService } from 'src/app/services/api-services/funding-assessment-management/funding-assessment-management.service';
import { PermissionsEnum } from 'src/app/models/enums';
import { IUser } from 'src/app/models/interfaces';
import { dtoFundingAssessmentApplicationFormFinalApproverItemGet, dtoFundingAssessmentApplicationFormGet, dtoFundingAssessmentApplicationFormSDAGet, dtoFundingAssessmentApplicationFormSDAUpsert, dtoFundingAssessmentApplicationFormSummaryItemGet, dtoFundingAssessmentApplicationGet, dtoFundingAssessmentFormQuestionResponseUpsert } from 'src/app/services/api-services/funding-assessment-management/dtoFundingAssessmentManagement';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FundingAssessmentUIEventsService } from '../funding-assessment-ui-events.service';

@Component({
  selector: 'app-funding-assessment-form',
  templateUrl: './funding-assessment-form.component.html',
  styleUrls: ['./funding-assessment-form.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class FundingAssessmentFormComponent implements OnInit {
 @Input() fundingAssessmentForm: dtoFundingAssessmentApplicationFormGet;



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

  _buttonItems: MenuItem[];
  _fundingAssessments: dtoFundingAssessmentApplicationGet[];
  _showDOIDialog: boolean = false;
  _showSubmitDialog: boolean = false;
  _showEndDialog: boolean = false;
  _doiApprover: boolean = false;
  _showFundingAssessment: boolean = false;


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
  //    this.loadFundingAssessments();
      this.buildButtonItems();

      this.npoForm = this.fb.group({
        NpoName: [''],
        CCID: [''],
        Question1SelectionList1Value: [''],
        Question1RatingValue: [''],
        Question2SelectionList1Value: [''],
        Question2RatingValue: [''],
        LegislativeComplianceFinding: [''],
        LegislativeComplianceOverallRating: [''],
        LegislativeComplianceApproval: ['']
      });
    });
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
          this._showFundingAssessment = true;
        }
      });

    }
  }

  getLegislativeCompliance()
  {
     return this.fundingAssessmentForm.questions.filter(x=>x.questionSectionName==="Legislative Compliance");
  }

  getPFMACompliance()
  {
     return this.fundingAssessmentForm.questions.filter(x=>x.questionSectionName==="PFMA Compliance");
  }

  getAnalysisPerformance()
  {
     return this.fundingAssessmentForm.questions.filter(x=>x.questionSectionName==="Analysis Of Performance");
  }

  onSummaryChange(summaryItem: dtoFundingAssessmentApplicationFormSummaryItemGet){


        let response = {
          id: summaryItem.id,
          assessmentApplicationFormId: this.fundingAssessmentForm.id,
          selectedResponseOptionId: summaryItem.selectedResponseOptionId,
          selectedResponseRatingId: null,
          comment: null
        } as dtoFundingAssessmentFormQuestionResponseUpsert;
    
        this._repo.upsertQuestionResponse(response).subscribe(x => {
          this.uiEvents.onResponseChanged();
        });
  }

  onServiceDeliveryAreaModelChange(event: any, dto: dtoFundingAssessmentApplicationFormSDAGet){
   let dtoPayload = {id: dto.id, fundingAssessmentFormId: this.fundingAssessmentForm.id, programServiceDeliveryAreaId: dto.programServiceDeliveryAreaId, isSelected: dto.isSelected} as dtoFundingAssessmentApplicationFormSDAUpsert;
    this._repo.upsertSDA(this.fundingAssessmentForm.id, this.fundingAssessmentForm.applicationId, dtoPayload).subscribe(x => {
      this.uiEvents.onResponseChanged();   
    });
  }

  onFinalApproverChange(finalApprovalItem: dtoFundingAssessmentApplicationFormFinalApproverItemGet){


    let response = {
      id: finalApprovalItem.id,
      assessmentApplicationFormId: this.fundingAssessmentForm.id,
      selectedResponseOptionId: finalApprovalItem.selectedResponseOptionId,
      selectedResponseRatingId: null,
      comment: finalApprovalItem.comment
    } as dtoFundingAssessmentFormQuestionResponseUpsert;

    this._repo.upsertQuestionResponse(response).subscribe(x => {
      this.uiEvents.onResponseChanged();
    });
  }

  confirmSubmit()
  {
    if(this.fundingAssessmentForm.canEndAssessment)
    {
      this._showEndDialog = true;
    }
    else{
      this._showSubmitDialog = true;
    }
   
  }

  onConfirmEndSubmit()
  {
    this._spinner.show();
    this._repo.onSubmitEndForm(this.fundingAssessmentForm.applicationId).subscribe(
      (result) => {
        this._showSubmitDialog = false;
        this._spinner.hide();

        window.location.reload();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  
  onConfirmSubmit()
  {
    this._spinner.show();
    this._repo.onSubmitForm(this.fundingAssessmentForm.applicationId).subscribe(
      (result) => {
        this._showSubmitDialog = false;
        this._spinner.hide();

        window.location.reload();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  onDOIApproverConfirm()
  {
    this._spinner.show();
    this._repo.updateDOIApprover(this.fundingAssessmentForm.applicationId).subscribe(
      (result) => {

        this._spinner.hide();

        this.uiEvents.onResponseChanged();
        
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );

  }

}
