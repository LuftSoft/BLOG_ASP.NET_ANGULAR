import { Component, OnInit, ViewChild } from '@angular/core';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';
import { PaginationComponent } from '../../layout/pagination/pagination.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-tag',
  templateUrl: './list-tag.component.html',
  styleUrls: ['./list-tag.component.css']
})
export class ListTagComponent implements OnInit {
  @ViewChild('pagination') pagination: PaginationComponent | undefined;
  public listTag: any;
  pageName = "tag"
  pageTotal: any;
  page = '0'
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute, private router: Router) {
    //route.params.subscribe(p => { this.page = p.page });
    route.queryParams.subscribe(p => { if (p.page != undefined) this.page = p.page; })
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/tag/list?page=${this.page}`)
      .subscribe({
        next: (res) => {
          this.listTag = res['payload'].rel;
          this.pageTotal = res['payload'].page_total;
          this.pagination.arrayPage = Array(this.pageTotal).fill(0).map((x, i) => i);
          // this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
          //   this.router.navigate(['/tag/list']);
          // });
        },
        error: (err) => {
          alert(err)
        }
      })
  }
  deleteTag() {

  }
  resetPage() {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false
    this.router.onSameUrlNavigation = 'reload'
    this.router.navigate(['/tag/list'], {
      relativeTo: this.route
    });
  }
  paging(i: any) {
    this.page = i;
    this.ngOnInit();
  }

}
