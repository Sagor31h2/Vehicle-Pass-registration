import { VehiclepassService } from './services/vehiclepass.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VhiclePassHomeComponent } from './components/vhicle-pass-home/vhicle-pass-home.component';
import { HttpClientModule } from '@angular/common/http';
import { CreatevehicleComponent } from './components/createvehicle/createvehicle.component';
import { FormsModule } from '@angular/forms';
import { EditVehicleComponent } from './components/edit-vehicle/edit-vehicle.component';

@NgModule({
  declarations: [AppComponent, VhiclePassHomeComponent, CreatevehicleComponent, EditVehicleComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [VehiclepassService],
  bootstrap: [AppComponent],
})
export class AppModule {}
