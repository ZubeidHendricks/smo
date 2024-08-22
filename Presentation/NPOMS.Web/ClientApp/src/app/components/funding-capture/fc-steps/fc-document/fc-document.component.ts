import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-fc-document',
  templateUrl: './fc-document.component.html',
  styleUrls: ['./fc-document.component.css']
})
export class FCDocumentComponent implements OnInit {

  @Input() activeStep: number;
  @Output() activeStepChange: EventEmitter<number> = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

}
