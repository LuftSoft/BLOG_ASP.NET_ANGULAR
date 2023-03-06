import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/layout/navbar/navbar.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { CreatePostComponent } from './components/post/create-post/create-post.component';
import { ListPostComponent } from './components/post/list-post/list-post.component';
import { EditPostComponent } from './components/post/edit-post/edit-post.component';
import { FormsModule } from '@angular/forms';
import { DetailPostComponent } from './components/post/detail-post/detail-post.component';
import { BlogRoutes } from './routes/blog.routing';
import { LoginLayoutComponent } from './components/layout/login-layout/login-layout.component';
import { RightSidebarComponent } from './components/layout/right-sidebar/right-sidebar.component';
import { CreateCategoryComponent } from './components/category/create-category/create-category.component';
import { ListCategoryComponent } from './components/category/list-category/list-category.component';
import { EditCategoryComponent } from './components/category/edit-category/edit-category.component';
import { CreateTagComponent } from './components/tag/create-tag/create-tag.component';
import { EditTagComponent } from './components/tag/edit-tag/edit-tag.component';
import { ListTagComponent } from './components/tag/list-tag/list-tag.component';
import { ListUserComponent } from './components/user/list-user/list-user.component';
import { EditUserComponent } from './components/user/edit-user/edit-user.component';
import { ListRoleComponent } from './components/role/list-role/list-role.component';
import { EditRoleComponent } from './components/role/edit-role/edit-role.component';
import { AuthSigninComponent } from './components/auth/auth-signin/auth-signin.component';
import { AuthSignupComponent } from './components/auth/auth-signup/auth-signup.component';
import { CreateRoleComponent } from './components/role/create-role/create-role.component';
import { DetailUserComponent } from './components/user/detail-user/detail-user.component';
import { APIService } from './services/API.service';
import { CommonModule, DatePipe } from '@angular/common';
import { MessageService } from './services/Message.service';
import { HomeComponent } from './components/layout/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    CreatePostComponent,
    ListPostComponent,
    EditPostComponent,
    DetailPostComponent,
    LoginLayoutComponent,
    RightSidebarComponent,
    CreateCategoryComponent,
    ListCategoryComponent,
    EditCategoryComponent,
    CreateTagComponent,
    EditTagComponent,
    ListTagComponent,
    ListUserComponent,
    EditUserComponent,
    ListRoleComponent,
    EditRoleComponent,
    AuthSigninComponent,
    AuthSignupComponent,
    CreateRoleComponent,
    DetailUserComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BlogRoutes,
    FormsModule,
    HttpClientModule
  ],
  providers: [APIService, DatePipe, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
