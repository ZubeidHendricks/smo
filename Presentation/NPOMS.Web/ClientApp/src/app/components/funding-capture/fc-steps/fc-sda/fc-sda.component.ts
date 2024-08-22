import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-fc-sda',
  templateUrl: './fc-sda.component.html',
  styleUrls: ['./fc-sda.component.css']
})
export class FCSDAComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

}
