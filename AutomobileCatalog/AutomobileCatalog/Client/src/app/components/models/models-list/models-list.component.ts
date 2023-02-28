import { Component, OnInit } from '@angular/core';
import { Model } from 'src/app/models/model.model';
import { ModelsService } from 'src/app/services/models.service';

@Component({
  selector: 'app-models-list',
  templateUrl: './models-list.component.html',
  styleUrls: ['./models-list.component.css']
})
export class ModelsListComponent implements OnInit {
  models: Model[] = [];
  constructor(private modelsService: ModelsService) {}

  ngOnInit() : void {
    this.modelsService.getAllModels()
    .subscribe({
      next: (models) => {
        this.models = models;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
