import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './pages/header/header.component';
import { FooterComponent } from './pages/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { CarsListComponent } from './components/cars/cars-list/cars-list.component';
import { ColorsListComponent } from './components/colors/colors-list/colors-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddColorComponent } from './components/colors/add-color/add-color.component';
import { FormsModule } from '@angular/forms';
import { EditColorComponent } from './components/colors/edit-color/edit-color.component';
import { AddCarComponent } from './components/cars/add-car/add-car.component';
import { EditCarComponent } from './components/cars/edit-car/edit-car.component';
import { AddModelComponent } from './components/models/add-model/add-model.component';
import { EditModelComponent } from './components/models/edit-model/edit-model.component';
import { ModelsListComponent } from './components/models/models-list/models-list.component';
import { AddMakeComponent } from './components/makes/add-make/add-make.component';
import { EditMakeComponent } from './components/makes/edit-make/edit-make.component';
import { MakesListComponent } from './components/makes/makes-list/makes-list.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    CarsListComponent,
    ColorsListComponent,
    AddColorComponent,
    EditColorComponent,
    AddCarComponent,
    EditCarComponent,
    AddModelComponent,
    EditModelComponent,
    ModelsListComponent,
    AddMakeComponent,
    EditMakeComponent,
    MakesListComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
