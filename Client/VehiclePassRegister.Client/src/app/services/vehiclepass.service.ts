import { getVehicle } from './../models/response/getVehicle.models';
import { CreateVehicle } from './../models/request/createVehicle';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { updateVehicle } from '../models/request/updateVehicle';

@Injectable({
  providedIn: 'root',
})
export class VehiclepassService {
  private vehicleUrl: string = 'http://localhost:5125/api/vehiclepass/';

  constructor(private http: HttpClient) {}

  getAllVehicle(): Observable<getVehicle[]> {
    return this.http
      .get<getVehicle[]>(this.vehicleUrl)
      .pipe(catchError(this.errorHandler));
  }

  postVehicle(createVehicle: CreateVehicle): Observable<CreateVehicle> {
    return this.http.post<CreateVehicle>(this.vehicleUrl, createVehicle);
  }

  getbyId(id: number): Observable<getVehicle> {
    return this.http
      .get<getVehicle>(this.vehicleUrl + id)
      .pipe(catchError(this.errorHandler));
  }

  updateVehicle(
    id: number,
    updateVehicle: updateVehicle
  ): Observable<updateVehicle> {
    return this.http.put<updateVehicle>(this.vehicleUrl + id, updateVehicle);
  }
  errorHandler(err: HttpErrorResponse) {
    return throwError(err);
  }
}
