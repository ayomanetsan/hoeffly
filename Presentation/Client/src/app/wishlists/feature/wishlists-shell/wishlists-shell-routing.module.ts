import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'library',
    loadChildren: () =>
      import('../wishlists-library/wishlists-library.module').then(
        (m) => m.WishlistsLibraryModule
      ),
    title: 'Wishlists - Library'
  },
  {
    path: ':id',
    loadChildren: () =>
        import('../wishlist-page/wishlist-page.module').then(
            (m) => m.WishlistPageModule
        ),
    title: 'Wishlist'
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WishlistsShellRoutingModule { }
