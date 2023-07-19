import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { StockItemFormComponent } from './stock-item-form/stock-item-form.component';
import { StockItemTableComponent } from './stock-item-table/stock-item-table.component';
import { StockItemService } from './stock-item.service';

@NgModule({
  declarations: [AppComponent, StockItemFormComponent, StockItemTableComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [StockItemService],
  bootstrap: [AppComponent],
})
export class AppModule {}
