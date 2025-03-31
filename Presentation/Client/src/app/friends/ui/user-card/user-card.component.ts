import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserResponse } from '../users';

@Component({
    selector: 'app-user-card',
    templateUrl: './user-card.component.html',
    styleUrl: './user-card.component.sass',
    standalone: false
})
export class UserCardComponent {

  @Input({required: true}) user!: UserResponse;
  @Output() requestSent = new EventEmitter<string>();

  sendRequest(): void {
    this.requestSent.emit(this.user.email);
  }

}
