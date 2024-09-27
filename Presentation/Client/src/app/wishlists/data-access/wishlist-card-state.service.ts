import { Injectable } from '@angular/core';
import {Subject} from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class WishlistCardStateService {
  private menuOpenedSource = new Subject<string | null>();

  menuOpened$ = this.menuOpenedSource.asObservable();

  notifyMenuOpened(wishlistId: string | null): void {
    this.menuOpenedSource.next(wishlistId);
  }
}
