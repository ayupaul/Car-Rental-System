import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm:FormGroup
  constructor(private formBuilder:FormBuilder,private userService:UserServiceService,private route:Router){
      this.loginForm=this.formBuilder.group({
        email:"",
        password:''
      });
  }
  onLogin(){
    console.log(this.loginForm.value);
    this.userService.login(this.loginForm.value).subscribe((res)=>{
      this.userService.storeToken(res.token);
      this.route.navigateByUrl("/dashboard");
      
    },
    (error)=>{
      alert("Login Fails");
      console.log(error);
    })
  }
}
