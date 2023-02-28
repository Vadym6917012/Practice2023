import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Make } from 'src/app/models/make.model';
import { MakesService } from 'src/app/services/make.service';

@Component({
  selector: 'app-add-make',
  templateUrl: './add-make.component.html',
  styleUrls: ['./add-make.component.css']
})
export class AddMakeComponent implements OnInit {
  addMakeRequest: Make = {
    id: 0,
    name: " ",
  }

  constructor(private makeService: MakesService, private router: Router) {}

  ngOnInit(): void {
  }

  addMake() { 
    this.makeService.addMake(this.addMakeRequest)
    .subscribe({
      next: (make) => {
        this.router.navigate(['/makes']);
      } 
    })
  }
}
