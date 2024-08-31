import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'register',
    loadChildren: () =>
      import('../auth-register/auth-register.module').then(
        (m) => m.AuthRegisterModule
      ),
  },
  {
    path: 'login',
    loadChildren: () =>
      import('../auth-login/auth-login.module').then(
        (m) => m.AuthLoginModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthShellRoutingModule { }
