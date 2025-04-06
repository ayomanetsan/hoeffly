import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { WishlistsService } from '../../data-access/wishlists.service';
import {
  WishlistBriefResponse,
  WishlistCreateRequest,
  WishlistUpdateRequest,
} from '../../models/wishlist';
import { WishlistCategories } from '../../models/wishlistCategories';

@Component({
  selector: 'app-create-dialog',
  standalone: false,
  templateUrl: './create-dialog.component.html',
  providers: [DatePipe],
})
export class CreateDialogComponent implements OnInit {
  wishlist: WishlistBriefResponse | undefined;
  wishlistForm!: FormGroup;
  wishlistCategories: string[] = WishlistCategories;
  today = new Date();
  loading = false;

  constructor(
    private dialogRef: DynamicDialogRef,
    private config: DynamicDialogConfig,
    private datePipe: DatePipe,
    private fb: FormBuilder,
    private wishlistsService: WishlistsService,
  ) {
    this.wishlist = this.config.data as WishlistBriefResponse | undefined;
  }

  ngOnInit(): void {
    this.initForm();
  }

  close() {
    this.dialogRef.close();
  }

  selectCategory(index: number) {
    const selectedCategories = this.wishlistForm.get('selectedCategories')
      ?.value as number[];
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
    return (
      (this.wishlistForm.get('selectedCategories')?.value as number[]).indexOf(
        index,
      ) !== -1
    );
  }

  getSelectedCategoriesCount(): number {
    return (this.wishlistForm.get('selectedCategories')?.value as number[])
      .length;
  }

  onSubmit() {
    if (this.wishlistForm.invalid) {
      return;
    }

    const categories = this.wishlistCategories.filter((cat, index) =>
      (this.wishlistForm.get('selectedCategories')?.value as number[]).includes(
        index,
      ),
    );
    const occasionDate = new Date(
      this.wishlistForm.get('occasionDate')?.value,
    ).toISOString();

    if (this.wishlist) {
      const wishlistUpdateRequest: WishlistUpdateRequest = {
        id: this.wishlist.id,
        name: this.wishlistForm.get('name')?.value,
        isPublic: this.wishlistForm.get('isPublic')?.value,
        categories: categories,
        occasionDate: occasionDate,
      };

      this.wishlistsService
        .update(wishlistUpdateRequest.id, wishlistUpdateRequest)
        .subscribe({
          next: () => {
            this.dialogRef.close(true);
          },
        });
    } else {
      const wishlistRequest: WishlistCreateRequest = {
        name: this.wishlistForm.get('name')?.value,
        isPublic: this.wishlistForm.get('isPublic')?.value,
        categories: categories,
        occasionDate: occasionDate,
      };

      this.wishlistsService.create(wishlistRequest).subscribe({
        next: () => {
          this.dialogRef.close(true);
        },
      });
    }
  }

  private initForm() {
    const occasionDate: string | null = this.datePipe.transform(
      this.wishlist?.occasionDate,
      'd MMM y',
    );

    this.wishlistForm = this.fb.group({
      name: [this.wishlist?.name || '', Validators.required],
      isPublic: [this.wishlist?.isPublic || false],
      selectedCategories: [
        this.getSelectedCategoryIndices(),
        Validators.required,
      ],
      occasionDate: [occasionDate, Validators.required],
    });
  }

  private getSelectedCategoryIndices(): number[] {
    if (!this.wishlist?.categories) return [];
    return this.wishlist.categories.map((cat: string) =>
      this.wishlistCategories.indexOf(cat),
    );
  }
}
