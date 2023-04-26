import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateRoleComponent } from './create-role/create-role.component';
import { EditRoleComponent } from './edit-role/edit-role.component';
import { ListRoleComponent } from './list-role/list-role.component';
import { PaginationComponent } from '../layout/pagination/pagination.component';
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
    ListRoleComponent,
    CreateRoleComponent,
    EditRoleComponent
  ],
  exports: [
    ListRoleComponent,
    CreateRoleComponent,
    EditRoleComponent
  ]
})
export class RoleModule { }
