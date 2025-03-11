import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/compat/auth';
import { map, take } from 'rxjs/operators';
import { Router } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const afAuth = inject(AngularFireAuth);
  const router = inject(Router);

  return afAuth.authState.pipe(
    take(1),
    map(user => {
      if (user) {
        // User is authenticated, allow access
        return true;
      } else {
        // User is not authenticated, redirect to the login page
        return router.createUrlTree(['/auth/login']);
      }
    })
  );
};
