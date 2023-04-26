import { Component, ViewChild } from '@angular/core';
import { NavbarComponent } from './components/layout/navbar/navbar.component';
import { DataService } from './services/Data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isLoading = false;
  isShowMessage = true;
  @ViewChild('navbar') nav: NavbarComponent | undefined;
  constructor(public data: DataService) { }
  ngOnInit() {
    //this.isLoading = true;
  }
  ngAfterViewInit() {
    //console.log("app after view init")
    this.data.setDefault();
  }
  active() {
    if (this.data.message !== '') {
      if (!this.isShowMessage) {
        this.data.setDefault();
        this.isShowMessage = true;
      }
      else this.isShowMessage = false;
    }
  }
  searchEvent(param) {
    console.log("event from navbar - " + param)
  }
}
