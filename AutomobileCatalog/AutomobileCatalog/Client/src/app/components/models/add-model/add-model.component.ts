import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Color } from 'src/app/models/color.model';
import { Make } from 'src/app/models/make.model';
import { Model } from 'src/app/models/model.model';
import { ColorsService } from 'src/app/services/colors.service';
import { MakesService } from 'src/app/services/make.service';
import { ModelsService } from 'src/app/services/models.service';

@Component({
  selector: 'app-add-model',
  templateUrl: './add-model.component.html',
  styleUrls: ['./add-model.component.css']
})
export class AddModelComponent implements OnInit {
  makes: Make[] = [];
  colors: Color[] = [];
  addModelRequest: Model = {
    id: 0,
    name: " ",
    makeId: 0,
    make: null,
    vehicleColorId: 0,
    vehicleColor: null
  }

  constructor(private modelService: ModelsService, private makeService: MakesService, private colorService: ColorsService, private router: Router) {}

  ngOnInit() : void {
    this.makeService.getAllMakes()
    .subscribe({
      next: (makes) => {
        this.makes = makes;
      },
      error: (response) => {
        console.log(response);
      }
    });
    this.colorService.getAllColors()
    .subscribe({
      next: (colors) => {
        this.colors = colors;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }
  
  addModel() { 
    this.modelService.addModel(this.addModelRequest)
    .subscribe({
      next: (model) => {
        this.router.navigate(['/models']);
      } 
    })
  }
}
