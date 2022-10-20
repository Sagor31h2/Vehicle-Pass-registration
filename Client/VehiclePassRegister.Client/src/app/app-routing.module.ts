import { CreatevehicleComponent } from './components/createvehicle/createvehicle.component';
import { VhiclePassHomeComponent } from './components/vhicle-pass-home/vhicle-pass-home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/getall', pathMatch: 'full' },
  { path: 'getall', component: VhiclePassHomeComponent },
  { path: 'create', component: CreatevehicleComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
export const routingComponents = [VhiclePassHomeComponent];
