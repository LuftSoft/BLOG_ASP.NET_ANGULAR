import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TagModel } from 'src/app/models/TagModel';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-create-tag',
  templateUrl: './create-tag.component.html',
  styleUrls: ['./create-tag.component.css']
})
export class CreateTagComponent implements OnInit {
  tag: TagModel
  constructor(private api: APIService, public data: DataService, private router: Router) {
    this.tag = {
      tagId: 0,
      tagName: "",
      tagDescription: ""
    };
  }

  ngOnInit(): void {
  }
  createTag() {
    this.api.post(`${this.data.URL}/tag/create`, this.tag)
      .subscribe({
        next: (res) => {
          if (res.success == true) {
            this.data.setSuccess(res.message);
            //console.log(this.data.message + "-" + this.data.typeMessage)
            this.router.navigate(['/tag/list'])
          }
          else this.data.setDanger(res.message);
        },
        error: (err) => {
          this.data.setDanger(err.message);
        }
      });
  }
}
