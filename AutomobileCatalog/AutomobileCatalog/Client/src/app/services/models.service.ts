import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Model } from '../models/model.model';

@Injectable({
  providedIn: 'root'
})
export class ModelsService {

  baseUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  // Get all cards
  getAllModels(): Observable<Model[]> {
    return this.http.get<Model[]>(this.baseUrl + '/api/model');
  }

  addModel(Model: Model): Observable<Model> {
    Model.id = 0;
    return this.http.post<Model>(this.baseUrl + '/api/model', Model);
  }

  deleteModel(id: number): Observable<Model> {
    return this.http.delete<Model>(this.baseUrl + '/api/model/' + id);
  }

  updateModel(id: number, updateModelRequest: Model): Observable<Model> {
    return this.http.put<Model>(this.baseUrl + '/api/model/' + id, updateModelRequest)
  }

  getModel(id: number): Observable<Model> {
    return this.http.get<Model>(this.baseUrl + '/api/model/' + id);
  }
}