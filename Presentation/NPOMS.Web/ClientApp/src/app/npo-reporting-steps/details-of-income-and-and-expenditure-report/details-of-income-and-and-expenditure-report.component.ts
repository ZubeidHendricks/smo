import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-details-of-income-and-and-expenditure-report',
  templateUrl: './details-of-income-and-and-expenditure-report.component.html',
  styleUrls: ['./details-of-income-and-and-expenditure-report.component.css']
})
export class DetailsOfIncomeAndAndExpenditureReportComponent implements OnInit {
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  data = [
    { column1: ' ', column2: '', column3: '', column4: '' },
    { column1: ' ', column2: '', column3: '', column4: '' },
    { column1: ' ', column2: '', column3: '', column4: '' },
    { column1: ' ', column2: '', column3: '', column4: '' },
    { column1: ' ', column2: '', column3: '', column4: '' },
  
  ];
  constructor() { }

  ngOnInit(): void {
  }

  nextPage() {
    this.activeStep = this.activeStep + 1;
    this.activeStepChange.emit(this.activeStep);
  }
  

  prevPage() {
    this.activeStep = this.activeStep - 1;
    this.activeStepChange.emit(this.activeStep);
  }


}
