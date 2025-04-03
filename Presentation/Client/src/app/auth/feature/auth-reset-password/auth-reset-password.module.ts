import { CommonModule, NgOptimizedImage } from '@angular/common';
import { NgModule } from '@angular/core';

import { ReactiveFormsModule } from '@angular/forms';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';
import { InputText } from 'primeng/inputtext';
import { Message } from 'primeng/message';
import { AuthResetPasswordRoutingModule } from './auth-reset-password-routing.module';
import { AuthResetPasswordComponent } from './auth-reset-password.component';

@NgModule({
  declarations: [AuthResetPasswordComponent],
  imports: [
    CommonModule,
    AuthResetPasswordRoutingModule,
    ReactiveFormsModule,
    Button,
    Divider,
    InputText,
    Message,
    NgOptimizedImage,
  ],
})
export class AuthResetPasswordModule {}
