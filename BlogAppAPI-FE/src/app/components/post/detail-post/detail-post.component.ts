import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { APIService } from 'src/app/services/API.service';
import { MessageService } from 'src/app/services/Message.service';

@Component({
  selector: 'app-detail-post',
  templateUrl: './detail-post.component.html',
  styleUrls: ['./detail-post.component.css']
})
export class DetailPostComponent implements OnInit {
  slug: string
  post: any
  constructor(private api: APIService, private msg: MessageService, private route: ActivatedRoute) {
    this.route.params.subscribe(p => this.slug = p.slug)
  }

  ngOnInit(): void {
    this.api.get(`https://localhost:7163/api/v1/post/detail?slug=${this.slug}`)
      .subscribe(data => { this.post = data; })
  }

}
