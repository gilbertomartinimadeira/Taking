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
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

import { SaleService } from '../../services/SaleService';

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
    MatIconModule,
    MatSnackBarModule
  ]
})
export class CreateSaleComponent {
  saleForm: FormGroup;
  displayedColumns: string[] = ['product', 'quantity', 'unitPrice', 'actions'];

  constructor(
    private fb: FormBuilder,
    public dialog: MatDialog,
    private snackBar: MatSnackBar,
    private cdRef: ChangeDetectorRef,
    private saleService: SaleService
  ) {
    
    this.saleForm = this.fb.group({
      customer: ['', Validators.required],      
      branch: ['', Validators.required],         
      items: this.fb.array([]),
    });
  }

  get items(): FormArray {
    return this.saleForm.get('items') as FormArray;
  }

  addSaleItem(): void {
    const dialogRef = this.dialog.open(SaleItemModalComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {       
        const itemFormGroup = this.fb.group({
          product: [result.product, Validators.required],
          quantity: [result.quantity, [Validators.required, Validators.min(1)]],
          unitPrice: [result.unitPrice, [Validators.required, Validators.min(0)]],         
        });

        this.items.push(itemFormGroup);
        this.updateTotalAmount();        
      }
      return false;
    });
  }

  removeSaleItem(item: any): void {
    const index = this.items.controls.indexOf(item);
    if (index >= 0) {
      this.items.removeAt(index); 
      this.updateTotalAmount(); 
      this.cdRef.markForCheck();
    }
  }

  updateTotalAmount(): void {
    const total = this.items.controls.reduce((sum, item) => {
      const value = item.value;
      const amount = (value.quantity * value.unitPrice) - value.discount;
      return sum + amount;
    }, 0);

    this.saleForm.patchValue({ totalAmount: total }); 
  }

  onSubmit(): void {
    if (this.saleForm.valid) {
      const sale = this.saleForm.value;

      this.saleService.createSale(sale).subscribe({
        next: () => {         
          this.saleForm.reset();

          this.showNotification("Sale saved successfully!", "success");
          debugger;
          this.saleForm.errors && console.log(this.saleForm.errors);
        },
        error: (err) => {
          console.error("Error saving sale:", err);
          this.showNotification("Failed to save sale. Please try again.", "error");
        }
      });
    }
  }

  onCancel(): void {
    console.log("Sale creation cancelled.");
  }

  showNotification(message: string, type: "success" | "error"): void {
    this.snackBar.open(message, "Close", {
      duration: 5000, 
      panelClass: type === "success" ? "snackbar-success" : "snackbar-error",
      horizontalPosition: "right",
      verticalPosition: "bottom",
    });
  }
}
