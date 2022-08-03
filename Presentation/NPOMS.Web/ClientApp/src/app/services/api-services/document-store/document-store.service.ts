import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { EntityTypeEnum } from 'src/app/models/enums';
import { IDocumentStore } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import * as fileSaver from 'file-saver';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class DocumentStoreService {

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient
  ) { }

  public upload(files: File[], entityType: EntityTypeEnum, entityId: number, entity: string, refNo: string, documentTypeId: number) {
    const formData = new FormData();

    if (files.length === 0) {
      return;
    }

    Array.from(files).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });

    let documentStoreViewModel = JSON.stringify({
      EntityId: entityId,
      Entity: entity,
      EntityTypeId: entityType,
      DocumentTypeId: documentTypeId,
      RefNo: refNo
    });

    formData.append("documentStoreViewModel", documentStoreViewModel);

    return this._http.post(`${this._envUrl.urlAddress}/api/documentstore`, formData, { reportProgress: true, observe: 'events' })
      .pipe(
        catchError(this.handleError)
      );
  }

  public get(entityId: number, entityType: EntityTypeEnum): Observable<IDocumentStore[]> {

    return this._http.get<IDocumentStore[]>(`${this._envUrl.urlAddress}/api/documentstore/entitytypes/${entityType}/entities/${entityId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  public download(doc: IDocumentStore) {
    return this._http.get(`${this._envUrl.urlAddress}/api/documentstore/${doc.resourceId}`, { responseType: 'blob' })
      .pipe(
        tap(blob => {
          const url = window.URL.createObjectURL(new Blob([blob]));
          fileSaver.saveAs(url, doc.name);
        }),
      );
  }

  public delete(resourceId: FunctionStringCallback) {

    return this._http.delete(`${this._envUrl.urlAddress}/api/documentstore/${resourceId}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  public update(document: IDocumentStore) {
    const url = `${this._envUrl.urlAddress}/api/documentstore`;
    return this._http.put<IDocumentStore>(url, document, httpOptions);
  }

  private handleError(err): Observable<never> {

    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}
