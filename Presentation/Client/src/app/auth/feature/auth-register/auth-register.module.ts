import { CommonModule, NgOptimizedImage } from '@angular/common';
import { NgModule } from '@angular/core';

import { ReactiveFormsModule } from '@angular/forms';
import { Button } from 'primeng/button';
import { Divider } from 'primeng/divider';
import { InputText } from 'primeng/inputtext';
import { Message } from 'primeng/message';
import { Password } from 'primeng/password';
import { AuthRegisterRoutingModule } from './auth-register-routing.module';
import { AuthRegisterComponent } from './auth-register.component';

@NgModule({
  declarations: [AuthRegisterComponent],
  imports: [
    CommonModule,
    AuthRegisterRoutingModule,
    ReactiveFormsModule,
    Button,
    Divider,
    InputText,
    Message,
    NgOptimizedImage,
    Password,
  ],
})
export class AuthRegisterModule {}
