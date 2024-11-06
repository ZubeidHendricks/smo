import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor() { }

   // BehaviorSubject to hold the selected department ID
   private selectedDepartmentId = new BehaviorSubject<number>(0);

   // Observable for components to subscribe to
   selectedDepartment$ = this.selectedDepartmentId.asObservable();
 
   // Method to update the selected department ID
   selectedDept(id: number = 0) {
     this.selectedDepartmentId.next(id);
   }
}
