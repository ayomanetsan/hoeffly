import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GiftCardComponent } from './gift-card.component';



@NgModule({
    declarations: [
        GiftCardComponent
    ],
    exports: [
        GiftCardComponent
    ],
    imports: [
        CommonModule
    ]
})
export class GiftCardModule { }
