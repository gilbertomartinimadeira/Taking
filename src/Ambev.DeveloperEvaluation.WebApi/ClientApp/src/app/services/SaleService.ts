import { Injectable } from '@angular/core';
import axios from 'axios';
import { Observable, from } from 'rxjs';
import { Sale } from '../models/Sale';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SaleService {
  private apiUrl = environment.apiUrl;

  createSale(sale: any): Observable<any> {
    debugger;
    return from(axios.post(`${this.apiUrl}/sales`, sale));
  }

  listSales(): Observable<any> {
    return from(axios.get(`${this.apiUrl}/sales`));
  }

  updateSale(sale: Sale): Observable<any> {
    return from(axios.put(`${this.apiUrl}/sales`, sale));
  }

  cancelSale(): Observable<any> {
    return from(axios.delete(`${this.apiUrl}/sales`));
  }
}
