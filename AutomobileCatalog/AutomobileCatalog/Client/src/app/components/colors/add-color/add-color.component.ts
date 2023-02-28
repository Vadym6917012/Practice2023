import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Color } from 'src/app/models/color.model';
import { ColorsService } from 'src/app/services/colors.service';

@Component({
  selector: 'app-add-color',
  templateUrl: './add-color.component.html',
  styleUrls: ['./add-color.component.css']
})
export class AddColorComponent implements OnInit {
  addColorRequest: Color = {
    id: 0,
    name: " ",
  }

  constructor(private colorService: ColorsService, private router: Router) {}

  ngOnInit(): void {
  }

  addColor() { 
    this.colorService.addColor(this.addColorRequest)
    .subscribe({
      next: (color) => {
        this.router.navigate(['/colors']);
      } 
    })
  }
}