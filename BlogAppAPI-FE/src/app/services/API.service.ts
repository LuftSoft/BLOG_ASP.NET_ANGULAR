import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})


export class APIService {
  httpOption: any = {
    'Content-Type': 'application/json'
  }
  constructor(private httpclient: HttpClient) { }
  get(url: string) {
    return this.httpclient.get(url)
  }

  public post(url: string) {
    return new Promise((resolve, reject) => {
      resolve(this.httpclient.get(url));
    });
  }
  public put(url: string) {
    return new Promise((resolve, reject) => {
      resolve(this.httpclient.get(url));
    });
  }
  public delete(url: string) {
    return new Promise((resolve, reject) => {
      resolve(this.httpclient.get(url));
    });
  }
}
