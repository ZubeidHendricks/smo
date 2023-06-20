import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuditorOrAffiliationEnum } from 'src/app/models/enums';
import { IAuditorOrAffiliation, IContactInformation, INpo } from 'src/app/models/interfaces';
import { NpoService } from 'src/app/services/api-services/npo/npo.service';
import { LoggerService } from 'src/app/services/logger/logger.service';

@Component({
  selector: 'app-view-npo',
  templateUrl: './view-npo.component.html',
  styleUrls: ['./view-npo.component.css']
})
export class ViewNpoComponent implements OnInit {

  @Input() npoId: number;
  @Output() retrievedNpo: EventEmitter<INpo> = new EventEmitter<INpo>();

  npo: INpo;
  isDataAvailable: boolean = false;
  contactCols: any[];
  stateOptions: any[];

  contactInformation: IContactInformation = {} as IContactInformation;
  displayContactDialog: boolean;

  selectedTitle: string;
  selectedPosition: string;

  auditorOrAffiliations: IAuditorOrAffiliation[];
  auditorCols: any[];
  auditorOrAffiliation: IAuditorOrAffiliation = {} as IAuditorOrAffiliation;
  displayAuditorDialog: boolean;

  // Highlight required fields on validate click
  validated: boolean = true;

  constructor(
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService,
    private _loggerService: LoggerService
  ) { }

  ngOnInit(): void {
    this.loadNpo();

    this.contactCols = [
      { header: 'Name', width: '30%' },
      { header: 'Position', width: '20%' },
      { header: 'Email', width: '30%' },
      { header: 'Cellphone', width: '15%' },
      { header: 'Actions', width: '5%' }
    ];

    this.auditorCols = [
      { header: 'Company', width: '20%' },
      { header: 'Registration Number', width: '15%' },
      { header: 'Address', width: '25%' },
      { header: 'Telephone Number', width: '10%' },
      { header: 'Email Address', width: '25%' },
      { header: 'Actions', width: '5%' }
    ];

    this.stateOptions = [
      {
        label: 'Yes',
        value: true
      },
      {
        label: 'No',
        value: false
      }
    ];
  }

  private loadNpo() {
    if (this.npoId != null) {
      this._npoRepo.getNpoById(Number(this.npoId)).subscribe(
        (results) => {
          this.npo = results;
          this.retrievedNpo.emit(results);
          console.log(results);
          this.loadAuditorOrAffiliations();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
  }

  private loadAuditorOrAffiliations() {
    this._npoRepo.getAuditorOrAffiliations(this.npo.id).subscribe(
      (results) => {
        this.auditorOrAffiliations = results.filter(x => x.entityType === AuditorOrAffiliationEnum.Auditor);
        this.isDataAvailable = true;
        this._spinner.hide();
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  viewContactInformation(data: IContactInformation) {
    this.contactInformation = this.cloneContactInformation(data);
    this.displayContactDialog = true;
  }

  private cloneContactInformation(data: IContactInformation): IContactInformation {
    let contactInfo = {} as IContactInformation;

    for (let prop in data)
      contactInfo[prop] = data[prop];

    this.selectedTitle = data.title.name;
    this.selectedPosition = data.position.name;

    return contactInfo;
  }

  public viewAuditorInformation(data: IAuditorOrAffiliation) {
    this.auditorOrAffiliation = this.cloneAuditorOrAffiliation(data);
    this.displayAuditorDialog = true;
  }

  private cloneAuditorOrAffiliation(data: IAuditorOrAffiliation): IAuditorOrAffiliation {
    let object = {} as IAuditorOrAffiliation;

    for (let prop in data)
      object[prop] = data[prop];

    return object;
  }
}
