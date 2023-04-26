import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CreateTagComponent } from './create-tag/create-tag.component';
import { EditTagComponent } from './edit-tag/edit-tag.component';
import { ListTagComponent } from './list-tag/list-tag.component';
import { PaginationModule } from '../layout/pagination.module';



@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    PaginationModule
  ],
  declarations: [
    CreateTagComponent,
    EditTagComponent,
    ListTagComponent
  ],
  exports: [
    CreateTagComponent,
    EditTagComponent,
    ListTagComponent
  ]
})
export class TagModule { }
