import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Car } from '../models/car.model';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  baseUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  // Get all cards
  getAllCars(): Observable<Car[]> {
    return this.http.get<Car[]>(this.baseUrl + '/api/vehicle');
  }

  addCar(Car: Car): Observable<Car> {
    Car.id = 0;
    return this.http.post<Car>(this.baseUrl + '/api/vehicle', Car);
  }

  deleteCar(id: number): Observable<Car> {
    return this.http.delete<Car>(this.baseUrl + '/api/vehicle/' + id);
  }

  updateCar(id: number, updateCarRequest: Car): Observable<Car> {
    return this.http.put<Car>(this.baseUrl + '/api/vehicle/' + id, updateCarRequest)
  }

  getCar(id: number): Observable<Car> {
    return this.http.get<Car>(this.baseUrl + '/api/vehicle/' + id);
  }
}