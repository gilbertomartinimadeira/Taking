import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';  // For buttons
import { MatIconModule } from '@angular/material/icon'; // For icons like delete
import { MatCardModule } from '@angular/material/card';
import { SaleService } from '../../services/SaleService';
import { Sale } from '../../models/Sale';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import SaleListItem from '../../models/SaleListItem';

@Component({
  selector: 'app-list-sales',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatSnackBarModule
  ],
  templateUrl: './list-sales.component.html',
  styleUrls: ['./list-sales.component.scss']
})
export class ListSalesComponent implements OnInit{

  sales: SaleListItem[] = [];
  originalSales: { [key: number]: SaleListItem } = {}; // Store original values for canceling
  constructor(private saleService: SaleService, private snackBar: MatSnackBar) {
    const currentDate = new Date().toISOString().split('T')[0];
  }

  ngOnInit() {   
    this.saleService.listSales().subscribe(response => {    
      this.sales = response.data.data.sales;
    });   
  }
  displayedColumns: string[] = ['customer', 'branch', 'date', 'totalAmount', 'actions'];

  deleteSale(sale: Sale): void {
    
    console.log('Delete sale:', sale);
    debugger;
    
    
    this.saleService.cancelSale(sale.id).subscribe(result => {
      this.showNotification("Sale removed successfully!", "success");
      this.sales = this.sales.filter(s => s.id !== sale.id);
    });
  }

  editSale(sale: Sale): void {
    console.log(sale);
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
