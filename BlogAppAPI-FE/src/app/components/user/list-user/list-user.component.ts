import { Component, OnInit, ViewChild } from '@angular/core';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';
import { PaginationComponent } from '../../layout/pagination/pagination.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  @ViewChild('pagination') pagination: PaginationComponent
  users: any
  pageTotal: number = 1;
  pageName = "user"
  page = '0'
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute) {
    route.queryParams.subscribe(p => { if (p.page != undefined) this.page = p.page; })
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/user/list?page=${this.page}`)
      .subscribe({
        next: (data) => {
          if (data['success'] == true) {
            this.users = data['payload'].rel;
            this.pageTotal = data['payload'].page_total;
            this.pagination.arrayPage = Array(this.pageTotal).fill(0).map((x, i) => i);
            return;
          }
          else {
            alert("error when get list user")
          }
        },
        error: err => { alert(err) }
      })
  }
  paging(i: any) {
    this.page = i;
    this.ngOnInit();
  }
}
