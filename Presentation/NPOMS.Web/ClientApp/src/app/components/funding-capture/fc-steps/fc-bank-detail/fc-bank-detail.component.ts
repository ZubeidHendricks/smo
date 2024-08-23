import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-fc-bank-detail',
  templateUrl: './fc-bank-detail.component.html',
  styleUrls: ['./fc-bank-detail.component.css']
})
export class FCBankDetailComponent implements OnInit {

  @Input() toggleable: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
