import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListPostComponent } from './list-post/list-post.component';
import { EditPostComponent } from './edit-post/edit-post.component';
import { CreatePostComponent } from './create-post/create-post.component';
import { DetailPostComponent } from './detail-post/detail-post.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PaginationComponent } from '../layout/pagination/pagination.component';
import { PaginationModule } from '../layout/pagination.module';
import { CKEditorModule } from 'ckeditor4-angular';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    PaginationModule,
    CKEditorModule
  ],
  declarations: [
    ListPostComponent,
    EditPostComponent,
    CreatePostComponent,
    DetailPostComponent
  ],
  exports: [
    ListPostComponent,
    EditPostComponent,
    CreatePostComponent,
    DetailPostComponent
  ]
})
export class PostModule { }
