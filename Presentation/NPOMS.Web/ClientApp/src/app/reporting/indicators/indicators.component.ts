import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-indicators',
  templateUrl: './indicators.component.html',
  styleUrls: ['./indicators.component.css']
})
export class IndicatorsComponent implements OnInit {
  data = [

    { column1: 'Governance', column2: '', column3: '', column4: '',column5: '',column6: '' },  
    { column1: 'Management', column2: '', column3: '', column4: '',column5: '',column6: '' },
    { column1: 'Human Resource Management', column2: '', column3: '', column4: '',column5: '',column6: '' },
    { column1: 'Occupational Health and Safety', column2: '', column3: '', column4: '',column5: '',column6: '' },

  ];

  constructor() { }

  ngOnInit(): void {
  }

}
