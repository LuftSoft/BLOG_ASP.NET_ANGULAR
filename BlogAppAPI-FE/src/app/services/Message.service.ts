import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor() { }
  URL = "https://localhost:7163/api/v1"
  HOST = "http://localhost:4200"
  status = "danger"
  message = ""
  User: any
}
