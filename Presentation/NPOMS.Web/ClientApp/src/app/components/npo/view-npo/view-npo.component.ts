import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { IContactInformation, IGender, INpo, IRace } from 'src/app/models/interfaces';
import { DropdownService } from 'src/app/services/api-services/dropdown/dropdown.service';
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
  selectedRace: string;
  selectedGender: string;
  selectedLanguage: string;

  minDate: Date;
  maxDate: Date;

  // Highlight required fields on validate click
  validated: boolean = true;

  constructor(
    private _npoRepo: NpoService,
    private _spinner: NgxSpinnerService,
    private _dropdownRepo: DropdownService,
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
    debugger;
    if (this.npoId != null) {
      this._npoRepo.getNpoById(Number(this.npoId)).subscribe(
        (results) => {
          this.retrievedNpo.emit(results);
          this.npo = results;
          this.isDataAvailable = true;
          this._spinner.hide();
        },
        (err) => {
          this._loggerService.logException(err);
          this._spinner.hide();
        }
      );
    }
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
    console.log('data',data);
    console.log('data',data.gender.name);
    console.log('data',data.race.name);
    console.log('data',data.language.name);
    this.selectedGender = data.gender.name;
    this.selectedRace = data.race.name;
    this.selectedLanguage = data.language.name;

    return contactInfo;
  }
}
