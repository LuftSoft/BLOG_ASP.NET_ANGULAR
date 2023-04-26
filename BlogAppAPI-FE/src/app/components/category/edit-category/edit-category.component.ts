import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryModel } from 'src/app/models/CategoryModel';
import { APIService } from 'src/app/services/API.service';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit {
  public slug: string;
  public cate: any;
  constructor(private api: APIService, private route: ActivatedRoute) {
    this.route.params.subscribe(p => this.slug = p.slug);
  }

  ngOnInit(): void {
    this.api.get(`https://localhost:7163/api/v1/category/detail?slug=${this.slug}`)
      .subscribe(data => { this.cate = data })
  }
  editCategory() {
    console.log(this.cate)
  }

}
