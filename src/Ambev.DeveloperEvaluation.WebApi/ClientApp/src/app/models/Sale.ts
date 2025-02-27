import { SaleItem } from './SaleItem';
export interface Sale {
  id: string; 
  date: string; 
  customer: string;
  totalAmount: number;
  branch: string;
  isCancelled: boolean;
  items: SaleItem[];
}


