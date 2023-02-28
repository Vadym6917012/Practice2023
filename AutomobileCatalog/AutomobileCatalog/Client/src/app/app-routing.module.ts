import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCarComponent } from './components/cars/add-car/add-car.component';
import { CarsListComponent } from './components/cars/cars-list/cars-list.component';
import { EditCarComponent } from './components/cars/edit-car/edit-car.component';
import { AddColorComponent } from './components/colors/add-color/add-color.component';
import { ColorsListComponent } from './components/colors/colors-list/colors-list.component';
import { EditColorComponent } from './components/colors/edit-color/edit-color.component';
import { AddMakeComponent } from './components/makes/add-make/add-make.component';
import { EditMakeComponent } from './components/makes/edit-make/edit-make.component';
import { MakesListComponent } from './components/makes/makes-list/makes-list.component';
import { AddModelComponent } from './components/models/add-model/add-model.component';
import { EditModelComponent } from './components/models/edit-model/edit-model.component';
import { ModelsListComponent } from './components/models/models-list/models-list.component';

const routes: Routes = [
  { path: 'colors', component: ColorsListComponent },
  { path: 'colors/add', component: AddColorComponent },
  { path: 'colors/edit/:id', component: EditColorComponent },
  { path: 'makes', component: MakesListComponent },
  { path: 'makes/add', component: AddMakeComponent },
  { path: 'makes/edit/:id', component: EditMakeComponent },
  { path: 'models', component: ModelsListComponent },
  { path: 'models/add', component: AddModelComponent },
  { path: 'models/edit/:id', component: EditModelComponent },
  { path: 'cars', component: CarsListComponent },
  { path: 'cars/add', component: AddCarComponent} ,
  { path: 'cars/edit/:id', component: EditCarComponent },
  { path: '', redirectTo: 'cars', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
