import { VehiclepassService } from './../../services/vehiclepass.service';
import { CreateVehicle } from './../../models/request/createVehicle';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-createvehicle',
  templateUrl: './createvehicle.component.html',
  styleUrls: ['./createvehicle.component.css'],
})
export class CreatevehicleComponent implements OnInit {
  constructor(private service: VehiclepassService) {}

  ngOnInit(): void {}
  createVehicle: CreateVehicle = {
    vechicleNo: '',
    driverPhoneNO: 0,
    driverName: '',
  };

  submit() {
    console.log('fuction called');
    this.service.postVehicle(this.createVehicle).subscribe({
      next: (value) => {
        console.log(value);
      },
    });
  }
}
