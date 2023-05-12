import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }
  // URL = "https://localhost:7163/api/v1"
  URL = "http://luffschloss.somee.com/api/v1"
  HOST = "http://localhost:4200"
  status = "danger"
  message = ""
  typeMessage = "success";
  User: Object = JSON.parse(localStorage.getItem('user'));

  setSuccess(msg) {
    this.typeMessage = "success"
    this.message = msg
  }
  setWarning(msg) {
    this.typeMessage = "warning"
    this.message = msg
  }
  setDanger(msg) {
    this.typeMessage = "danger"
    this.message = msg
  }
  setDefault() {
    this.typeMessage = "success"
    this.message = ""
  }
}
