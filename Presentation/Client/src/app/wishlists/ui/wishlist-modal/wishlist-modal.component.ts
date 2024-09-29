import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { WishlistCategories } from '../../models/wishlistCategories';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WishlistsService } from '../../data-access/wishlists.service';
import {WishlistBriefResponse, WishlistCreateRequest, WishlistUpdateRequest} from '../../models/wishlist';

@Component({
  selector: 'app-wishlist-modal',
  templateUrl: './wishlist-modal.component.html',
  styleUrl: './wishlist-modal.component.sass'
})
export class WishlistModalComponent implements OnInit{
  wishlistForm!: FormGroup;
  wishlistCategories: string[] = WishlistCategories;
  isEditMode = false;

  constructor(
    private dialogRef: MatDialogRef<WishlistModalComponent>,
    private fb: FormBuilder,
    private wishlistsService: WishlistsService,
    @Inject(MAT_DIALOG_DATA) public data: { wishlist?: WishlistBriefResponse, mode: string }
  ) { }

  ngOnInit() {
    if(this.data.mode == "edit"){
      this.isEditMode = true;
    }
    else {
      this.isEditMode = false;
    }

    this.initForm();
  }

  initForm() {
    this.wishlistForm = this.fb.group({
      name: [this.data?.wishlist?.name || '', Validators.required],
      isPublic: [this.data?.wishlist?.isPublic || false],
      selectedCategories: [this.getSelectedCategoryIndices(), Validators.required],
    });
  }

  getSelectedCategoryIndices(): number[] {
    if (!this.data?.wishlist?.categories) return [];
    return this.data.wishlist.categories.map(cat => this.wishlistCategories.indexOf(cat));
  }

  close() {
    this.dialogRef.close();
  }

  changeVisibilityInput(isPublic: boolean) {
    this.wishlistForm.patchValue({ isPublic });
  }

  selectCategory(index: number) {
    const selectedCategories = this.wishlistForm.get('selectedCategories')?.value as number[];
    const categoryIndex = selectedCategories.indexOf(index);

    if (categoryIndex === -1) {
      if (selectedCategories.length < 3) {
        selectedCategories.push(index);
      }
    } else {
      selectedCategories.splice(categoryIndex, 1);
    }

    this.wishlistForm.patchValue({ selectedCategories });
  }

  isSelectedCategory(index: number): boolean {
    return (this.wishlistForm.get('selectedCategories')?.value as number[]).indexOf(index) !== -1;
  }

  onSubmit() {
    if (this.wishlistForm.valid) {
      const categories = this.wishlistCategories.filter((cat, index) =>
        (this.wishlistForm.get('selectedCategories')?.value as number[]).includes(index)
      );

      const wishlistRequest: WishlistCreateRequest = {
        name: this.wishlistForm.get('name')?.value,
        isPublic: this.wishlistForm.get('isPublic')?.value,
        categories: categories
      }
      const wishlistUpdateRequest: WishlistUpdateRequest = {
        id: this.data.wishlist!.id,
        name: this.wishlistForm.get('name')?.value,
        isPublic: this.wishlistForm.get('isPublic')?.value,
        categories: categories
      }

      if (this.isEditMode) {
        this.wishlistsService.update(wishlistUpdateRequest.id, wishlistUpdateRequest).subscribe({
          next: () => {
            this.dialogRef.close(true);
          },
        });
      } else {
        this.wishlistsService.create(wishlistRequest).subscribe({
          next: () => {
            this.dialogRef.close(true);
          },
        });
      }
    }
  }
}
