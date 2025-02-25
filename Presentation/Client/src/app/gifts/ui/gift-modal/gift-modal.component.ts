import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import {
  Currency,
  CurrencyCategories,
  GiftCategories,
  GiftCreateRequest, GiftResponse, GiftUpdateRequest,
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
  giftId: string | null = null;

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
      @Inject(MAT_DIALOG_DATA) public data: { gift?: GiftResponse, wishlistId: string }
  ) { }

  ngOnInit() {
    this.isEditMode = !!this.data.gift;
    this.giftId = this.data.gift?.id || null;
    this.initForm();
  }

  initForm() {
    this.giftForm = this.fb.group({
      name: [this.data.gift?.name || '', Validators.required],
      note: [this.data.gift?.note || ''],
      categoryName: [this.data.gift?.categoryName || '', Validators.required],
      shopLink: [this.data.gift?.shopLink || ''],
      price: [this.data.gift?.price || 0, [Validators.required, Validators.min(0)]],
      currency: [this.data.gift?.currency || 0, [Validators.required]],
      priority: [this.data.gift?.priority || 0, [Validators.required]],
    });

    if (this.data.gift?.thumbnailLink) {
      this.imagePreview = this.data.gift.thumbnailLink;
    }
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

  // TODO: Refactor the method to include the image upload logic
  onSubmit() {
    if (this.giftForm.valid) {
      const formValue = this.giftForm.value;
      const giftCreateRequest: GiftCreateRequest = {
        ...formValue,
        wishlistId: this.data.wishlistId,
        currency: Number(formValue.currency),
        priority: Number(formValue.priority)
      };

      if (this.isEditMode && this.giftId) {
        const giftUpdateRequest: GiftUpdateRequest = {
            ...giftCreateRequest,
            id: this.giftId
        }
        console.log(giftUpdateRequest)
        // Handle update logic
        if (this.selectedImage) {
          this.imageService.uploadImage(this.selectedImage, this.giftForm.value.name).subscribe(imageBbResponse => {
            giftCreateRequest.photoLink = imageBbResponse.data.image.url;
            giftCreateRequest.thumbnailLink = imageBbResponse.data.thumb.url;

            this.giftService.update(giftUpdateRequest).subscribe({
              next: () => {
                this.dialogRef.close(true);
              },
            });
          });
        } else {
          // If the image was not changed, keep the existing image
          giftCreateRequest.photoLink = this.data.gift!.photoLink;
          giftCreateRequest.thumbnailLink = this.data.gift!.thumbnailLink;

          this.giftService.update(giftUpdateRequest).subscribe({
            next: () => {
              this.dialogRef.close(true);
            },
          });
        }
      } else {
        // Handle create logic
        if (this.selectedImage) {
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
}