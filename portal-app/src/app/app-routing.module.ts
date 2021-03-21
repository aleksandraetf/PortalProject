import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';

import { NewsListComponent } from './news/news-list.component';
import { AuthGuard } from './helper/auth.guard';
import { NgModule } from '@angular/core';

const routes: Routes = [
    // { path: '', component: NewsComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: '',component:NewsListComponent},

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];


 export const appRoutingModule = RouterModule.forRoot(routes);

