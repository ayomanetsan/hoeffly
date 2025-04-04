import { inject } from '@angular/core';
import { Auth } from '@angular/fire/auth';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const auth = inject(Auth);
  const router = inject(Router);

  return new Promise((resolve) => {
    auth.onAuthStateChanged((user) => {
      if (user) {
        // User is authenticated, allow access
        resolve(true);
      } else {
        // User is not authenticated, redirect to the login page
        resolve(router.createUrlTree(['/auth/login']));
      }
    });
  });
};
