import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Avatar } from 'primeng/avatar';
import { Button } from 'primeng/button';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { InputText } from 'primeng/inputtext';
import { Select } from 'primeng/select';
import { SelectButton } from 'primeng/selectbutton';
import { StyleClass } from 'primeng/styleclass';
import { Toast } from 'primeng/toast';
import { ShareModalComponent } from './share-modal.component';

@NgModule({
  declarations: [ShareModalComponent],
  imports: [
    CommonModule,
    Button,
    SelectButton,
    FormsModule,
    StyleClass,
    Select,
    ReactiveFormsModule,
    InputText,
    Toast,
    Avatar,
    ConfirmDialog,
  ],
})
export class ShareModalModule {}
