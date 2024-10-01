import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./landing/feature/landing/landing.module').then(
        (m) => m.LandingModule
      ),
  },
  {
    path: 'auth',
    loadChildren: () =>
      import('./auth/feature/auth-shell/auth-shell.module').then(
        (m) => m.AuthShellModule
      ),
  },
  {
    path: 'wishlists',
    loadChildren: () =>
      import('./wishlists/feature/wishlists-shell/wishlists-shell.module').then(
        (m) => m.WishlistsShellModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
