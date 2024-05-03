import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  Backend:string="http://localhost:5095/api/Car"
  constructor(private http:HttpClient) { }
  //search car
  searchCar(carDetails:any):Observable<any>{
    return this.http.post(`${this.Backend}/search`,carDetails);
  }
  //check car already booked
  checkBooking(carAgreementDetails:any):Observable<any>{
    return this.http.post(`${this.Backend}/alreadyBooked`,carAgreementDetails);
  }
  //get car by id
  getCarById(id:any):Observable<any>{
    return this.http.get(`${this.Backend}/carById/${id}`);
  }
  //book car
  bookCar(carAgreementDetails:any):Observable<any>{
    return this.http.post(`${this.Backend}/bookCar`,carAgreementDetails);
  }
  //get agreements based on user id
  getAgreement(id:any):Observable<any>{
    return this.http.get(`${this.Backend}/getAgreements/${id}`);
  }
  //request for return 
  requestForReturn(id:any):Observable<any>{
    return this.http.put(`${this.Backend}/requestForReturn/${id}`,null);
  }
  //get all agreements
  getAllAgreements():Observable<any>{
    return this.http.get(`${this.Backend}/getAllAgreements`);
  }
  //approve return for request
  approve(id:any):Observable<any>{
    return this.http.delete(`${this.Backend}/approveReturn/${id}`);
  }
  //add car 
  addCar(carDetails:any):Observable<any>{
    return this.http.post(`${this.Backend}/addCar`,carDetails);
  }
  //edit car
  updateCar(id:any,carDetails:any):Observable<any>{
    return this.http.put(`${this.Backend}/updateCar/${id}`,carDetails);
  }
  //delete car
  deleteACar(id:any):Observable<any>{
    return this.http.delete(`${this.Backend}/deleteCar/${id}`);
  }
  //get all cars
  getAllCars():Observable<any>{
    return this.http.get(`${this.Backend}/getAllCar`);
  }
}
