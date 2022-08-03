import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { IRolePermissionMatrix } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  private generateHeaders = () => {
    return {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
  }

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public getFeaturePermissionRoleMatrix(): Observable<IRolePermissionMatrix> {
    return this._http.get<IRolePermissionMatrix>(`${this._envUrl.urlAddress}/api/role-permissions/matrix`)
      .pipe(
        catchError(this.handleError)
      );
  }

  public deleteFeaturePermissionFromRole(permissionId, roleId): Observable<any[]> {
    return this._http.delete<any[]>(`${this._envUrl.urlAddress}/api/role-permissions/matrix/permissions/${permissionId}/roles/${roleId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  public addAddFeaturePermissionToRole(permissionId, roleId) {
    return this._http.post(`${this._envUrl.urlAddress}/api/role-permissions/matrix/permissions/${permissionId}/roles/${roleId}`, null, this.generateHeaders())
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(err): Observable<never> {

    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.message}`;
    }
    else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.message}`;
    }

    console.error(err);
    return throwError(errorMessage);
  }
}
