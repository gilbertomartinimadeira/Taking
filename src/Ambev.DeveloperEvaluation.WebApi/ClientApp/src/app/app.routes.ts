import { Routes } from '@angular/router';
import { CreateSaleComponent } from './components/create-sale/create-sale.component';
import { ListSalesComponent } from './components/list-sales/list-sales.component';

export const routes: Routes = [
  { path: 'create-sale', component: CreateSaleComponent },
  { path: 'list-sales', component: ListSalesComponent },
  { path: '', redirectTo: '/create-sale', pathMatch: 'full' } // Default route
];
