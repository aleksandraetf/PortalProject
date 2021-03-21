import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { appRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NewsFormComponent } from './news/news-form/news-form.component';

import { NewsListComponent } from './news/news-list.component';
import { LoginComponent } from './login/login.component';

import {  ErrorInterceptor } from './helper/error.interceptor';

import {  JwtInterceptor } from './helper/jwt.interceptor';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    NewsFormComponent,
    NewsListComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    appRoutingModule,
    ReactiveFormsModule
  ],
  exports:[
    RouterModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

],
  bootstrap: [AppComponent]
})
export class AppModule { }