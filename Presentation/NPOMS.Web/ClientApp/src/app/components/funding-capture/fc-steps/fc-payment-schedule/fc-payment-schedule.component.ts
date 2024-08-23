import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-fc-payment-schedule',
  templateUrl: './fc-payment-schedule.component.html',
  styleUrls: ['./fc-payment-schedule.component.css']
})
export class FCPaymentScheduleComponent implements OnInit {

  @Input() toggleable: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
