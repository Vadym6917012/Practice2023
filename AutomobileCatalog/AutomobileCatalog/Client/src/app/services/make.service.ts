import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Make } from '../models/make.model';

@Injectable({
  providedIn: 'root'
})
export class MakesService {

  baseUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  // Get all cards
  getAllMakes(): Observable<Make[]> {
    return this.http.get<Make[]>(this.baseUrl + '/api/make');
  }

  addMake(make: Make): Observable<Make> {
    make.id = 0;
    return this.http.post<Make>(this.baseUrl + '/api/make', make);
  }

  deleteMake(id: number): Observable<Make> {
    return this.http.delete<Make>(this.baseUrl + '/api/make/' + id);
  }

  updateMake(id: number, updateMakeRequest: Make): Observable<Make> {
    return this.http.put<Make>(this.baseUrl + '/api/make/' + id, updateMakeRequest)
  }

  getMake(id: number): Observable<Make> {
    return this.http.get<Make>(this.baseUrl + '/api/make/' + id);
  }
}