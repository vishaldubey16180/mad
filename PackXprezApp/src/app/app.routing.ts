import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { BranchHomeComponent } from './branch-home/branch-home.component';
import { BranchLoginComponent } from './branch-login/branch-login.component';
import { LoginComponent } from './login/login.component';
import { BranchReceivePackageComponent } from './branch-receive-package/branch-receive-package.component';

const routes: Routes = [
  { path: '', component: BranchHomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'AddCustomer', component: RegisterUserComponent },
  { path: 'BranchHome', component: BranchHomeComponent },
  { path: 'branchLogin', component: BranchLoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'branchReceivePackage', component: BranchReceivePackageComponent },
   { path: '**', component: BranchHomeComponent }


];
export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
