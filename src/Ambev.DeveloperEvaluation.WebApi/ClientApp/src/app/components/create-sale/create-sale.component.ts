import { Component, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { SaleItemModalComponent } from '../../sale-item-modal/sale-item-modal.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SaleService } from '../../services/SaleService';

@Component({
  selector: 'app-create-sale',
  templateUrl: './create-sale.component.html',
  styleUrls: ['./create-sale.component.css']
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

  // Getter for items form array
  get items(): FormArray {
    return this.saleForm.get('items') as FormArray;
  }

  // Add item to the FormArray
  addSaleItem(): void {
    const dialogRef = this.dialog.open(SaleItemModalComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        const itemFormGroup = this.fb.group({
          product: [result.product, Validators.required],
          quantity: [result.quantity, [Validators.required, Validators.min(1)]],
          unitPrice: [result.unitPrice, [Validators.required, Validators.min(0)]],
        });

        this.items.push(itemFormGroup); // Add item to the FormArray
        this.updateTotalAmount();        // Update total amount
        this.cdRef.detectChanges();      // Trigger change detection
      }
    });
  }

  // Remove item from the FormArray
  removeSaleItem(item: any): void {
    const index = this.items.controls.indexOf(item);
    if (index >= 0) {
      this.items.removeAt(index); // Remove item from the FormArray
      this.updateTotalAmount();   // Update total amount
    }
  }

  updateTotalAmount(): void {
    const total = this.items.controls.reduce((sum, item) => {
      const value = item.value;
      return sum + (value.quantity * value.unitPrice);
    }, 0);

    this.saleForm.patchValue({ totalAmount: total });
  }

  // Submit the sale form
  onSubmit(): void {
    if (this.saleForm.valid) {
      const sale = this.saleForm.value;

      this.saleService.createSale(sale).subscribe({
        next: () => {
          this.saleForm.reset();
          this.showNotification("Sale saved successfully!", "success");
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
