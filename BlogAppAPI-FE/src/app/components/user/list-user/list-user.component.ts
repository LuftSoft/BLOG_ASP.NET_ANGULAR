import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/services/API.service';
import { MessageService } from 'src/app/services/Message.service';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  users: any
  constructor(private api: APIService, private msg: MessageService) { }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/user/list`)
      .subscribe(data => { this.users = data; console.log(data); })
  }

}
