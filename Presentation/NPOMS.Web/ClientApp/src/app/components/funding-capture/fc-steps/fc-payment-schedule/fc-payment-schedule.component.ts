import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-fc-payment-schedule',
  templateUrl: './fc-payment-schedule.component.html',
  styleUrls: ['./fc-payment-schedule.component.css']
})
export class FCPaymentScheduleComponent implements OnInit {

  @Input() toggleable: boolean;

  private _validated: boolean;
  @Input()
  get validated(): boolean { return this._validated; }
  set validated(validated: boolean) { this._validated = validated; }

  constructor() { }

  ngOnInit(): void {
  }
}
