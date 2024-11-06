import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
    providedIn: 'root',
  })
  export class FundingAssessmentUIEventsService {
    private responseChanged = new Subject<void>();
  
    // Observable to be accessed by components
    onResponseChanged$ = this.responseChanged.asObservable();
  
    // Method to trigger the event
    onResponseChanged() {
      this.responseChanged.next();
    }
  }