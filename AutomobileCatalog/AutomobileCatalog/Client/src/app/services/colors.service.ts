import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Color } from '../models/color.model';

@Injectable({
  providedIn: 'root'
})
export class ColorsService {

  baseUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  // Get all cards
  getAllColors(): Observable<Color[]> {
    return this.http.get<Color[]>(this.baseUrl + '/api/vehiclecolor');
  }

  addColor(color: Color): Observable<Color> {
    color.id = 0;
    return this.http.post<Color>(this.baseUrl + '/api/vehiclecolor', color);
  }

  deleteColor(id: number): Observable<Color> {
    return this.http.delete<Color>(this.baseUrl + '/api/vehiclecolor/' + id);
  }

  updateColor(id: number, updateColorRequest: Color): Observable<Color> {
    return this.http.put<Color>(this.baseUrl + '/api/vehicleColor/' + id, updateColorRequest)
  }

  getColor(id: number): Observable<Color> {
    return this.http.get<Color>(this.baseUrl + '/api/vehiclecolor/' + id);
  }
}