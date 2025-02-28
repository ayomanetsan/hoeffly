import { Component } from '@angular/core';
import { AuthService } from "../../data-access/auth.service";
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from "@angular/forms";

@Component({
  selector: 'app-auth-register',
  templateUrl: './auth-register.component.html',
  styleUrl: './auth-register.component.sass'
})
export class AuthRegisterComponent {
  registerForm: FormGroup;
  loading: boolean = false;
  showPassword: boolean = false;
  showRepeatPassword: boolean = false;

  constructor(private auth: AuthService, private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(32),
        Validators.pattern(/^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!?*.]).{8,32}$/)
      ]],
      repeatPassword: ['', Validators.required]
    }, { validator: this.passwordMatchValidator });
  }

  async register() {
    if (this.registerForm.valid) {
      this.loading = true;
      try {
        const { fullName, email, password } = this.registerForm.value;
        await this.auth.register(fullName, email, password);
      } finally {
        this.loading = false;
      }
    }
  }

  async loginWithGoogle() {
    await this.auth.loginWithGoogle();
  }

  togglePasswordVisibility(isForRepeatPassword: boolean) {
    let passwordInput: HTMLInputElement;

    if (isForRepeatPassword) {
      this.showRepeatPassword = !this.showPassword;
      passwordInput = document.getElementById('repeatPassword') as HTMLInputElement;
    } else {
      this.showPassword = !this.showPassword;
      passwordInput = document.getElementById('password') as HTMLInputElement;
    }

    passwordInput.type = this.showPassword ? 'text' : 'password';
  }

  private passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password');
    const repeatPassword = control.get('repeatPassword');

    if (password && repeatPassword && password.value !== repeatPassword.value) {
      return { passwordMismatch: true };
    }

    return null;
  }
}
