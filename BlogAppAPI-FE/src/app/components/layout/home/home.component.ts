import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostModel } from 'src/app/models/PostModel';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  listPost: PostModel[];
  category: any = undefined;
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute) {
    route.queryParams.subscribe(data => { if (data.category !== undefined) this.category = data.category });
  }

  ngOnInit(): void {
    console.log(localStorage.getItem('user'))
    if (this.category === undefined) {
      this.api.get(`${this.msg.URL}/post/list?page=0`)
        .subscribe({
          next: (res) => {
            this.listPost = res['payload'].rel;
            // console.log(this.listPost);
          },
          error: (err) => {
            alert(err)
          }
        });
    }
    else {
      this.api.get(`${this.msg.URL}/post/${this.category}?page=0`)
        .subscribe(
          {
            next: (data) => {
              // console.log(data)
              if (data['success'] == true) {
                this.listPost = data['payload'].rel;
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
  }
}
