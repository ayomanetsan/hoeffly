import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthLoginComponent } from "./auth-login.component";

const routes: Routes = [
  { path: '', component: AuthLoginComponent, title: 'Höffly - Sign In' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthLoginRoutingModule { }
