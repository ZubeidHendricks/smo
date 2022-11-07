import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-service-delivery-area',
  templateUrl: './service-delivery-area.component.html',
  styleUrls: ['./service-delivery-area.component.css']
})
export class ServiceDeliveryAreaComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

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
