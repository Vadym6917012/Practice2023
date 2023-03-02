import { HttpClient, HttpEventType, HttpRequest } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from 'src/app/models/car.model';
import { Make } from 'src/app/models/make.model';
import { Model } from 'src/app/models/model.model';
import { CarsService } from 'src/app/services/cars.service';
import { ColorsService } from 'src/app/services/colors.service';
import { MakesService } from 'src/app/services/make.service';
import { ModelsService } from 'src/app/services/models.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit {

  working = false;
  uploadFile!: File | null;
  uploadFileLabel: string | undefined = 'Choose an image to upload';
  uploadProgress!: number;
  uploadUrl!: string;

  handleFileInput(files: FileList) {
    if (files.length > 0) {
      this.uploadFile = files.item(0);
      this.uploadFileLabel = this.uploadFile?.name;
    }
  }

  upload() {
    if (!this.uploadFile) {
      alert('Choose a file to upload first');
      return;
    }

    const formData = new FormData();
    formData.append(this.uploadFile.name, this.uploadFile);

    const url = `${environment.baseApiUrl}/api/vehicle/uploadfile`;
    const uploadReq = new HttpRequest('POST', url, formData, {
      reportProgress: true,
    });

    this.uploadUrl = '';
    this.uploadProgress = 0;
    this.working = true;

    this.http.request(uploadReq).subscribe((event: any) => {
      if (event.type === HttpEventType.UploadProgress) {
        this.uploadProgress = Math.round((100 * event.loaded) / event.total);
      } else if (event.type === HttpEventType.Response) {
        this.uploadUrl = event.body.url;
      }
    }, (error: any) => {
      console.error(error);
    }).add(() => {
      this.working = false;
    });
  }

  models: Model[] = [];
  makes: Make[] = [];

  files: Array<any> = new Array<any>();

  addCarRequest: Car = {
    id: 0,
    vehicleModelId: 0,
    vehicleModel: null,
    imageUrl: "",
    engineCapacity: 0.0,
    priceId: 0,
    price: null,
    description: " "
  }

  constructor(private http: HttpClient, private carService: CarsService, private modelService: ModelsService, private makeService: MakesService, private colorService: ColorsService, private router: Router) { }

  ngOnInit(): void {
    this.modelService.getAllModels()
      .subscribe({
        next: (models) => {
          this.models = models;
        },
        error: (response) => {
          console.log(response)
        }
      });
      this.makeService.getAllMakes()
      .subscribe({
        next: (makes) => {
          this.makes = makes;
        },
        error: (response) => {
          console.log(response)
        }
      });
  }

  onSelectFile(event: any) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
      let img = event.target.files[0];
      if (img.length == 0)
        return;
      reader.readAsDataURL(img);
      this.files = img;

      reader.onload = (event: any) => {
        this.addCarRequest.imageUrl = event.target.result;
      }
    }
  }

  addCar() {
    this.carService.addCar(this.addCarRequest)
      .subscribe({
        next: (color) => {
          this.router.navigate(['/cars']);
        }
      });
  }
}
