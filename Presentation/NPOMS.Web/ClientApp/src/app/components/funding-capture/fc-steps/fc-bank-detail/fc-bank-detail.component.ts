import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-fc-bank-detail',
  templateUrl: './fc-bank-detail.component.html',
  styleUrls: ['./fc-bank-detail.component.css']
})
export class FCBankDetailComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

}
