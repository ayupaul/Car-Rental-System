import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from 'src/app/services/car.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-rental-agreement',
  templateUrl: './rental-agreement.component.html',
  styleUrls: ['./rental-agreement.component.css']
})
export class RentalAgreementComponent implements OnInit {
  carId:any;
  startDate:any;
  endDate:any;
  userName:any
  rentalDuration:any
  totalCost:any
  carDetails:any
  currentDate:any
  constructor(private router:ActivatedRoute,private userService:UserServiceService,private carService:CarService,private route:Router){
    this.userName=this.userService.getUserNameFromToken();
    console.log(this.userName);
    this.router.params.subscribe(params=>{
      console.log(params);
      this.carId=params['carId'];
      this.startDate=params['startDate'];
      this.endDate=params['endDate'];
      const startDateToDateTime=new Date(this.startDate);
      const endDateToDateTime=new Date(this.endDate);
      const timeDifference=endDateToDateTime.getTime()-startDateToDateTime.getTime();
      this.rentalDuration=Math.ceil(timeDifference/(1000*24*3600));
      const datePipe = new DatePipe('en-US');
    this.currentDate=datePipe.transform(new Date(),'yyyy-MM-dd');
    console.log(this.startDate)
    console.log(this.endDate)
  })
}
  ngOnInit(): void {
    this.carService.getCarById(this.carId).subscribe((res)=>{
     this.carDetails=res;
     const numericPrice=parseFloat(this.carDetails.rentalPrice.replace('$',''));
     this.totalCost=numericPrice*this.rentalDuration;
    },
    (error)=>{
      console.log(error);
    })
    
  }
  onBook(){
    const checkBooking={startDate:"",endDate:"",carId:0};
    checkBooking.startDate=this.startDate;
    checkBooking.endDate=this.endDate;
    checkBooking.carId=this.carId;
    const sd=new Date(this.startDate);
    const ed=new Date(this.endDate);
    if(sd>=ed){
      alert("return date could not be equal to or greater than pickup date");
    }
    else{
    this.carService.checkBooking(checkBooking).subscribe((res)=>{
      if(res===true){
        alert("Car already booked for the selected date");
      }
      else{
        const userId=this.userService.getIdFromToken();
        const carAgreementDetails={carId:this.carId,userId:userId,totalCost:this.totalCost,startDate:this.startDate,endDate:this.endDate};
        this.carService.bookCar(carAgreementDetails).subscribe((res)=>{
          alert("Car Booked Successfully");
          this.route.navigateByUrl("my-rental-agreement");
        },(error)=>{
          console.log(error);
        })
      }
    },(error)=>{
      console.log(error);
    })
  }
  }
  updateTotalCost() {
    if (this.carDetails && this.endDate && this.startDate) {
      const startDateToDateTime = new Date(this.startDate);
      const endDateToDateTime = new Date(this.endDate);
      const timeDifference = endDateToDateTime.getTime() - startDateToDateTime.getTime();
      this.rentalDuration = Math.ceil(timeDifference / (1000 * 24 * 3600));
      const numericPrice = parseFloat(this.carDetails.rentalPrice.replace('$', ''));
      this.totalCost = numericPrice * this.rentalDuration;
    }
  }
}
 
  
