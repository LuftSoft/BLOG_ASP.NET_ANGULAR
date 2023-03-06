import { Component, OnInit } from '@angular/core';
import { CategoryModel } from 'src/app/models/CategoryModel';
import { APIService } from 'src/app/services/API.service';

@Component({
  selector: 'app-list-category',
  templateUrl: './list-category.component.html',
  styleUrls: ['./list-category.component.css']
})
export class ListCategoryComponent implements OnInit {
  public cates: CategoryModel[]
  constructor(private api: APIService) { }

  ngOnInit(): void {
    this.api.get('https://localhost:7163/api/v1/category/list?page=0').subscribe(rel => {
      this.cates = rel as CategoryModel[]
    });
  }

}
