import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import {
  CurrencyCategories,
  GiftCategories,
  GiftCreateRequest, GiftResponse, GiftUpdateRequest,
  PriorityCategories
} from '../../models/gift';
import { ImageService } from '../../../shared/data-access/image.service';
import { GiftService } from '../../data-access/gift.service';
import { ToastrService } from 'ngx-toastr';

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
  imageUrl: string | null = null;
  scraping: boolean = false;
  creating: boolean = false;

  readonly categories = GiftCategories;
  readonly currencies = CurrencyCategories;
  readonly priorities = PriorityCategories;

  constructor(
      private dialogRef: MatDialogRef<GiftModalComponent>,
      private fb: FormBuilder,
      private imageService: ImageService,
      private giftService: GiftService,
      private toastr: ToastrService,
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

  scrapeGift() {
    if (!this.giftForm.value.shopLink) {
      this.toastr.info('Please provide a shop link');
      return;
    }

    this.scraping = true;
    this.giftService.scrapeGiftDetails(this.giftForm.value.shopLink).subscribe(res => {
      this.scraping = false;

      if (res.isEmpty) {
        this.toastr.error('No data found for the provided link');
        return;
      }

      if (res.name) {
        this.giftForm.patchValue({
          name: res.name
        });
      }

      if (res.price) {
        this.giftForm.patchValue({
          price: res.price
        });
      }

      if (res.currency) {
        this.giftForm.patchValue({
          currency: CurrencyCategories.find(currency => currency.text === res.currency)?.value
        });
      }

      if (res.imageUrl) {
        this.imagePreview = res.imageUrl;
        this.imageUrl = res.imageUrl;
      }
    });
  }

  // TODO: Refactor the method to include the image upload logic
  onSubmit() {
    if (this.giftForm.valid) {
      this.creating = true;
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
                return;
              },
            });
          });
        }

        if (this.imageUrl) {
          this.imageService.uploadImage(this.imageUrl, this.giftForm.value.name).subscribe({
            next: (imageBbResponse) => {
              giftCreateRequest.photoLink = imageBbResponse.data.image.url;
              giftCreateRequest.thumbnailLink = imageBbResponse.data.thumb.url;

              this.giftService.create(giftCreateRequest).subscribe({
                next: () => {
                  this.dialogRef.close(true);
                },
              });
            },
            error: (err) => {
              if (err.error.error.message.includes('Can\'t download remote image [ 403 ]')) {
                this.toastr.error('Cannot download remote image. Please upload an image instead');
                this.imageUrl = null;
                this.imagePreview = null;
                this.creating = false;
              }
            }
          });
        }
      }
    }
  }
}
