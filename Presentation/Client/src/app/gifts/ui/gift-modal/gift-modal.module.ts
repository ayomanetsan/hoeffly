import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GiftModalComponent } from './gift-modal.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
    declarations: [
        GiftModalComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
    ]
})
export class GiftModalModule { }
