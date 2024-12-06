import { Component, OnInit } from '@angular/core';
import { IndicatorService } from '../../services/indicator.service';

@Component({
  selector: 'app-business-plan-indicators',
  templateUrl: './business-plan-indicators.component.html',
  styleUrls: ['./business-plan-indicators.component.css']
})
export class BusinessPlanIndicatorsComponent implements OnInit {
  quarters: any[] = [
    { id: 1, name: 'Q1' },
    { id: 2, name: 'Q2' },
    { id: 3, name: 'Q3' },
    { id: 4, name: 'Q4' }
  ];
  
  selectedQuarter: any;
  indicators: any[] = [];
  showActualsTab: boolean = false;
  
  constructor(private indicatorService: IndicatorService) {}

  ngOnInit() {
    this.loadIndicators();
  }

  loadIndicators() {
    if (this.selectedQuarter) {
      this.indicatorService.getIndicators(this.selectedQuarter.id).subscribe(
        data => this.indicators = data,
        error => console.error('Error loading indicators:', error)
      );
    }
  }

  onQuarterChange() {
    this.loadIndicators();
  }

  captureActual(indicator: any) {
    indicator.captured = true;
    this.saveIndicator(indicator);
  }

  updateIndicator(indicator: any) {
    this.saveIndicator(indicator);
  }

  private saveIndicator(indicator: any) {
    this.indicatorService.saveIndicator(indicator).subscribe(
      response => console.log('Indicator saved:', response),
      error => console.error('Error saving indicator:', error)
    );
  }
}