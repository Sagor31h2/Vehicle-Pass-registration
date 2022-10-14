import { HttpClient } from '@angular/common/http';
import { VehiclepassService } from './../../services/vehiclepass.service';
import { getVehicle } from '../../models/response/getVehicle.models';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vhicle-pass-home',
  templateUrl: './vhicle-pass-home.component.html',
  styleUrls: ['./vhicle-pass-home.component.css'],
})
export class VhiclePassHomeComponent implements OnInit {
  vehicles: getVehicle[] = [];

  constructor(private _vehicleService: VehiclepassService) {}
  getAllVehicles(): void {
    this._vehicleService.getAllVehicle().subscribe((listOfVehicles) => {
      this.vehicles = listOfVehicles;
    });
  }
  ngOnInit(): void {
    this.getAllVehicles();
  }
}
