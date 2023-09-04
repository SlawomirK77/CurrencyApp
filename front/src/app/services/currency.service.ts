import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { CurrencyTable } from '../shared/interfaces';

@Injectable({
  providedIn: 'root',
})
export class CurrencyService {
  constructor(private http: HttpClient) {}

  private apiUrl = `${environment.apiUrl}`;

  getCurrencyTables(): Observable<CurrencyTable[]> {
    return this.http.get<CurrencyTable[]>(`${this.apiUrl}/CurrencyTables`);
  }
}
