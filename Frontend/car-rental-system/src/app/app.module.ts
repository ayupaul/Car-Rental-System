import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './components/navbar/navbar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RentalAgreementComponent } from './components/rental-agreement/rental-agreement.component';
import { MyRentalAgreementsComponent } from './components/my-rental-agreements/my-rental-agreements.component';
import { AllAgreementsComponent } from './components/all-agreements/all-agreements.component';
import { AddCarComponent } from './components/add-car/add-car.component';
import { EditCarComponent } from './components/edit-car/edit-car.component';
import { TokenInterceptor } from './interceptors/token.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
    DashboardComponent,
    RentalAgreementComponent,
    MyRentalAgreementsComponent,
    AllAgreementsComponent,
    AddCarComponent,
    EditCarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    FormsModule
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
  }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
