import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/services/API.service';
import { MessageService } from 'src/app/services/Message.service';

@Component({
  selector: 'app-list-tag',
  templateUrl: './list-tag.component.html',
  styleUrls: ['./list-tag.component.css']
})
export class ListTagComponent implements OnInit {
  public listTag: any;
  constructor(private api: APIService, private msg: MessageService) { }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/tag/list?page=0`)
      .subscribe(data => { this.listTag = data; })
  }
  deleteTag() {

  }
}
