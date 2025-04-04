import { CommonModule, NgOptimizedImage } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { Avatar } from 'primeng/avatar';
import { Menu } from 'primeng/menu';
import { SidebarComponent } from './sidebar.component';

@NgModule({
  declarations: [SidebarComponent],
  exports: [SidebarComponent],
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive,
    NgOptimizedImage,
    Avatar,
    Menu,
  ],
})
export class SidebarModule {}
