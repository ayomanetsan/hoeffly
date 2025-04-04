import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { provideHttpClient } from '@angular/common/http';
import { initializeApp, provideFirebaseApp } from '@angular/fire/app';
import { getAuth, provideAuth } from '@angular/fire/auth';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ToastrModule } from 'ngx-toastr';
import { providePrimeNG } from 'primeng/config';
import { environment } from '../environments/environment.development';
import { Hoeffly } from '../hoeffly-prime-preset';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    provideHttpClient(),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: Hoeffly,
        options: {
          darkModeSelector: 'none',
        },
      },
    }),
    provideFirebaseApp(() => initializeApp(environment.firebase)),
    provideAuth(() => getAuth()),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
