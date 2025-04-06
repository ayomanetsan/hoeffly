import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Button } from 'primeng/button';
import { DatePicker } from 'primeng/datepicker';
import { InputText } from 'primeng/inputtext';
import { RadioButton } from 'primeng/radiobutton';
import { CreateDialogComponent } from './create-dialog.component';

@NgModule({
  declarations: [CreateDialogComponent],
  imports: [
    CommonModule,
    Button,
    InputText,
    ReactiveFormsModule,
    DatePicker,
    RadioButton,
  ],
})
export class CreateDialogModule {}
