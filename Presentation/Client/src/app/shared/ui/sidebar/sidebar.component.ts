import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../auth/data-access/auth.service';
import { links } from '../../utils/link-data';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  standalone: false,
})
export class SidebarComponent implements OnInit {
  links = links;
  displayName!: string;
  photoUrl: string | undefined;
  email!: string;

  constructor(private authService: AuthService) {}

  async ngOnInit() {
    this.displayName = localStorage.getItem('displayName') as string;
    this.photoUrl = localStorage.getItem('photoUrl') as string | undefined;
    this.email = await this.authService.getCurrentUserEmail();
  }

  async logout() {
    await this.authService.logout();
  }
}
