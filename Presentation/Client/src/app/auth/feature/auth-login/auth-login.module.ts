import { CommonModule, NgOptimizedImage } from '@angular/common';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';
import { InputText } from 'primeng/inputtext';
import { Message } from 'primeng/message';
import { Password } from 'primeng/password';
import { StyleClass } from 'primeng/styleclass';
import { AuthLoginRoutingModule } from './auth-login-routing.module';
import { AuthLoginComponent } from './auth-login.component';

@NgModule({
  declarations: [AuthLoginComponent],
  imports: [
    CommonModule,
    AuthLoginRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgOptimizedImage,
    Button,
    Divider,
    InputText,
    Message,
    Password,
    StyleClass,
  ],
})
export class AuthLoginModule {}
