import { CommonModule, NgOptimizedImage } from '@angular/common';
import { NgModule } from '@angular/core';

import { AnimateOnScroll } from 'primeng/animateonscroll';
import { Button } from 'primeng/button';
import { Chip } from 'primeng/chip';
import { InputGroup } from 'primeng/inputgroup';
import { InputText } from 'primeng/inputtext';
import { LandingRoutingModule } from './landing-routing.module';
import { LandingComponent } from './landing.component';

@NgModule({
  declarations: [LandingComponent],
  imports: [
    CommonModule,
    LandingRoutingModule,
    Button,
    NgOptimizedImage,
    Chip,
    AnimateOnScroll,
    InputGroup,
    InputText,
  ],
})
export class LandingModule {}
