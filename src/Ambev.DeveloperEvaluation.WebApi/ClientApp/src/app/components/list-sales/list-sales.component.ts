import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-list-sales',
  standalone: true,
  imports: [CommonModule],
  template: `<h2>List Sales</h2>
             <p>Table or list of sales will be displayed here.</p>`,
  styleUrls: ['./list-sales.component.scss']
})
export class ListSalesComponent { }
