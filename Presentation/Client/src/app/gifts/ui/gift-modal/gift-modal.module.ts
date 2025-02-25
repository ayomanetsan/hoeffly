import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GiftModalComponent } from './gift-modal.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DropdownModule } from '../../../shared/ui/dropdown/dropdown.module';



@NgModule({
    declarations: [
        GiftModalComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        DropdownModule,
    ]
})
export class GiftModalModule { }
