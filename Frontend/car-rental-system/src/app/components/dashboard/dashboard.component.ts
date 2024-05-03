import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CarService } from 'src/app/services/car.service';
import { UserServiceService } from 'src/app/services/user-service.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  none=null
  carDetails:any
  startDate:any
  endDate:any
  getRole:any
  allCars:any
  carDetailswithDate:any
  currentDate:any
  selectedMaker: any = null;
  selectedModel: any = null;
  selectedPrice: any=null;
  newAddedCar:any
  makers: any; 
  models: any; 
  prices:any;
  

  constructor(
    private userService: UserServiceService,
    private userStoreService: UserStoreService,
    private carService:CarService,
    private route:Router,
  
  ) {
    this.makers=new Set();
    this.models=new Set();
    this.prices=new Set();
    this.carService.getAllCars().subscribe((res)=>{
      this.allCars=res;
      console.log(this.allCars);
    this.allCars.forEach((car:any) => {
      this.makers.add(car.maker);
      this.models.add(car.model);
      this.prices.add(car.rentalPrice);
    });
    },(error)=>{
      console.log(error);
    })
   
    

    
  }
  ngOnInit(): void {
    const userPayload = this.userService.decodedToken();
    this.userStoreService.setData(userPayload);
    this.getRole=this.userService.getRoleFromToken();
    this.userStoreService.setData(this.getRole);
    const datePipe = new DatePipe('en-US');
    this.currentDate=datePipe.transform(new Date(),'yyyy-MM-dd');
    
    
    
  }
 onBook(carId:any,startDate:any,endDate:any){
  const startDates=new Date(startDate);
  const endDates=new Date(endDate);
  const carAgreementDetails={startDate:"",endDate:"",carId:0}
  carAgreementDetails.startDate=startDate;
  carAgreementDetails.endDate=endDate;
  carAgreementDetails.carId=carId;
  this.carService.checkBooking(carAgreementDetails).subscribe((res)=>{
    if(res===true){
      alert("Car is already booked in the selected date");
    }
    else{
      this.route.navigate(["rental-agreement",carId,startDate,endDate]);
    }
  },(error)=>{
    console.log(error);
  })
  
 }
 filterData() {

  const filteredData={maker:null,model:null,rentalPrice:null};
  filteredData.maker=this.selectedMaker;
  filteredData.model=this.selectedModel;
  filteredData.rentalPrice=this.selectedPrice;
  this.carService.searchCar(filteredData).subscribe((res)=>{
   console.log(res);
   this.carDetails=res;
   this.carDetailswithDate=this.carDetails.map((car:any)=>({
     ...car,startDate:this.startDate,endDate:this.endDate
   }))
  },(error)=>{
   console.log(error);
  })
 }
 editCar(id:any){
  this.route.navigate(['edit-car',id]);
 }
 deleteACar(id:any){
  this.carService.deleteACar(id).subscribe((res)=>{
    console.log(res);
    alert("Deleted Successfully...")
    window.location.reload();
  },(error)=>{
    console.log(error);
  })
 }
}
