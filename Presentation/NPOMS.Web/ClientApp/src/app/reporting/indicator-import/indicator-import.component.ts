
import { Component, ViewChild, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MenuItem, MessageService } from 'primeng/api';
import { HttpClient } from '@angular/common/http';  
import { BehaviorSubject, Observable } from 'rxjs';
import { Table } from 'primeng/table';
import { IDepartment, IFinancialYear, IIndicator, INPOIndicator, IWorkplanIndicator } from 'src/app/models/interfaces';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DropdownService } from 'src/app/services/dropdown/dropdown.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoggerService } from 'src/app/services/logger/logger.service';
import { DropdownTypeEnum } from 'src/app/models/enums';
import { DocumentStoreService } from 'src/app/services/api-services/document-store/document-store.service';


export interface IMonth
{ 
  id: number,
  name: string
}

export interface IYear
{ 
  year: string
}

@Component({
  selector: 'app-indicator-import',
  templateUrl: './indicator-import.component.html',
  styleUrls: ['./indicator-import.component.css']
})
export class IndicatorImportComponent implements OnInit {

  menuActions: MenuItem[] = [];
  _iDepartment: IDepartment[];
  selectedYear: number;
  years: any[] = [];
  months: any[] = [];
  _iYear: IYear[];
  _iMonth: IMonth[] = [];
  selectedMonth: number;
  selectedYr: any;
  selectedMo: any;
  selectedDept: any;
  selectedFile: File;
  csv: any;
  covidData: any[] = [];
  errorMessage: string;
  private _financialYears: IFinancialYear[];
  @Input()
  get financialYears(): IFinancialYear[] { return this._financialYears; }
  set financialYears(financialYears: IFinancialYear[]) { this._financialYears = financialYears; }
  selectedFinancialYear: IFinancialYear;
  yearSelected: boolean = false;

  indicatorCols: any[];
  NPOindicatorCols: any[];
  indicators: IIndicator[];
  npoIndicators: INPOIndicator[];

  constructor(
                private _router:Router,
                private http: HttpClient,
                private _authService: AuthService,
                private _dropdownRepo: DropdownService,
                private _spinner: NgxSpinnerService,
                private _confirmationService: ConfirmationService,
                private _messageService: MessageService,
                private _loggerService: LoggerService,
                private _documentStore: DocumentStoreService,
              
                //private _notificationService: NotificationToastService,
  ) { 

    this.selectedYear = new Date().getFullYear();
    const lastYear =  this.selectedYear-9;
    for (let year = this.selectedYear; year >= lastYear; year--) {
      this.years.push({year});
      this._iYear = this.years;
    }

    this.selectedMonth = new Date().getMonth();
    const lastMonth =  this.selectedMonth + 11;
    for (let month = this.selectedMonth; month <= lastMonth; month++) {
      if(month == 0)
      this.months.push({month:'Jan'});
      if(month == 1)
      this.months.push({month:'Feb'});
      if(month == 2)
      this.months.push({month:'Mar'});
      if(month == 3)
      this.months.push({month:'Apr'});
      if(month == 4)
      this.months.push({month:'May'});
      if(month == 5)
      this.months.push({month:'Jun'});
      if(month == 6)
      this.months.push({month:'Jul'});
      if(month == 7)
      this.months.push({month:'Aug'});
      if(month == 8)
      this.months.push({month:'Sep'});
      if(month == 9)
      this.months.push({month:'Oct'});
      if(month == 10)
      this.months.push({month:'Nov'});
      if(month == 11)
      this.months.push({month:'Dec'});

      this._iMonth = this.months;
    }
  }

