import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})


export class APIService {
  httpOption: any = {
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`
  }
  constructor(private httpclient: HttpClient) { }
  get(url: string) {
    return this.httpclient.get(url, this.httpOption)
  }

  public post(url: string, payload: any): Observable<any> {
    return this.httpclient.post<any>(url, payload, this.httpOption);
  }
  public put(url: string, payload: any) {
    return this.httpclient.put(url, payload, this.httpOption);
  }
  public delete(url: string) {
    return new Promise((resolve, reject) => {
      resolve(this.httpclient.get(url, this.httpOption));
    });
  }
}
