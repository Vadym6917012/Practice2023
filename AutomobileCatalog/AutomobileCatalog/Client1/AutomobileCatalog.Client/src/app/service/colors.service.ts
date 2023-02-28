import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Color } from '../models/color.model';

@Injectable({
  providedIn: 'root'
})
export class ColorsService {

  baseUrl = "https://localhost:7022/api/vehiclecolor";

  constructor(private http: HttpClient) { }

  // Get all cards
  getAllColors(): Observable<Color[]> {
    return this.http.get<Color[]>(this.baseUrl);
  }

  addColor(color: Color) {
    color.id = 0;
    return this.http.post(this.baseUrl, color);
  }

  deleteColor(id: number): Observable<Color> {
    return this.http.delete<Color>(this.baseUrl + '/' + id);
  }
}