import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import {
  Currency,
  CurrencyCategories,
  GiftCategories,
  GiftCreateRequest,
  Priority,
  PriorityCategories
} from '../../models/gift';
import { ImageService } from '../../../shared/data-access/image.service';
import { GiftService } from '../../data-access/gift.service';

@Component({
  selector: 'app-gift-modal',
  templateUrl: './gift-modal.component.html',
  styleUrl: './gift-modal.component.sass'
})
export class GiftModalComponent implements OnInit {

  giftForm!: FormGroup;
  isEditMode = false;

  selectedImage: File | null = null;
  imagePreview: string | ArrayBuffer | null = null;

  readonly categories = GiftCategories;
  readonly currencies = CurrencyCategories;
  readonly priorities = PriorityCategories;

  constructor(
      private dialogRef: MatDialogRef<GiftModalComponent>,
      private fb: FormBuilder,
      private imageService: ImageService,
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
      note: [''],
      categoryName: [Validators.required],
      shopLink: [''],
      price: [0, [Validators.required, Validators.min(0)]],
      currency: [[Validators.required]],
      priority: [[Validators.required]],
    });
  }

  close() {
    this.dialogRef.close();
  }

  onFileSelected(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      this.selectedImage = file;

      // Show image preview
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreview = reader.result;
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit() {
    console.log(this.giftForm.valid);
    if (this.giftForm.valid && this.selectedImage) {
      const formValue = this.giftForm.value;
      const giftCreateRequest: GiftCreateRequest = {
        ...formValue,
        wishlistId: this.data.wishlistId,
        currency: Number(formValue.currency),
        priority: Number(formValue.priority)
      }
      if (this.isEditMode) {
      } else {
        this.imageService.uploadImage(this.selectedImage, this.giftForm.value.name).subscribe(imageBbResponse => {
          giftCreateRequest.photoLink = imageBbResponse.data.image.url;
          giftCreateRequest.thumbnailLink = imageBbResponse.data.thumb.url;

          this.giftService.create(giftCreateRequest).subscribe({
            next: () => {
              this.dialogRef.close(true);
            },
          });
        });
      }
    }
  }

}
