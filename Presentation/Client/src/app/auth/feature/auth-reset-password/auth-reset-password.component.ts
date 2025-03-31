import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute } from '@angular/router';
import { AuthService } from "../../data-access/auth.service";

@Component({
    selector: 'app-auth-reset-password',
    templateUrl: './auth-reset-password.component.html',
    styleUrl: './auth-reset-password.component.sass',
    standalone: false
})
export class AuthResetPasswordComponent implements OnInit {
  resetPasswordForm: FormGroup;
  loading: boolean = false;
  resetSent: boolean = false;
  sentToEmail: string = '';
  errorMessage: string = '';

  constructor(
    private auth: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {
    this.resetPasswordForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  ngOnInit(): void {
    // Check if email was passed in the URL (e.g., from login page)
    this.route.queryParams.subscribe(params => {
      if (params['email']) {
        this.resetPasswordForm.get('email')?.setValue(params['email']);
      }
    });
  }

  async requestPasswordReset() {
    if (this.resetPasswordForm.valid) {
      this.loading = true;
      this.errorMessage = '';

      try {
        const { email } = this.resetPasswordForm.value;
        await this.auth.sendPasswordResetEmail(email);
        this.sentToEmail = email;
        this.resetSent = true;
      } finally {
        this.loading = false;
      }
    }
  }
}
