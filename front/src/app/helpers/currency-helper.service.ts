import { Injectable } from '@angular/core';
import { CurrencyService } from '../services/currency.service';
import { CurrencyTable } from '../shared/interfaces';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CurrencyHelper {
  constructor(private currencyService: CurrencyService) {}

  getCurrencyTables(): Observable<CurrencyTable[]> {
    return this.currencyService.getCurrencyTables();
  }
}
