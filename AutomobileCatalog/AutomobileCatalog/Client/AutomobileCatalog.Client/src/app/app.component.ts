import { Component, OnInit } from '@angular/core';
import { Color } from './models/color.model';
import { ColorsService } from './service/colors.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'AutomobileCatalog';

  colors: Color[] = []; 
  color: Color = {
    id: 0,
    name: " ",
  }

  constructor(private colorsService: ColorsService) {

  }

  ngOnInit(): void {
    this.getAllColors();
  }

  getAllColors(){
    this.colorsService.getAllColors()
    .subscribe(
      response => {
        this.colors = response;
      }
    );
  }

  onSubmit() {
    this.colorsService.addColor(this.color)
    .subscribe(
      response => {
        this.getAllColors();
        this.color = {
          id: 0,
          name: " ",
        }
      }
    )
  }

  deleteColor(id: number) {
    this.colorsService.deleteColor(id)
    .subscribe(
      response => {
        this.getAllColors();
      }
    )
  }
}
