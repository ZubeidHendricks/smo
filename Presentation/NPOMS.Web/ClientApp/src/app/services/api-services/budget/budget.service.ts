import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IDepartmentBudget, IDirectorateBudget, IProgrammeBudget } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class BudgetService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getDepartmentBudgetsByIds(departmentId: number, financialYearId: number) {
    const url = `${this._envUrl.urlAddress}/api/budgets/department-budgets/departmentId/${departmentId}/financialYearId/${financialYearId}`;
    return this._http.get<IDepartmentBudget[]>(url, httpOptions);
  }

  public createDepartmentBudget(departmentBudget: IDepartmentBudget) {
    const url = `${this._envUrl.urlAddress}/api/budgets/department-budgets`;
    return this._http.post<IDepartmentBudget>(url, departmentBudget, httpOptions);
  }

  public updateDepartmentBudget(departmentBudget: IDepartmentBudget) {
    const url = `${this._envUrl.urlAddress}/api/budgets/department-budgets`;
    return this._http.put<IDepartmentBudget>(url, departmentBudget, httpOptions);
  }

  public getDirectorateBudgetsByIds(departmentId: number, financialYearId: number) {
    const url = `${this._envUrl.urlAddress}/api/budgets/directorate-budgets/departmentId/${departmentId}/financialYearId/${financialYearId}`;
    return this._http.get<IDirectorateBudget[]>(url, httpOptions);
  }

  public createDirectorateBudget(directorateBudget: IDirectorateBudget) {
    const url = `${this._envUrl.urlAddress}/api/budgets/directorate-budgets`;
    return this._http.post<IDirectorateBudget>(url, directorateBudget, httpOptions);
  }

  public updateDirectorateBudget(directorateBudget: IDirectorateBudget) {
    const url = `${this._envUrl.urlAddress}/api/budgets/directorate-budgets`;
    return this._http.put<IDirectorateBudget>(url, directorateBudget, httpOptions);
  }

  public getProgrammeBudgetsByIds(departmentId: number, financialYearId: number) {
    const url = `${this._envUrl.urlAddress}/api/budgets/programme-budgets/departmentId/${departmentId}/financialYearId/${financialYearId}`;
    return this._http.get<IProgrammeBudget[]>(url, httpOptions);
  }

  public getProgrammeBudgetByProgrammeId(programmeId: number, financialYearId: number) {
    const url = `${this._envUrl.urlAddress}/api/budgets/programme-budgets/programmeId/${programmeId}/financialYearId/${financialYearId}`;
    return this._http.get<IProgrammeBudget>(url, httpOptions);
  }

  public createProgrammeBudget(programmeBudget: IProgrammeBudget) {
    const url = `${this._envUrl.urlAddress}/api/budgets/programme-budgets`;
    return this._http.post<IProgrammeBudget>(url, programmeBudget, httpOptions);
  }

  public updateProgrammeBudget(programmeBudget: IProgrammeBudget) {
    const url = `${this._envUrl.urlAddress}/api/budgets/programme-budgets`;
    return this._http.put<IProgrammeBudget>(url, programmeBudget, httpOptions);
  }
}
