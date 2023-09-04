import { Component, OnInit } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { CurrencyHelper } from 'src/app/helpers/currency-helper.service';
import { CurrencyTable } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-table-wrapper',
  templateUrl: './table-wrapper.component.html',
  styleUrls: ['./table-wrapper.component.scss'],
})
export class TableWrapperComponent implements OnInit {
  constructor(private currencyHelper: CurrencyHelper) {}

  $currencyTables: Observable<CurrencyTable[]>;
  selectedTable: CurrencyTable;
  buttons: string[];

  ngOnInit(): void {
    this.$currencyTables = this.currencyHelper.getCurrencyTables();
    this.$currencyTables.subscribe(
      (tables) => (this.buttons = tables.map((x) => x.table))
    );
  }

  setTable(table: string) {
    this.$currencyTables.subscribe((tables) => {
      this.selectedTable = tables.find((x) => x.table == table)!;
    });
  }
}
