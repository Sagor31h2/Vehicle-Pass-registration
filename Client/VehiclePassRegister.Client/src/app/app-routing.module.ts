import { EditVehicleComponent } from './components/edit-vehicle/edit-vehicle.component';
import { updateVehicle } from './models/request/updateVehicle';
import { CreatevehicleComponent } from './components/createvehicle/createvehicle.component';
import { VhiclePassHomeComponent } from './components/vhicle-pass-home/vhicle-pass-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/getall', pathMatch: 'full' },
  { path: 'getall', component: VhiclePassHomeComponent },
  { path: 'create', component: CreatevehicleComponent },
  { path: 'updatevehicle/:id', component: EditVehicleComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
export const routingComponents = [VhiclePassHomeComponent];
