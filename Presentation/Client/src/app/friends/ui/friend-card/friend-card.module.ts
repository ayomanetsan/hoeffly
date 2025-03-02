import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FriendCardComponent } from './friend-card.component';



@NgModule({
  declarations: [
    FriendCardComponent
  ],
  exports: [
    FriendCardComponent
  ],
  imports: [
    CommonModule
  ]
})
export class FriendCardModule { }
