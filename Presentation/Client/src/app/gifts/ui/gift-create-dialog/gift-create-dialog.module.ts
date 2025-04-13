import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Button } from 'primeng/button';
import { InputGroup } from 'primeng/inputgroup';
import { InputNumber } from 'primeng/inputnumber';
import { InputText } from 'primeng/inputtext';
import { Select } from 'primeng/select';
import { Textarea } from 'primeng/textarea';
import { Tooltip } from 'primeng/tooltip';
import { GiftCreateDialogComponent } from './gift-create-dialog.component';

@NgModule({
  declarations: [GiftCreateDialogComponent],
  imports: [
    CommonModule,
    Button,
    InputText,
    Select,
    ReactiveFormsModule,
    Textarea,
    InputNumber,
    InputGroup,
    Tooltip,
  ],
})
export class GiftCreateDialogModule {}
