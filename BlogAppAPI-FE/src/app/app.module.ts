import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BlogRoutes } from './routes/blog.routing';
import { APIService } from './services/API.service';
import { CommonModule, DatePipe } from '@angular/common';
import { DataService } from './services/Data.service';
import { CKEditorModule } from 'ckeditor4-angular';
import { PostModule } from './components/post/post.module';
import { RoleModule } from './components/role/role.module';
import { CategoryModule } from './components/category/category.module';
import { TagModule } from './components/tag/tag.module';
import { UserModule } from './components/user/user.module';
import { LayoutModule } from './components/layout/layout.module';
import { TestUploadComponent } from './components/test/test-upload/test-upload.component';
import { RouterModule } from '@angular/router';
import { NotfoundComponent } from './components/layout/notfound/notfound.component';
import { PaginationModule } from './components/layout/pagination.module';
import { AuthSigninComponent } from './components/auth/auth-signin/auth-signin.component';
import { AuthSignupComponent } from './components/auth/auth-signup/auth-signup.component';


@NgModule({
  declarations: [
    AppComponent,
    TestUploadComponent,
    NotfoundComponent,
    AuthSigninComponent,
    AuthSignupComponent
  ],
  imports: [
    LayoutModule,
    BrowserModule,
    AppRoutingModule,
    BlogRoutes,
    FormsModule,
    RouterModule,
    HttpClientModule,
    PostModule,
    RoleModule,
    CategoryModule,
    TagModule,
    UserModule,
    ReactiveFormsModule
  ],
  providers: [APIService, DatePipe, DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
