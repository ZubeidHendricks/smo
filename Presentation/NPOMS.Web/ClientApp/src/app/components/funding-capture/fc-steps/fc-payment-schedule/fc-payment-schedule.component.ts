import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-fc-payment-schedule',
  templateUrl: './fc-payment-schedule.component.html',
  styleUrls: ['./fc-payment-schedule.component.css']
})
export class FCPaymentScheduleComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

}
