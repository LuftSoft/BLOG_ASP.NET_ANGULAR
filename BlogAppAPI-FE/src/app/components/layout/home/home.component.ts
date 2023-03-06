import { Component, OnInit } from '@angular/core';
import { PostModel } from 'src/app/models/PostModel';
import { APIService } from 'src/app/services/API.service';
import { MessageService } from 'src/app/services/Message.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  listPost: PostModel[];
  constructor(private api: APIService, private msg: MessageService) { }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/post/list?page=0`)
      .subscribe(data => { this.listPost = data as PostModel[]; });
  }
}
