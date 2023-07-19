import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class StockItemService {
  private apiUrl = 'api/stockitems';

  constructor(private http: HttpClient) {}

  getStockItems() {
    return this.http.get<any[]>(this.apiUrl);
  }

  addStockItem(stockItem: any) {
    return this.http.post<any>(this.apiUrl, stockItem);
  }

  removeStockItem(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
