import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
//import { CustomerComponent } from './customer/customer.component';
import { CommonlayoutComponent } from './commonlayout/commonlayout.component';
//import { RegisterUserComponent } from './register-user/register-user.component';
//import { HttpClient } from 'selenium-webdriver/http';
import { ServiceAvailabilityComponent } from './service-availability/service-availability.component';

import { HttpClientModule } from '@angular/common/http';
import { userservice } from './services/userservice.service';
import { HomeComponent } from './home/home.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { BranchHomeComponent } from './branch-home/branch-home.component';
import { routing } from './app.routing';
import { BranchCommonLayoutComponent } from './branch-common-layout/branch-common-layout.component';
import { BranchLoginComponent } from './branch-login/branch-login.component';
import { BranchOfficerLayoutComponent } from './branch-officer-layout/branch-officer-layout.component';
import { BranchReceivePackageComponent } from './branch-receive-package/branch-receive-package.component';
//import { userservice } from './services/userservice';
//import { routing } from './app.routing';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
   // CustomerComponent,
    CommonlayoutComponent,
   RegisterUserComponent,
    ServiceAvailabilityComponent,
    HomeComponent,
    FeedbackComponent,
    BranchHomeComponent,
    BranchCommonLayoutComponent,
    BranchLoginComponent,
    BranchOfficerLayoutComponent,
    BranchReceivePackageComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    routing


  ],
  providers: [userservice],
  bootstrap: [AppComponent]
})
export class AppModule { }
