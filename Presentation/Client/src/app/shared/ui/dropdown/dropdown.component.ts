import { Component, forwardRef, Input, TemplateRef, ViewChild, ElementRef, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { DropdownOption } from '../../models/dropdownOption';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.sass'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DropdownComponent),
      multi: true,
    },
  ],
})
export class DropdownComponent implements ControlValueAccessor {
  @Input() options: DropdownOption[] = [];
  @Input() placeholder: string = 'Select an option';
  @Input() noResultsText: string = 'No results found';
  @Input() optionTemplate!: TemplateRef<any>;
  @Input() debounceTime: number = 300;

  @ViewChild('dropdownInput') dropdownInput!: ElementRef;
  @ViewChild('dropdownList') dropdownList!: ElementRef;

  searchControl = new FormControl('');
  filteredOptions: DropdownOption[] = [];
  isOpen: boolean = false;
  selectedOption: DropdownOption | null = null;

  constructor() {
    this.searchControl.valueChanges
        .pipe(debounceTime(this.debounceTime), distinctUntilChanged())
        .subscribe((value) => {
          if (!value) {
            this.clearSelection();
          }
          this.filterOptions(value);
        });
  }

  writeValue(value: any): void {
    if (value !== undefined) {
      const matchingOption = this.options.find((option) => option.value === value);
      this.searchControl.setValue(matchingOption?.text || '');
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  onChange: any = () => {};
  onTouched: any = () => {};

  filterOptions(searchTerm: string | null): void {
    if (!searchTerm) {
      this.filteredOptions = this.options;
      return;
    }
    this.filteredOptions = this.options.filter((option) =>
        option.text.toLowerCase().includes(searchTerm.toLowerCase())
    );
  }

  toggleDropdown(): void {
    this.isOpen = !this.isOpen;
    if (this.isOpen) {
      this.filteredOptions = this.options;
      setTimeout(() => this.dropdownInput.nativeElement.focus(), 0);
    }
  }

  selectOption(option: DropdownOption): void {
    this.selectedOption = option;
    this.searchControl.setValue(option.text);
    this.onChange(option.value);
    this.isOpen = false;
  }

  clearSelection(): void {
    this.selectedOption = null;
    this.searchControl.setValue(''); 
    this.onChange(null); 
    this.filteredOptions = this.options; 
  }
}
