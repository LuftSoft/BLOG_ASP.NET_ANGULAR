import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-edit-tag',
  templateUrl: './edit-tag.component.html',
  styleUrls: ['./edit-tag.component.css']
})
export class EditTagComponent implements OnInit {
  tagId: any; tag: any;
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute) {
    route.params.subscribe(data => this.tagId = data.id)
  }

  ngOnInit(): void {
    //console.log(this.tagId)
    this.api.get(`${this.msg.URL}/tag/detail?id=${this.tagId}`)
      .subscribe(data => { this.tag = data; })
  }


  editTag() { }

}
