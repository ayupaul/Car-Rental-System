import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ActionGuard } from './guards/action.guard';
import { RentalAgreementComponent } from './components/rental-agreement/rental-agreement.component';
import { MyRentalAgreementsComponent } from './components/my-rental-agreements/my-rental-agreements.component';
import { AllAgreementsComponent } from './components/all-agreements/all-agreements.component';
import { AuthGuard } from './guards/auth.guard';
import { AddCarComponent } from './components/add-car/add-car.component';
import { EditCarComponent } from './components/edit-car/edit-car.component';

const routes: Routes = [
  {path:"",component:HomeComponent},
  {path:"login",component:LoginComponent},
  {path:"dashboard",component:DashboardComponent,canActivate:[ActionGuard]},
  {path:"rental-agreement/:carId/:startDate/:endDate",component:RentalAgreementComponent,canActivate:[ActionGuard]},
  {path:"my-rental-agreement",component:MyRentalAgreementsComponent,canActivate:[ActionGuard]},
  {path:"all-agreements",component:AllAgreementsComponent,canActivate:[AuthGuard]},
  {path:"add-car",component:AddCarComponent,canActivate:[AuthGuard]},
  {path:"edit-car/:id",component:EditCarComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
