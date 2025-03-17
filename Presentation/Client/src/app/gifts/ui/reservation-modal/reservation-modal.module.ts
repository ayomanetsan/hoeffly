import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationModalComponent } from './reservation-modal.component';
import { DropdownModule } from '../../../shared/ui/dropdown/dropdown.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ReservationModalComponent
  ],
    imports: [
        CommonModule,
        DropdownModule,
        ReactiveFormsModule
    ]
})
export class ReservationModalModule { }
