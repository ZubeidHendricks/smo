import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-post-report',
  templateUrl: './post-report.component.html',
  styleUrls: ['./post-report.component.css']
})
export class PostReportComponent implements OnInit {
  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  data = [
    { column1: ' ', column2: '', column3: '', column4: '',column5: '',column6: '',column7: '' },
    { column1: ' ', column2: '', column3: '', column4: '',column5: '',column6: '',column7: '' },
    { column1: ' ', column2: '', column3: '', column4: '',column5: '',column6: '',column7: '' },
    { column1: ' ', column2: '', column3: '', column4: '',column5: '',column6: '',column7: '' },
    { column1: ' ', column2: '', column3: '', column4: '',column5: '',column6: '',column7: '' },
  
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
