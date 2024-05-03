import { CurrencyPipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CarService } from 'src/app/services/car.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent {
  carForm:FormGroup
  constructor(private formBuilder:FormBuilder,private carService:CarService,private route:Router,private userStoreService:UserStoreService){
    this.carForm=this.formBuilder.group({
      maker:['',Validators.required],
      model:['',Validators.required],
      rentalPrice:['',Validators.required]
    })
  }
  onAdd(){
    const modifiedPrice=this.carForm.get('rentalPrice')?.value;
    
    const formattedPrice =  `${modifiedPrice}$`
    const formValue=this.carForm.value;
    formValue.rentalPrice=formattedPrice;
    
    this.carService.addCar(this.carForm.value).subscribe((res)=>{
      console.log(res);
      alert("Car Added Successfully...");
      
      this.route.navigateByUrl('dashboard');
    },(error)=>{
      console.log(error);
    })
  }
}
