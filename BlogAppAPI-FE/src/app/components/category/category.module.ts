import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateCategoryComponent } from './create-category/create-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';
import { ListCategoryComponent } from './list-category/list-category.component';
import { RouterModule } from '@angular/router';
import { PaginationModule } from '../layout/pagination.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    PaginationModule,
    FormsModule
  ],
  declarations: [
    CreateCategoryComponent,
    EditCategoryComponent,
    ListCategoryComponent
  ],
  exports: [
    CreateCategoryComponent,
    EditCategoryComponent,
    ListCategoryComponent
  ]
})
export class CategoryModule { }
