import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-detail-user',
  templateUrl: './detail-user.component.html',
  styleUrls: ['./detail-user.component.css']
})
export class DetailUserComponent implements OnInit {
  id: any
  user: any
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute) {
    this.route.params.subscribe(p => this.id = p.id);
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/user/detail/${this.id}`)
      .subscribe(data => { this.user = data; console.log(data) })
  }

}
