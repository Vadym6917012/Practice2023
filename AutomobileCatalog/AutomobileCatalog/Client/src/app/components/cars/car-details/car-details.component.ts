import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/models/car.model';
import { Color } from 'src/app/models/color.model';
import { Make } from 'src/app/models/make.model';
import { CarsService } from 'src/app/services/cars.service';
import { ColorsService } from 'src/app/services/colors.service';
import { MakesService } from 'src/app/services/make.service';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {

carDetails: Car = {
  id: 0,
  vehicleModelId: 0,
  vehicleModel: null,
  imageUrl: null,
  engineCapacity: 0,
  priceId: 0,
  price: null,
  description: ""
}

constructor(private carsService: CarsService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.carsService.getCar(+id)
            .subscribe({
              next: (response) => {
                this.carDetails = response;
              }
            });
        }
      }
    });
   }

   deleteCar(id: number) {
    this.carsService.deleteCar(id)
    .subscribe({
      next: (response) => {
        this.router.navigate(['/cars']);
      }
    });
  }
}
