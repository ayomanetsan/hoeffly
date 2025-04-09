import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { Button } from 'primeng/button';
import { Menu } from 'primeng/menu';
import { Tag } from 'primeng/tag';
import { GiftCardComponent } from './gift-card.component';

@NgModule({
  declarations: [GiftCardComponent],
  exports: [GiftCardComponent],
  imports: [CommonModule, Tag, Button, Menu],
})
export class GiftCardModule {}
