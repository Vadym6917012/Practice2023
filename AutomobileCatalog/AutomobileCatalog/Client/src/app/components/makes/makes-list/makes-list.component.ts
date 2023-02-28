import { Component, OnInit } from '@angular/core';
import { Make } from 'src/app/models/make.model';
import { MakesService } from 'src/app/services/make.service';

@Component({
  selector: 'app-makes-list',
  templateUrl: './makes-list.component.html',
  styleUrls: ['./makes-list.component.css']
})
export class MakesListComponent implements OnInit {
  makes: Make[] = [];
  constructor(private makesService: MakesService) {}

  ngOnInit() : void {
    this.makesService.getAllMakes()
    .subscribe({
      next: (makes) => {
        this.makes = makes;
      },
      error: (response) => {
        console.log(response);
      }
    })
  }
}
