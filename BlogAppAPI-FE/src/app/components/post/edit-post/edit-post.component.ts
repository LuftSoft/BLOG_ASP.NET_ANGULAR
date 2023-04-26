import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PostModel } from 'src/app/models/PostModel';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {
  slug: string
  post: any
  formContent: FormGroup
  constructor(private api: APIService, private msg: DataService, private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe(p => this.slug = p.slug);
    this.formContent = new FormGroup([

    ])
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/post/detail?slug=${this.slug}`)
      .subscribe(data => {
        if (data['success']) {
          this.post = data['payload']
        } else {
          this.msg.setDanger("can't get post information")
        }
      });
  }

  editPost() {
    this.api.put(`${this.msg.URL}/post/edit`, this.post)
      .subscribe(data => {
        if (data['success']) {
          this.msg.setSuccess("edit post success")
        } else {
          this.msg.setDanger("edit failed")
        }
      })
    this.router.navigate(['/post/list']);
  }

}