  ngOnInit(): void {

    this.indicatorCols = [
      { header: ' Indicator Id', width: '10%' },
      { header: 'Indicator Description/Title', width: '10%' },
      { header: 'Output Title', width: '10%' },
      { header: 'Annual Target', width: '10%' },
      { header: 'Quarter 1', width: '10%' },
      { header: 'Quarter 2', width: '10%' },
      { header: 'Quarter 3', width: '10%' },
      { header: 'Quarter 4', width: '10%' },
      { header: 'Short Definition', width: '10%' },
      { header: 'Purpose', width: '10%' },
    ];

    this.NPOindicatorCols = [
      { header: ' C code', width: '10%' },
      { header: 'Organisation Name', width: '10%' },
      { header: 'Programme', width: '10%' },
      { header: 'SubprogrammeType', width: '10%' },
      { header: 'Indicator Id', width: '10%' },
      { header: 'Financial Year', width: '10%' },
      { header: 'Annual Target', width: '10%' },
      { header: 'Quarter 1', width: '10%' },
      { header: 'Quarter 2', width: '10%' },
      { header: 'Quarter 3', width: '10%' },
      { header: 'Quarter 4', width: '10%' }
    ];
    
    this._authService.profile$.subscribe(x=>{
      if(x)
      {
        let ids =  [];
        x.departments.forEach( (element) => {
          ids.push(element.id);
        });

        if (ids.length > 0)
          this.csv = ids.join(",");
        else
          this.csv = 0;
          this.NPOloadIndicators();
          this.buildMenu();
          this.loadDepartment();
          this.loadFinancialYears();
          this.loadIndicators();
      }
    });    

  }

  private loadIndicators() {
    this._dropdownRepo.getEntities(DropdownTypeEnum.Indicator, false).subscribe(
      (results) => {
        this.indicators = results;
      },
      (err) => {
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }

  private NPOloadIndicators() {
    console.log('Calling the API for Indicators');
    this._dropdownRepo.getEntities(DropdownTypeEnum.HighLevelNPO, false).subscribe(
      (results) => {
        console.log('Received results:', results);
        this.npoIndicators = results;
      },
      (err) => {
        console.error('Error fetching Indicators:', err);
        this._loggerService.logException(err);
        this._spinner.hide();
      }
    );
  }
  

  onFilterData()
  {
   this.loadVouchers();
  }
  loadVouchers()
  {
  }

setValue(value) 
{
  let selectedOnes =[];
  selectedOnes.push(value);

  if (selectedOnes.length > 0)
  this.selectedDept = selectedOnes.join(",");
  else
  this.selectedDept = "0";
}

private loadFinancialYears() {
  this._spinner.show();
  this._dropdownRepo.getEntities(DropdownTypeEnum.FinancialYears, false).subscribe(
    (results) => {
      this.financialYears = results;
      this._spinner.hide();
    },
    (err) => {
      this._loggerService.logException(err);
      this._spinner.hide();
    }
  );
}

public financialYearChange() {
  this.yearSelected =  true;
}


async onUploadIndicator(event, form) {
  if (this.selectedFinancialYear) {
    const selectedYear = this.selectedFinancialYear.year.toString(); 
    await this._documentStore.UploadFileToImportIndicator(event.files, selectedYear).subscribe(
      (error) => {
        this.errorMessage = 'An error occurred: ' + error;
      }
    );
  } else {
    this.errorMessage = 'Please select a financial year before uploading.';
  }
  form.clear();
  this.loadIndicators();
}

async onUploadNPOLevel(event, form) {
  if (this.selectedFinancialYear) {
    const selectedYear = this.selectedFinancialYear.year.toString(); 
    await this._documentStore.UploadFileToImportNPOLevel(event.files, selectedYear).subscribe(
      (error) => {
        this.errorMessage = 'An error occurred: ' + error;
      }
    );
  } else {
    this.errorMessage = 'Please select a financial year before uploading.';
  }
  form.clear();
  this.NPOloadIndicators();
}

  buildMenu()
  {
      this.menuActions.push({
            label: 'Add Email Template', icon: 'fa fa-plus', command: () => {
              //this.confirmAction('AddEmailTemplate');
            }
      });
  }
  setAuthorities(value) 
  {
    let selectedOnes =[];
    selectedOnes.push(value);
  
    if (selectedOnes.length > 0)
    this.selectedDept = selectedOnes.join(",");
    else
    this.selectedDept = "0";
  }
  selectedYears(text: any){
    let selectedOnes =[];
    selectedOnes.push(text);
  
    if (selectedOnes.length > 0)
    this.selectedYr = selectedOnes.join(",");
    else
    this.selectedYr = "0";
  }
  
  selectedMonths(value){
    let selectedOnes =[];
    selectedOnes.push(value);
  
    if (selectedOnes.length > 0)
    this.selectedMo = selectedOnes.join(",");
    else
    this.selectedMo = 0;
    
  }
  private loadDepartment() {
    // this._repo.GetLinkedDepartment(this.csv).subscribe((department)=>{
    //    this._iDepartment = department
    // });
  }
 
  // Used for table filtering
  @ViewChild('dt') dt: Table | undefined;
}

