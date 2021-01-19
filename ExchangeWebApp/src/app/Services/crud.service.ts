import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class CrudService {

  private headers: HttpHeaders;

  private forexApiBaseUrl = 'http://localhost:5000/forex/api/';

  constructor(private http: HttpClient) { 
  }

  private setHeaders() {
    this.headers = new HttpHeaders().set('Content-Type', 'application/json');    
  }

  public getByUrl(endpoint: string) {
    this.setHeaders();
    return this.http.get(this.forexApiBaseUrl + endpoint, {headers: this.headers});
  }

  public postByUrl(endpoint: string, param: any) {
    this.setHeaders();
    return this.intercept(this.http.post(this.forexApiBaseUrl + endpoint, param, {headers: this.headers}));
  }

  private intercept(observer: Observable<any>): Observable<any> {
    return observer.pipe(
      catchError((error) =>{
        switch (error.status) {
          case 400:
            console.log("400");            
            break;
          case 500:
            console.log("500");
            break;        
          default:
            break;

            return Observable.throw(error);
        }
      }));
  }

}
