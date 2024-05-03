import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-edit-car',
  templateUrl: './edit-car.component.html',
  styleUrls: ['./edit-car.component.css']
})
export class EditCarComponent implements OnInit {
  id:any
  updateCarForm:FormGroup
  constructor(private router:ActivatedRoute,private carService:CarService,private formBuilder:FormBuilder,private route:Router){
    this.router.params.subscribe((params)=>
      this.id=params['id']
    )
     this.updateCarForm=this.formBuilder.group({
      maker:['',Validators.required],
      model:['',Validators.required],
      rentalPrice:['',Validators.required]
    });  
  }
  ngOnInit(): void {
    this.carService.getCarById(this.id).subscribe((res)=>{
      this.updateCarForm.setValue({
        maker:res.maker,
        model:res.model,
        rentalPrice:res.rentalPrice
      })
    },(error)=>{
      console.log(error);
    })
  }
  onUpdate(){
    this.carService.updateCar(this.id,this.updateCarForm.value).subscribe((res)=>{
      console.log(res);
      alert("Editted Successfully...");
      this.route.navigate(['dashboard']);
    },(error)=>{
      console.log(error);
    })
  }
}
