import { Component, OnInit } from '@angular/core';
import { APIService } from 'src/app/services/API.service';
import { MessageService } from 'src/app/services/Message.service';

@Component({
  selector: 'app-list-role',
  templateUrl: './list-role.component.html',
  styleUrls: ['./list-role.component.css']
})
export class ListRoleComponent implements OnInit {
  roles: any
  constructor(private api: APIService, private msg: MessageService) { }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/role/list`)
      .subscribe(data => { this.roles = data; console.log(data) })
  }

}
