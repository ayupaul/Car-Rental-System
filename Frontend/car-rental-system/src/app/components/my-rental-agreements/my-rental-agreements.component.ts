import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-my-rental-agreements',
  templateUrl: './my-rental-agreements.component.html',
  styleUrls: ['./my-rental-agreements.component.css']
})
export class MyRentalAgreementsComponent implements OnInit {
  myAgreements:any
  userId:any
  agreementDetails:any
  constructor(private carService:CarService,private userService:UserServiceService){
    this.userId=this.userService.getIdFromToken();

    
  }
  ngOnInit(): void {
    this.carService.getAgreement(this.userId).subscribe((res)=>{
      console.log(res);
      this.agreementDetails=res;
    },(error)=>{
      console.log(error);
    })
  }
  requestForReturn(id:any){
    this.carService.requestForReturn(id).subscribe((res)=>{
      console.log(res);
      window.location.reload();
      
    },(error)=>{
      console.log(error);
    })
  }
}
