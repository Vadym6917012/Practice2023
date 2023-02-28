import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Make } from 'src/app/models/make.model';
import { MakesService } from 'src/app/services/make.service';

@Component({
  selector: 'app-edit-make',
  templateUrl: './edit-make.component.html',
  styleUrls: ['./edit-make.component.css']
})
export class EditMakeComponent implements OnInit {
  makeDetails: Make = {
    id: 0,
    name: " ",
  };

  constructor(private route: ActivatedRoute, private makeService: MakesService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.makeService.getMake(+id)
            .subscribe({
              next: (response) => {
                this.makeDetails = response;
              }
            });
        }
      }
    })
  }

  updateMake() {
    this.makeService.updateMake(this.makeDetails.id, this.makeDetails)
      .subscribe({
        next: (colors) => {
          this.router.navigate(['/makes']);
        }
      });
  }
  deleteMake(id: number) {
    this.makeService.deleteMake(id)
    .subscribe({
      next: (response) => {
        this.router.navigate(['/makes']);
      }
    });
  }
}
