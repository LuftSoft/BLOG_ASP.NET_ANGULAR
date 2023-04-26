import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoryModel } from 'src/app/models/CategoryModel';
import { APIService } from 'src/app/services/API.service';
import { PaginationComponent } from '../../layout/pagination/pagination.component';
import { DataService } from 'src/app/services/Data.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css']
})
export class ListCategoryComponent implements OnInit {
  @ViewChild('pagination') pagination: PaginationComponent | undefined;
  pageName = "category";
  pageTotal = 1;
  page = '0'
  public cates: any;
  constructor(private api: APIService, public data: DataService, private route: ActivatedRoute) {
    this.route.queryParams.subscribe(c => { if (c.page != undefined) this.page = c.page; })
  }

  ngOnInit(): void {
    this.api.get(`https://localhost:7163/api/v1/category/list?page=${this.page}`).subscribe(
      {
        next: (res) => {
          this.cates = res['payload'].rel;
          this.pageTotal = res['payload'].page_total;
          this.pagination.arrayPage = Array(this.pageTotal).fill(0).map((x, i) => i);
          console.log('page total: ' + this.pageTotal);
        },
        error: (err) => {
          alert(err)
        }
      }
    );
  }
  paging(i: any) {
    this.page = i;
    this.ngOnInit();
  }

}
