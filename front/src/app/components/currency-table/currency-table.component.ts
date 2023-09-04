import { Component, Input } from '@angular/core';
import { CurrencyTable } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-currency-table',
  templateUrl: './currency-table.component.html',
  styleUrls: ['./currency-table.component.scss'],
})
export class CurrencyTableComponent {
  @Input()
  currencyTable: CurrencyTable;
}
