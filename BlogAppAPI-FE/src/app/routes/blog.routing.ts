import { Routes, RouterModule } from '@angular/router';
import { CreatePostComponent } from '../components/post/create-post/create-post.component';
import { ListPostComponent } from '../components/post/list-post/list-post.component';
import { EditPostComponent } from '../components/post/edit-post/edit-post.component';
import { DetailPostComponent } from '../components/post/detail-post/detail-post.component';
import { CreateCategoryComponent } from '../components/category/create-category/create-category.component';
import { ListCategoryComponent } from '../components/category/list-category/list-category.component';
import { EditCategoryComponent } from '../components/category/edit-category/edit-category.component';
import { CreateTagComponent } from '../components/tag/create-tag/create-tag.component';
import { ListTagComponent } from '../components/tag/list-tag/list-tag.component';
import { EditTagComponent } from '../components/tag/edit-tag/edit-tag.component';
import { ListUserComponent } from '../components/user/list-user/list-user.component';
import { EditUserComponent } from '../components/user/edit-user/edit-user.component';
import { EditRoleComponent } from '../components/role/edit-role/edit-role.component';
import { ListRoleComponent } from '../components/role/list-role/list-role.component';
import { AuthSigninComponent } from '../components/auth/auth-signin/auth-signin.component';
import { AuthSignupComponent } from '../components/auth/auth-signup/auth-signup.component';
import { CreateRoleComponent } from '../components/role/create-role/create-role.component';
import { DetailUserComponent } from '../components/user/detail-user/detail-user.component';
import { HomeComponent } from '../components/layout/home/home.component';

const routes: Routes = [
  {
    path: "", component: HomeComponent
  },
  {
    path: "post", children: [
      { path: "create", component: CreatePostComponent },
      { path: "list", component: ListPostComponent },
      { path: "edit/:slug", component: EditPostComponent },
      { path: "detail/:slug", component: DetailPostComponent }
    ]
  },
  {
    path: "category", children: [
      { path: "create", component: CreateCategoryComponent },
      { path: "list", component: ListCategoryComponent },
      { path: "edit/:slug", component: EditCategoryComponent }
    ]
  },
  {
    path: "tag", children: [
      { path: "create", component: CreateTagComponent },
      { path: "list", component: ListTagComponent },
      { path: "edit/:id", component: EditTagComponent }
    ]
  },
  {
    path: "user", children: [
      { path: "list", component: ListUserComponent },
      { path: "edit/:id", component: EditUserComponent },
      { path: "detail/:id", component: DetailUserComponent }
    ]
  },
  {
    path: "role", children: [
      { path: "create", component: CreateRoleComponent },
      { path: "list", component: ListRoleComponent },
      { path: "edit/:slug", component: EditRoleComponent },
    ]
  },
  {
    path: "auth", children: [
      { path: "signin", component: AuthSigninComponent },
      { path: "signup", component: AuthSignupComponent },
    ]
  },
];

export const BlogRoutes = RouterModule.forChild(routes);
