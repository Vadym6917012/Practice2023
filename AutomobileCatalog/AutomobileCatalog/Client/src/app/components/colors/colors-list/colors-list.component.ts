import { Component, OnInit } from '@angular/core';
import { Color } from 'src/app/models/color.model';
import { ColorsService } from 'src/app/services/colors.service';

@Component({
  selector: 'app-colors-list',
  templateUrl: './colors-list.component.html',
  styleUrls: ['./colors-list.component.css']
})
export class ColorsListComponent implements OnInit {

  colors: Color[] = [];
  constructor(private colorsService: ColorsService) {}

  ngOnInit() : void {
    this.colorsService.getAllColors()
    .subscribe({
      next: (colors) => {
        this.colors = colors;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}

