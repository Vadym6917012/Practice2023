import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Color } from 'src/app/models/color.model';
import { ColorsService } from 'src/app/services/colors.service';

@Component({
  selector: 'app-edit-color',
  templateUrl: './edit-color.component.html',
  styleUrls: ['./edit-color.component.css']
})
export class EditColorComponent implements OnInit {
  colorDetails: Color = {
    id: 0,
    name: " ",
  };

  constructor(private route: ActivatedRoute, private colorService: ColorsService, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.colorService.getColor(+id)
            .subscribe({
              next: (response) => {
                this.colorDetails = response;
              }
            });
        }
      }
    })
  }

  updateColor() {
    this.colorService.updateColor(this.colorDetails.id, this.colorDetails)
      .subscribe({
        next: (colors) => {
          this.router.navigate(['/colors']);
        }
      });
  }
  deleteColor(id: number) {
    this.colorService.deleteColor(id)
    .subscribe({
      next: (response) => {
        this.router.navigate(['/colors']);
      }
    });
  }
}
