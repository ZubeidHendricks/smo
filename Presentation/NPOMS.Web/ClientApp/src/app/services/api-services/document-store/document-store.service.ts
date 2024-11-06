import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { EntityTypeEnum } from 'src/app/models/enums';
import { IDocumentStore } from 'src/app/models/interfaces';
import { EnvironmentUrlService } from '../../environment-url/environment-url.service';
import * as fileSaver from 'file-saver';
import * as XLSX from 'xlsx';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class DocumentStoreService {
  lines = []; //for headings
  linesR = []; // for rows
  message: string;
  records: number;

  constructor(
    private _envUrl: EnvironmentUrlService,
    private _http: HttpClient,
    private _environmentService: EnvironmentUrlService,
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

  public getFundApp(entityId: number, docTypeId: number, entityType: EntityTypeEnum): Observable<IDocumentStore[]> {

    return this._http.get<IDocumentStore[]>(`${this._envUrl.urlAddress}/api/documentstore/entitytypes/${entityType}/entities/${entityId}/documentTypeId/${docTypeId}`)
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

  public UploadFileToImportIndicator(files: File[], year: string)
  {
      const formData = new FormData();

      if (files.length === 0) {

           return;
      }

      Array.from(files).map((file, index) => {
        const f = file;
        let reader = new FileReader(); 
        reader.readAsBinaryString(f);        
        reader.onload = (e: any) => {
          /* create workbook */
          const binarystr: string = e.target.result;
          const wb: XLSX.WorkBook = XLSX.read(binarystr, { type: 'binary' });
    
          /* selected the first sheet */
          const wsname: string = wb.SheetNames[0];
          const ws: XLSX.WorkSheet = wb.Sheets[wsname];
    
          /* save data */
          const data = XLSX.utils.sheet_to_json(ws);
          this.message = 'You are uploading file which has total '  + data.length + ' records. \n The number of records may be reduced in sampling page';
          alert(this.message);
         
        };
        return formData.append('file'+index, file, file.name);
      });

      return this._http.post(`${this._envUrl.urlAddress}/api/documentStore/uploadIndicator/${year}`, formData, {responseType: 'text'})
      .pipe(
             //tap(data=> console.log(data)),
      );
  }

  public UploadFileToImportNPOLevel(files: File[], year: string)
  {
      const formData = new FormData();

      if (files.length === 0) {

           return;
      }

      Array.from(files).map((file, index) => {
        const f = file;
        let reader = new FileReader(); 
        reader.readAsBinaryString(f);        
        reader.onload = (e: any) => {
          /* create workbook */
          const binarystr: string = e.target.result;
          const wb: XLSX.WorkBook = XLSX.read(binarystr, { type: 'binary' });
    
          /* selected the first sheet */
          const wsname: string = wb.SheetNames[0];
          const ws: XLSX.WorkSheet = wb.Sheets[wsname];
    
          /* save data */
          const data = XLSX.utils.sheet_to_json(ws);
          this.message = 'You are uploading file which has total '  + data.length + ' records. \n The number of records may be reduced in sampling page';
          alert(this.message);
         
        };
        return formData.append('file'+index, file, file.name);
      });

      return this._http.post(`${this._envUrl.urlAddress}/api/documentStore/npouploadIndicator/${year}`, formData, {responseType: 'text'})
      .pipe(
             //tap(data=> console.log(data)),
      );
  }
}
