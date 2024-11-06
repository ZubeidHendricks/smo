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
import { dtoFundingAssessmentApplicationFormGet, dtoFundingAssessmentApplicationGet, dtoFundingAssessmentFormQuestionResponseUpsert, dtoQuestionGet } from 'src/app/services/api-services/funding-assessment-management/dtoFundingAssessmentManagement';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FundingAssessmentUIEventsService } from '../funding-assessment-ui-events.service';

@Component({
  selector: 'app-funding-assessment-form-questionsection',
  templateUrl: './funding-assessment-form-questionsection.component.html',
  styleUrls: ['./funding-assessment-form-questionsection.component.css'],
  providers: [MessageService, ConfirmationService]
})
export class FundingAssessmentFormQuestionSectionComponent implements OnInit {
  @Input() Questions: dtoQuestionGet;
  @Input() AssessmentApplicationFormId: number;
  @Input() HeaderName: string;
  @Input() FinalCommentRequired: boolean = false;

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



  }

  onQuestionChange(question: dtoQuestionGet) {
    let response = {
      id: question.id,
      assessmentApplicationFormId: this.AssessmentApplicationFormId,
      selectedResponseOptionId: question.selectedResponseOptionId,
      selectedResponseRatingId: question.selectedResponseRatingId,
      comment: question.comment
    } as dtoFundingAssessmentFormQuestionResponseUpsert;

    this._repo.upsertQuestionResponse(response).subscribe(x => {
        this.uiEvents.onResponseChanged();
    });
  }


}
