import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { APIService } from 'src/app/services/API.service';
import { MessageService } from 'src/app/services/Message.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  id: any
  user: any
  constructor(private api: APIService, private msg: MessageService, private route: ActivatedRoute) {
    this.route.params.subscribe(p => this.id = p.id);
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/user/detail/${this.id}`)
      .subscribe(data => { this.user = data; console.log(data) })
  }

}
