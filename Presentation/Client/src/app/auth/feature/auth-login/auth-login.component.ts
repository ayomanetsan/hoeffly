import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../../data-access/auth.service";

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styleUrl: './auth-login.component.sass'
})
export class AuthLoginComponent {
  loginForm: FormGroup;
  loading: boolean = false;

  constructor(private auth: AuthService, private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  async login() {
    if (this.loginForm.valid) {
      this.loading = true;
      try {
        const { email, password } = this.loginForm.value;
        await this.auth.login(email, password);
      } finally {
        this.loading = false;
      }
    }
  }

  async loginWithGoogle() {
    await this.auth.loginWithGoogle();
  }
}
