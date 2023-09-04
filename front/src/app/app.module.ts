import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CurrencyTableComponent } from './components/currency-table/currency-table.component';
import { TableWrapperComponent } from './components/table-wrapper/table-wrapper.component';

@NgModule({
  declarations: [AppComponent, CurrencyTableComponent, TableWrapperComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
