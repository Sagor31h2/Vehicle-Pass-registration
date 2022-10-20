import { updateVehicle } from './../../models/request/updateVehicle';
import { ActivatedRoute, Router } from '@angular/router';
import { VehiclepassService } from './../../services/vehiclepass.service';
import { getVehicle } from './../../models/response/getVehicle.models';
import { Component, OnInit } from '@angular/core';
import { __param } from 'tslib';

@Component({
  selector: 'app-edit-vehicle',
  templateUrl: './edit-vehicle.component.html',
  styleUrls: ['./edit-vehicle.component.css'],
})
export class EditVehicleComponent implements OnInit {
  constructor(
    private vehicleService: VehiclepassService,
    private router: ActivatedRoute,
    private navigate: Router
  ) {}

  vehicle: getVehicle = {
    id: 0,
    vechicleNo: '',
    driverName: '',
    driverPhoneNo: 0,
    passingTime: 0,
  };

  update: updateVehicle = {
    driverName: '',
    driverPhoneNO: 0,
  };

  getData() {
    console.log('get by id called');
    this.router.paramMap.subscribe({
      next: (param) => {
        const id = param.get('id');

        if (id) {
          this.vehicleService.getbyId(Number(id)).subscribe({
            next: (response) => {
              this.vehicle = response;
            },
          });
        }
      },
    });
  }

  submit() {
    this.update.driverName = this.vehicle.driverName;
    this.update.driverPhoneNO = this.vehicle.driverPhoneNo;
    this.vehicleService.updateVehicle(this.vehicle.id, this.update).subscribe({
      next: () => {
        this.navigate.navigate(['/getall']);
      },
    });
  }

  ngOnInit(): void {
    this.getData();
  }
}
