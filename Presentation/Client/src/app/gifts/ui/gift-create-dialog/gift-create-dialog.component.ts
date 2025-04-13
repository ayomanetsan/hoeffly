import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import {
  Currency,
  CurrencyCategories,
  GiftCategories,
  PriorityCategories,
} from '../../models/gift';

@Component({
  selector: 'app-gift-create-dialog',
  standalone: false,
  templateUrl: './gift-create-dialog.component.html',
})
export class GiftCreateDialogComponent {
  giftCreateForm!: FormGroup;

  categoryDropdownOptions = GiftCategories;
  currencyDropdownOptions = CurrencyCategories;
  priorityDropdownOptions = PriorityCategories;

  previewImage: SafeUrl | string | null = null;
  imagePreviewLoading = false;

  constructor(
    private dialogRef: DynamicDialogRef,
    private fb: FormBuilder,
    private sanitizer: DomSanitizer,
  ) {}

  ngOnInit() {
    this.initForm();
  }

  closeDialog() {
    this.dialogRef.close();
  }

  loadImageFromUrl(url: string): void {
    this.imagePreviewLoading = true;

    // Create an image element to test if the URL loads properly
    const img = new Image();
    img.onload = () => {
      this.previewImage = this.sanitizer.bypassSecurityTrustUrl(url);
      this.imagePreviewLoading = false;
    };

    img.onerror = () => {
      this.previewImage = null;
      this.imagePreviewLoading = false;
      // Optionally, show an error message
      console.error('Failed to load image from URL');
    };

    img.src = url;
  }

  uploadImage(event: any): void {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.previewImage = this.sanitizer.bypassSecurityTrustUrl(
          e.target.result,
        );
        // Clear the URL input as we're now using an uploaded file
        this.giftCreateForm
          .get('photoLink')
          ?.setValue('', { emitEvent: false });
      };
      reader.readAsDataURL(file);
    }
  }

  onButtonClick(): void {
    // If there's a URL in the input, load that image
    const url = this.giftCreateForm.get('photoLink')?.value;
    if (url && url.trim()) {
      this.loadImageFromUrl(url);
    } else {
      // If no URL, trigger file upload dialog
      document.getElementById('fileUpload')?.click();
    }
  }

  get currency() {
    return Currency[this.giftCreateForm.get('currency')?.value];
  }

  private initForm() {
    this.giftCreateForm = this.fb.group({
      name: ['', Validators.required],
      category: ['Electronics', Validators.required],
      note: [''],
      shopLink: [''],
      photoLink: [''],
      thumbnailLink: [''],
      price: [0, Validators.required],
      currency: [Currency.USD, Validators.required],
      priority: [0, Validators.required],
      wishlistId: [''],
    });

    this.giftCreateForm.get('photoLink')?.valueChanges.subscribe((link) => {
      if (link && link.trim()) {
        this.loadImageFromUrl(link);
      } else {
        this.previewImage = null;
      }
    });
  }
}
