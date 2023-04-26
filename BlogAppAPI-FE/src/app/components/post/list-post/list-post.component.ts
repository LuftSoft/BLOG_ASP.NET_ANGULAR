import { Component, OnInit, ViewChild } from '@angular/core';
import { PostModel } from 'src/app/models/PostModel';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';
import { PaginationComponent } from '../../layout/pagination/pagination.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-post',
  templateUrl: './list-post.component.html',
  styleUrls: ['./list-post.component.css']
})
export class ListPostComponent implements OnInit {
  @ViewChild('pagination') pagination: PaginationComponent;
  listPost: any;
  pageTotal = 1;
  pageName = "post";
  page = '0'
  category: string = undefined
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/post/list?page=0`)
      .subscribe(
        {
          next: (data) => {
            if (data['success'] == true) {
              this.listPost = data['payload'].rel;
              this.pageTotal = data['payload'].page_total;
              this.pagination.arrayPage = Array(this.pageTotal).fill(0).map((x, i) => i);
              return;
            }
            else {
              alert("error when get list user")
            }
          },
          error: err => { alert(err) }
        }
      );
  }
  delete() {
    console.log(`delete`)
  }
  paging(i: any) {
    this.page = i;
    this.ngOnInit();
  }
}
