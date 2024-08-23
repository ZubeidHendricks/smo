import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-fc-document',
  templateUrl: './fc-document.component.html',
  styleUrls: ['./fc-document.component.css']
})
export class FCDocumentComponent implements OnInit {

  @Input() toggleable: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
