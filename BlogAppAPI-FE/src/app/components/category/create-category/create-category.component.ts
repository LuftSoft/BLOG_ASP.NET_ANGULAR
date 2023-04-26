import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryModel } from 'src/app/models/CategoryModel';
import { APIService } from 'src/app/services/API.service';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent implements OnInit {
  category: CategoryModel;
  constructor(private api: APIService, public data: DataService, private router: Router) {
    this.category = {
      categoryId: 0,
      name: "",
      description: "",
      categorySlug: ""
    }
  }

  ngOnInit(): void {

  }
  createCategory() {
    console.log(`${this.category.categoryId} - ${this.category.name} - ${this.category.description} - ${this.category.categorySlug}`);
    this.api.post(`${this.data.URL}/category/create`, this.category)
      .subscribe({
        next: (req) => {
          if (req.success === true) {
            this.data.setSuccess(req.message);
            this.router.navigate(['/category/list'])
          }
        },
        error: (err) => {
          console.log("error: " + err.message)
        }
      });
  }
}
