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
import { ManageComponent } from '../components/layout/manage/manage.component';
import { ProfileUserComponent } from '../components/user/profile-user/profile-user.component';
import { TestUploadComponent } from '../components/test/test-upload/test-upload.component';
import { NotfoundComponent } from '../components/layout/notfound/notfound.component';
import { AuthGuard } from '../components/auth/AuthGuard';

const routes: Routes = [
  {
    path: "", component: HomeComponent
  },
  {
    path: "manage", children: [
      { path: "", component: ManageComponent }
    ]
  },
  {
    path: "post", children: [
      { path: "", component: HomeComponent },
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
      { path: "detail/:id", component: DetailUserComponent },
      { path: "profile/:id", component: ProfileUserComponent }
    ]
  },
  {
    path: "role", children: [
      { path: "create", component: CreateRoleComponent, canActivate: [AuthGuard] },
      { path: "list", component: ListRoleComponent, canActivate: [AuthGuard] },
      { path: "edit/:slug", component: EditRoleComponent, canActivate: [AuthGuard] },
    ]
  },
  {
    path: "auth", children: [
      { path: "signin", component: AuthSigninComponent },
      { path: "signup", component: AuthSignupComponent },
    ]
  },
  {
    path: "test", children: [
      { path: "upload-image", component: TestUploadComponent }
    ]
  },
  {
    path: "**", component: NotfoundComponent
  }
];

export const BlogRoutes = RouterModule.forChild(routes);
