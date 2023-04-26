import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PostModel } from 'src/app/models/PostModel';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {
  post: PostModel
  createPostForm: any
  constructor(private api: APIService, private data: DataService, private router: Router) {
    this.post = {
      postId: 0,
      authorId: 7,
      postTitle: "",
      postContent: "",
      postDescription: "",
      postSlug: "",
      createDate: new Date(),
      updateDate: new Date(),
    }
    this.createPostForm = new FormGroup({
      postTitle: new FormControl(this.post.postTitle, [
        Validators.required,
        Validators.maxLength(250),
        Validators.minLength(20)
      ]),
      postContent: new FormControl(this.post.postContent, [
        Validators.required,
        Validators.minLength(50)
      ]),
      postSlug: new FormControl(this.post.postSlug, [
        Validators.required,
        Validators.minLength(50)
      ])
    });
  }

  ngOnInit(): void {
  }
  createPost() {
    this.api.post(`${this.data.URL}/post/create`, this.post)
      .subscribe({
        next: (res) => {
          if (res.success == true) {
            this.data.setSuccess(res.message)
          }
          else {
            this.data.setWarning(res.message)
          }
          this.router.navigate(['/post/list']);
        },
        error: (err) => {
          this.data.setDanger(err.message)
        }
      })
  }
}
