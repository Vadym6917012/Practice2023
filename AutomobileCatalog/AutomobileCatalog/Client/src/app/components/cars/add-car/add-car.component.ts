import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from 'src/app/models/car.model';
import { Model } from 'src/app/models/model.model';
import { CarsService } from 'src/app/services/cars.service';
import { ColorsService } from 'src/app/services/colors.service';
import { MakesService } from 'src/app/services/make.service';
import { ModelsService } from 'src/app/services/models.service';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent {
  models: Model[] = [];
  addCarRequest: Car = {
    id: 0,
    vehicleModelId: 0,
    vehicleModel: null,
    engineCapacity: 0.0,
    priceId: 0,
    price: null,
    description: " "
  }

  constructor(private carService: CarsService,private modelService: ModelsService, private makeService: MakesService, private colorService: ColorsService, private router: Router) {}

  ngOnInit(): void {
    this.modelService.getAllModels()
    .subscribe({
      next: (models) =>{
        this.models = models;
      },
      error: (response) => {
        console.log(response)
      }
    })
  }

  addCar() { 
    this.carService.addCar(this.addCarRequest)
    .subscribe({
      next: (color) => {
        this.router.navigate(['/cars']);
      } 
    })
  }
}
