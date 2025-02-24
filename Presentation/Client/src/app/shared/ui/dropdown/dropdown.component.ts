import { Component, forwardRef, Input, TemplateRef, ViewChild, ElementRef, HostListener } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR, FormControl } from '@angular/forms';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

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
  @Input() options: any[] = [];
  @Input() placeholder: string = 'Select an option';
  @Input() noResultsText: string = 'No results found';
  @Input() optionTemplate!: TemplateRef<any>;
  @Input() debounceTime: number = 300;

  @ViewChild('dropdownInput') dropdownInput!: ElementRef;
  @ViewChild('dropdownList') dropdownList!: ElementRef;

  searchControl = new FormControl('');
  filteredOptions: any[] = [];
  isOpen: boolean = false;
  selectedOption: any;

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
    this.selectedOption = value;
    if (value) {
      this.searchControl.setValue(value.displayText);
    } else {
      this.searchControl.setValue('');
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
        option.displayText.toLowerCase().includes(searchTerm.toLowerCase())
    );
  }

  toggleDropdown(): void {
    this.isOpen = !this.isOpen;
    if (this.isOpen) {
      this.filteredOptions = this.options;
      setTimeout(() => this.dropdownInput.nativeElement.focus(), 0);
    }
  }

  selectOption(option: any): void {
    this.selectedOption = option;
    this.searchControl.setValue(option.displayText);
    this.onChange(option.displayText);
    this.isOpen = false;
  }

  clearSelection(): void {
    this.selectedOption = null;
    this.searchControl.setValue(''); 
    this.onChange(null); 
    this.filteredOptions = this.options; 
  }
}
