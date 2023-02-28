import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car.model';
import { Color } from 'src/app/models/color.model';
import { Model } from 'src/app/models/model.model';
import { CarsService } from 'src/app/services/cars.service';
import { ColorsService } from 'src/app/services/colors.service';
import { ModelsService } from 'src/app/services/models.service';

@Component({
  selector: 'app-cars-list',
  templateUrl: './cars-list.component.html',
  styleUrls: ['./cars-list.component.css']
})
export class CarsListComponent implements OnInit {
  models: Model[] = [];
  colors: Color[] = [];
  cars: Car[] = [];

  constructor(private carsService: CarsService, private modelsService: ModelsService, private colorsService: ColorsService) {}

  ngOnInit() : void {
    this.carsService.getAllCars()
    .subscribe({
      next: (cars) => {
        this.cars = cars;
      },
      error: (response) => {
        console.log(response);
      }
    });
    this.colorsService.getAllColors()
    .subscribe({
      next: (colors) => {
        this.colors = colors;
      },
      error: (response) => {
        console.log(response);
      }
    })
    this.modelsService.getAllModels()
    .subscribe({
      next: (models) => {
        this.models = models;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
}
