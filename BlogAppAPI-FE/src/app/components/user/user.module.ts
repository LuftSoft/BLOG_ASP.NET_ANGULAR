import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DetailUserComponent } from './detail-user/detail-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { ProfileUserComponent } from './profile-user/profile-user.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PaginationModule } from '../layout/pagination.module';



@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    PaginationModule
  ],
  declarations: [
    DetailUserComponent,
    ListUserComponent,
    ProfileUserComponent,
    EditUserComponent
  ],
  exports: [
    DetailUserComponent,
    ListUserComponent,
    ProfileUserComponent,
    EditUserComponent
  ]
})
export class UserModule { }
