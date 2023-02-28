import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Color } from 'src/app/models/color.model';
import { Make } from 'src/app/models/make.model';
import { Model } from 'src/app/models/model.model';
import { ColorsService } from 'src/app/services/colors.service';
import { MakesService } from 'src/app/services/make.service';
import { ModelsService } from 'src/app/services/models.service';

@Component({
  selector: 'app-edit-model',
  templateUrl: './edit-model.component.html',
  styleUrls: ['./edit-model.component.css']
})
export class EditModelComponent implements OnInit {
  makes: Make[] = [];
  colors: Color[] = [];
  modelDetails: Model = {
    id: 0,
    name: " ",
    makeId: 0,
    make: null,
    vehicleColorId: 0,
    vehicleColor: null
  };

  constructor(private route: ActivatedRoute, private modelService: ModelsService, private makeService: MakesService, private colorService: ColorsService ,private router: Router) { }

  ngOnInit(): void {
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
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.modelService.getModel(+id)
            .subscribe({
              next: (response) => {
                this.modelDetails = response;
              }
            });
        }
      }
    })
  }

  updateModel() {
    this.modelService.updateModel(this.modelDetails.id, this.modelDetails)
      .subscribe({
        next: (colors) => {
          this.router.navigate(['/models']);
        }
      });
  }

  deleteModel(id: number) {
    this.modelService.deleteModel(id)
    .subscribe({
      next: (response) => {
        this.router.navigate(['/models']);
      }
    });
  }
}
