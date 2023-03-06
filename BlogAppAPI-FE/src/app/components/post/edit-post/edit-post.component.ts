import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PostModel } from 'src/app/models/PostModel';
import { APIService } from 'src/app/services/API.service';
import { MessageService } from 'src/app/services/Message.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {
  slug: string
  post: any
  constructor(private api: APIService, private msg: MessageService, private route: ActivatedRoute) {
    route.params.subscribe(p => this.slug = p.slug)
  }

  ngOnInit(): void {
    this.api.get(`${this.msg.URL}/post/detail?slug=${this.slug}`)
      .subscribe(data => this.post = data as PostModel);
  }

  editPost() {
    console.log("edit post")
  }

}
