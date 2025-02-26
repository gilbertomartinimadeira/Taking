import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sale } from '../models/Sale';

@Injectable({
  providedIn: 'root',
})
export class SaleService {
  private apiUrl = 'your-api-endpoint';
  constructor(private http: HttpClient) { }

  createSale(sale: Sale): Observable<Sale> {
    return this.http.post<Sale>(`${this.apiUrl}/sales`, sale);
  }
}
