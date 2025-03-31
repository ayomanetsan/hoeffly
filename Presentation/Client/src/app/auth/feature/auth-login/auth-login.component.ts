import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../../data-access/auth.service";

@Component({
    selector: 'app-auth-login',
    templateUrl: './auth-login.component.html',
    styleUrl: './auth-login.component.sass',
    standalone: false
})
export class AuthLoginComponent {
  loginForm: FormGroup;
  loading: boolean = false;
  showPassword: boolean = false;

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

  togglePasswordVisibility() {
    this.showPassword = !this.showPassword;
    const passwordInput = document.getElementById('password') as HTMLInputElement;
    passwordInput.type = this.showPassword ? 'text' : 'password';
  }
}
