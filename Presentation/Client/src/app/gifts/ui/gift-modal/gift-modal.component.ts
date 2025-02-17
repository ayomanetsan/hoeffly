import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Currency, Priority } from '../../models/gift';

@Component({
  selector: 'app-gift-modal',
  templateUrl: './gift-modal.component.html',
  styleUrl: './gift-modal.component.sass'
})
export class GiftModalComponent implements OnInit {

  giftForm!: FormGroup;
  isEditMode = false;

  constructor(
      private dialogRef: MatDialogRef<GiftModalComponent>,
      private fb: FormBuilder,
      @Inject(MAT_DIALOG_DATA) public data: { wishlistId: string }
  ) { }

  ngOnInit() {
    this.isEditMode = this.data.wishlistId === '';
    this.initForm();
  }

  initForm() {
    this.giftForm = this.fb.group({
      name: ['', Validators.required],
      note: ['', Validators.required],
      shopLink: ['', Validators.required],
      photoLink: ['', Validators.required],
      thumbnailLink: ['', Validators.required],
      price: [0, Validators.required],
      currency: [Currency, Validators.required],
      priority: [Priority, Validators.required],
    });
  }

  close() {
    this.dialogRef.close();
  }

  onSubmit() {
  }

}
