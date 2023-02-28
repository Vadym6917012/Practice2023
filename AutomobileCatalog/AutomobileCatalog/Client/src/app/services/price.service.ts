import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Price } from '../models/price.model';

@Injectable({
  providedIn: 'root'
})
export class PricesService {

  baseUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  // Get all Priceds
  getAllPrices(): Observable<Price[]> {
    return this.http.get<Price[]>(this.baseUrl + '/api/price');
  }

  addPrice(Price: Price): Observable<Price> {
    Price.id = 0;
    return this.http.post<Price>(this.baseUrl + '/api/price', Price);
  }

  deletePrice(id: number): Observable<Price> {
    return this.http.delete<Price>(this.baseUrl + '/api/price/' + id);
  }

  updatePrice(id: number, updatePriceRequest: Price): Observable<Price> {
    return this.http.put<Price>(this.baseUrl + '/api/price/' + id, updatePriceRequest)
  }

  getPrice(id: number): Observable<Price> {
    return this.http.get<Price>(this.baseUrl + '/api/price/' + id);
  }
}