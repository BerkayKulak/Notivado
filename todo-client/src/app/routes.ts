import { Routes } from '@angular/router';
import { FriendListComponent } from './friend-list/friend-list.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { MemberListComponent } from './member-list/todo-list.component';
import { MessagesComponent } from './messages/messages.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RegisterComponent } from './register/register.component';
import { ProductDetailsComponent } from './work-details/work-details.component';
import { WorkEditComponent } from './work-edit/work-edit.component';
import { AuthGuard } from './_guards/auth-guard';

export const appRoutes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'home', component: LoginComponent },
  { path: 'todo', component: MemberListComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'friends', component: FriendListComponent, canActivate: [AuthGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
  {
    path: 'work-edit/:id',
    component: WorkEditComponent,
    canActivate: [AuthGuard],
  },
  { path: 'messages', component: MessagesComponent, canActivate: [AuthGuard] },
  {
    path: 'work-details',
    component: ProductDetailsComponent,
    canActivate: [AuthGuard],
  },
  { path: '**', component: NotFoundComponent },
];
