import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { WishlistCategories } from '../../models/wishlistCategories';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WishlistsService } from '../../data-access/wishlists.service';
import { WishlistCreateRequest } from '../../models/wishlist';

@Component({
  selector: 'app-wishlist-create',
  templateUrl: './wishlist-create.component.html',
  styleUrl: './wishlist-create.component.sass'
})
export class WishlistCreateComponent implements OnInit{
  wishlistForm!: FormGroup;
  wishlistCategories: string[] = WishlistCategories;

  constructor(
    private dialogRef: MatDialogRef<WishlistCreateComponent>,
    private fb: FormBuilder,
    private wishlistsService: WishlistsService) { }

  ngOnInit() {
    this.wishlistForm = this.fb.group({
      name: ['', Validators.required],
      isPublic: [false],
      selectedCategories: [[], Validators.required],
    });
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

      const wishlistCreateRequest: WishlistCreateRequest = {
        name: this.wishlistForm.get('name')?.value,
        isPublic: this.wishlistForm.get('isPublic')?.value,
        categories: categories
      }

      this.wishlistsService.create(wishlistCreateRequest).subscribe({
        next: () => {
          this.dialogRef.close(true);
        },
      });
    }
  }
}
