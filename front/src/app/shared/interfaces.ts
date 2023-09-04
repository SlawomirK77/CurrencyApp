export interface CurrencyTable {
  table: string;
  no: string;
  tradingDate: Date | null;
  effectiveDate: Date;
  rates: Rate[];
}

export interface Rate {
  currency: string;
  code: string;
  bid: number;
  ask: number;
  mid: number;
}
