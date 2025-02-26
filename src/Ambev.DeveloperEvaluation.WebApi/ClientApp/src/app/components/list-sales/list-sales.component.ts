import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';  // For buttons
import { MatIconModule } from '@angular/material/icon'; // For icons like delete
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-list-sales',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule
  ],
  template: `
    <mat-card class="sales-card">
      <h2>List Sales</h2>
      <div class="sales-table">
        <mat-table [dataSource]="sales">
          <!-- Customer Column -->
          <ng-container matColumnDef="customer">
            <mat-header-cell *matHeaderCellDef> Customer </mat-header-cell>
            <mat-cell *matCellDef="let sale">{{ sale.customer }}</mat-cell>
          </ng-container>

          <!-- Branch Column -->
          <ng-container matColumnDef="branch">
            <mat-header-cell *matHeaderCellDef> Branch </mat-header-cell>
            <mat-cell *matCellDef="let sale">{{ sale.branch }}</mat-cell>
          </ng-container>

          <!-- Date Column -->
          <ng-container matColumnDef="date">
            <mat-header-cell *matHeaderCellDef> Date </mat-header-cell>
            <mat-cell *matCellDef="let sale">{{ sale.date }}</mat-cell>
          </ng-container>

          <!-- Total Amount Column -->
          <ng-container matColumnDef="totalAmount">
            <mat-header-cell *matHeaderCellDef> Total Amount </mat-header-cell>
            <mat-cell *matCellDef="let sale">{{ sale.totalAmount | currency }}</mat-cell>
          </ng-container>

          <!-- Actions Column (Buttons like Edit/Delete) -->
          <ng-container matColumnDef="actions">
            <mat-header-cell *matHeaderCellDef> Actions </mat-header-cell>
            <mat-cell *matCellDef="let sale">
              <button mat-icon-button color="warn" (click)="deleteSale(sale)">
                <mat-icon>delete</mat-icon>
              </button>
            </mat-cell>
          </ng-container>

          <!-- Table Header & Body -->
          <mat-header-row *matHeaderRowDef="displayedColumns"></mat-header-row>
          <mat-row *matRowDef="let row; columns: displayedColumns;"></mat-row>
        </mat-table>
      </div>
    </mat-card>
  `,
  styleUrls: ['./list-sales.component.scss']
})
export class ListSalesComponent { 
  sales = [
    { customer: 'John Doe', branch: 'New York', date: '2025-01-01', totalAmount: 500.00 },
    { customer: 'Jane Smith', branch: 'Los Angeles', date: '2025-01-05', totalAmount: 750.00 },
    { customer: 'Alice Johnson', branch: 'Chicago', date: '2025-01-10', totalAmount: 620.00 }
  ];

  displayedColumns: string[] = ['customer', 'branch', 'date', 'totalAmount', 'actions'];

  deleteSale(sale: any): void {
    
    console.log('Delete sale:', sale);
    
    this.sales = this.sales.filter(s => s !== sale);
  }
}
