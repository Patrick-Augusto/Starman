import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-stock-item-form',
  templateUrl: './stock-item-form.component.html',
  styleUrls: ['./stock-item-form.component.css']
})
export class StockItemFormComponent {
  @Output() stockItemAdded = new EventEmitter<any>();
  name: string;
  quantity: number;
  unitPrice: number;

  addStockItem() {
    if (this.name && this.quantity && this.unitPrice) {
      const stockItem = {
        name: this.name,
        quantity: this.quantity,
        unitPrice: this.unitPrice,
      };
      this.stockItemAdded.emit(stockItem);
      this.name = '';
      this.quantity = null;
      this.unitPrice = null;
    }
  }
}
