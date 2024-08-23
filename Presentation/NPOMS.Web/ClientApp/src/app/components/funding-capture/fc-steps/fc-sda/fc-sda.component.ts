import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-fc-sda',
  templateUrl: './fc-sda.component.html',
  styleUrls: ['./fc-sda.component.css']
})
export class FCSDAComponent implements OnInit {

  @Input() toggleable: boolean;

  constructor() { }

  ngOnInit(): void {
  }

}
