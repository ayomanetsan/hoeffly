import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import {Currency, GiftCreateRequest, Priority} from '../../models/gift';
import {GiftService} from "../../data-access/gift.service";
import {GiftCategories} from "../../models/giftCategories";

@Component({
  selector: 'app-gift-modal',
  templateUrl: './gift-modal.component.html',
  styleUrl: './gift-modal.component.sass'
})
export class GiftModalComponent implements OnInit {

  giftForm!: FormGroup;
  isEditMode = false;
  categories = GiftCategories;
  Currency = Currency;
  Priority = Priority;

  currencies = [
    { value: Currency.EUR, label: 'EUR' },
    { value: Currency.UAH, label: 'UAH' },
    { value: Currency.USD, label: 'USD' }
  ];

  priorities = [
    { value: Priority.MustHave, label: 'Must Have' },
    { value: Priority.ReallyWanted, label: 'Really Wanted' },
    { value: Priority.WouldLike, label: 'Would Like' },
    { value: Priority.NiceToHave, label: 'Nice to Have' },
    { value: Priority.Optional, label: 'Optional' }
  ];

  constructor(
      private dialogRef: MatDialogRef<GiftModalComponent>,
      private fb: FormBuilder,
      private giftService: GiftService,
      @Inject(MAT_DIALOG_DATA) public data: { wishlistId: string }
  ) { }

  ngOnInit() {
    this.isEditMode = this.data.wishlistId === '';
    this.initForm();
  }

  initForm() {
    this.giftForm = this.fb.group({
      name: ['', Validators.required],
      categoryName: ['', Validators.required],
      note: ['', Validators.required],
      shopLink: ['', Validators.required],
      photoLink: ['', Validators.required],
      thumbnailLink: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      currency: [Currency.USD, [Validators.required]],
      priority: [Priority.MustHave, [Validators.required]],
    });
  }

  close() {
    this.dialogRef.close();
  }

  onSubmit() {
    if (this.giftForm.valid) {
      const formValue = this.giftForm.value;

      const giftCreateRequest: GiftCreateRequest = {
        ...formValue,
        wishlistId: this.data.wishlistId,
        currency: Number(formValue.currency),
        priority: Number(formValue.priority)
      }


      if (this.isEditMode) {

      } else {
        console.log(giftCreateRequest);
        this.giftService.create(giftCreateRequest).subscribe({
          next: () => {
            this.dialogRef.close(true);
          },
        });
      }
    }
  }

}
