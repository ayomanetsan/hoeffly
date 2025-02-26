import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthResetPasswordRoutingModule } from './auth-reset-password-routing.module';
import { AuthResetPasswordComponent } from './auth-reset-password.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AuthResetPasswordComponent
  ],
  imports: [
    CommonModule,
    AuthResetPasswordRoutingModule,
    ReactiveFormsModule
  ]
})
export class AuthResetPasswordModule { }
