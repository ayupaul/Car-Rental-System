import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin, map } from 'rxjs';
import { CarService } from 'src/app/services/car.service';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-all-agreements',
  templateUrl: './all-agreements.component.html',
  styleUrls: ['./all-agreements.component.css']
})
export class AllAgreementsComponent implements OnInit {
  allAgreements:any
  constructor(private carService:CarService,private userService:UserServiceService){}
  ngOnInit(): void {
    this.carService.getAllAgreements().subscribe((res)=>{
      this.allAgreements=res;  
     
    },(error)=>{
      console.log(error);
    })
  }
  approve(id:any){
    this.carService.approve(id).subscribe((res)=>{
      console.log(res);
      window.location.reload();
    },(error)=>{
      console.log(error);
    })
  }
  delete(id:any){
    this.carService.approve(id).subscribe((res)=>{
      console.log(res);
      window.location.reload();
    },(error)=>{
      console.log(error);
    })
  }
}
