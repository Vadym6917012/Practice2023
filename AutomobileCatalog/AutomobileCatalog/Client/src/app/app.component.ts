import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Make } from './models/make.model';
import { MakesService } from './services/make.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Client';
  searchText = '';
  term = '';
  makes: Make[] = [];

  constructor(private http: HttpClient, private makeService: MakesService) {}

  ngOnInit(): void {
    this.makeService.getAllMakes()
    .subscribe((data: Make[]) => {
      this.makes = data;
    })
  }
}
