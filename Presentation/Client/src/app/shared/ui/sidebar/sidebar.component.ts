import { Component } from '@angular/core';
import { links } from '../../utils/link-data';
import { AuthService } from '../../../auth/data-access/auth.service';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrl: './sidebar.component.sass',
    standalone: false
})
export class SidebarComponent {

  links = links;
  displayName: string;
  photoUrl: string | null;

  constructor(private authService: AuthService) {
    this.displayName = localStorage.getItem('displayName') as string;
    this.photoUrl = localStorage.getItem('photoUrl');
  }

  async logout() {
    await this.authService.logout();
  }
}
