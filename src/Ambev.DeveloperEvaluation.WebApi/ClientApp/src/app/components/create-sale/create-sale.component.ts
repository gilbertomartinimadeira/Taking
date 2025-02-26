import { Component, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { SaleItemModalComponent } from '../../sale-item-modal/sale-item-modal.component';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-create-sale',
  templateUrl: './create-sale.component.html',
  styleUrls: ['./create-sale.component.css'],
  standalone: true,
  imports: [
    ReactiveFormsModule,
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatCheckboxModule,
    MatDialogModule,
    MatCardModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatButtonModule,
    MatIconModule
  ]
})
export class CreateSaleComponent {
  saleForm: FormGroup;
  displayedColumns: string[] = ['product', 'quantity', 'unitPrice', 'actions'];

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private cdRef: ChangeDetectorRef  // Inject ChangeDetectorRef
  ) {
    const currentDate = new Date().toISOString().split('T')[0];

    this.saleForm = this.fb.group({
      customer: ['', Validators.required],
      totalAmount: [0, [Validators.required, Validators.min(0)]],
      branch: ['', Validators.required],
      date: [currentDate], // Set current date as default
      isCancelled: [false],
      items: this.fb.array([]),
    });
  }

  get items(): FormArray {
    return this.saleForm.get('items') as FormArray;
  }

  // Add Sale Item to FormArray after Save Item modal
  addSaleItem(): void {
    const dialogRef = this.dialog.open(SaleItemModalComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Add Sale Item to FormArray
        const itemFormGroup = this.fb.group({
          product: [result.product, Validators.required],
          quantity: [result.quantity, [Validators.required, Validators.min(1)]],
          unitPrice: [result.unitPrice, [Validators.required, Validators.min(0)]],
          discount: [result.discount, [Validators.min(0)]]
        });

        this.items.push(itemFormGroup); // Add the new item to the items array
        this.updateTotalAmount(); // Update the total amount whenever a new item is added

        this.cdRef.markForCheck(); // Manually trigger change detection to update the table
      }
    });
  }

  removeSaleItem(item: any): void {
    const index = this.items.controls.indexOf(item);
    if (index >= 0) {
      this.items.removeAt(index); // Remove the item from the FormArray
      this.updateTotalAmount(); // Update the total amount after item removal
      this.cdRef.markForCheck(); // Trigger change detection to update the table
    }
  }

  updateTotalAmount(): void {
    const total = this.items.controls.reduce((sum, item) => {
      const value = item.value;
      const amount = (value.quantity * value.unitPrice) - value.discount;
      return sum + amount;
    }, 0);

    this.saleForm.patchValue({ totalAmount: total }); // Update the total amount in the form
  }

  onSubmit(): void {
    if (this.saleForm.valid) {
      console.log(this.saleForm.value); // Submit sale
    }
  }

  onCancel(): void {
    console.log("Sale creation cancelled.");
  }
}
