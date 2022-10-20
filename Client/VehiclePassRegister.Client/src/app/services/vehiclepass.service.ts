import { CreateVehicle } from './../models/request/createVehicle';
import { getVehicle } from '../models/response/getVehicle.models';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class VehiclepassService {
  private vehicleUrl: string = 'http://localhost:5125/api/vehiclepass/';

  constructor(private http: HttpClient) {}

  getAllVehicle(): Observable<getVehicle[]> {
    return this.http.get<getVehicle[]>(this.vehicleUrl);
  }

  postVehicle(createVehicle: CreateVehicle): Observable<CreateVehicle> {
    return this.http.post<CreateVehicle>(this.vehicleUrl, createVehicle);
  }
}
