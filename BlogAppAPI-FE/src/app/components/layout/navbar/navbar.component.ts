import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DataService } from 'src/app/services/Data.service';
import $ from 'jquery'
import { APIService } from 'src/app/services/API.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Output() eventSearch: EventEmitter<any> = new EventEmitter();
  searchInput = "";
  constructor(public data: DataService, private api: APIService) {
    //console.log(data.User)
  }

  ngOnInit(): void { }

  ngAfterViewInit() { }
  ngDoCheck() {
    $('li').hover(function () {
      $(this).children('ul').stop().slideToggle(200);
    });
  }
  search() {
    if (this.searchInput == "") console.log("search is empty")
    else {
      this.eventSearch.emit(this.searchInput);
      console.log(`searching for ${this.searchInput}`)
      this.api.get(`${this.data.URL}/post/search?keyword=${this.searchInput}&page=0`)
        .subscribe(res => console.log(res))
    }
  }

}
