import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-stock-item-table',
  templateUrl: './stock-item-table.component.html',
})
export class StockItemTableComponent {
  @Input() stockItems: any[];
  @Output() stockItemRemoved = new EventEmitter<number>();

  removeStockItem(id: number) {
    this.stockItemRemoved.emit(id);
  }
}
