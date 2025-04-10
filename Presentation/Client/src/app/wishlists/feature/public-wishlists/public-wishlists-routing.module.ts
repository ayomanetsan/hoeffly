import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {PublicWishlistsComponent} from "./public-wishlists.component";

const routes: Routes = [
  {
    path: '',
    component: PublicWishlistsComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicWishlistsRoutingModule { }
