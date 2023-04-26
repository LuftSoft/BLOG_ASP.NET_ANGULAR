import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AlertComponent } from './alert/alert.component';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { LoadingComponent } from './loading/loading.component';
import { LoginLayoutComponent } from './login-layout/login-layout.component';
import { ManageComponent } from './manage/manage.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { PaginationComponent } from './pagination/pagination.component';
import { RightSidebarComponent } from './right-sidebar/right-sidebar.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';



@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  declarations: [
    AlertComponent,
    FooterComponent,
    NavbarComponent,
    HomeComponent,
    LoadingComponent,
    LoginLayoutComponent,
    ManageComponent,

    RightSidebarComponent
  ],
  exports: [
    AlertComponent,
    FooterComponent,
    NavbarComponent,
    HomeComponent,
    LoadingComponent,
    LoginLayoutComponent,
    ManageComponent,

    RightSidebarComponent
  ]
})
export class LayoutModule { }
