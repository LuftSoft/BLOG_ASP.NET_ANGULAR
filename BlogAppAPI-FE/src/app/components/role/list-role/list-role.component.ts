import { Component, OnInit, ViewChild } from '@angular/core';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';
import { PaginationComponent } from '../../layout/pagination/pagination.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-role',
  templateUrl: './list-role.component.html',
  styleUrls: ['./list-role.component.css']
})
export class ListRoleComponent implements OnInit {
  @ViewChild('pagination') pagination: PaginationComponent
  roles: any
  pageTotal = 1;
  pageName = "role";
  page = '0'
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute) {
    route.queryParams.subscribe(r => { if (r.page != undefined) this.page = r.page; })
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/role/list?page=${this.page}`)
      .subscribe({
        next: (res) => {
          this.roles = res['payload'].rel;
          this.pageTotal = res['payload'].page_total;
          this.pagination.arrayPage = Array(this.pageTotal).fill(0).map((x, i) => i);
        },
        error: (err) => {
          alert(err)
        }
      })
  }
  paging(i: any) {
    this.page = i;
    this.ngOnInit();
  }
}
