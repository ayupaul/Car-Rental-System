import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/services/user-service.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  userPayload:any
  regularUserRole:any
  constructor(private userService:UserServiceService,private route:Router,private userStoreService:UserStoreService){
    this.userStoreService.getData().subscribe((res)=>
    this.userPayload=res||this.userService.decodedToken());
    // this.regularUserRole=this.userService.getRoleFromToken();
    this.userStoreService.getData().subscribe((res)=>this.regularUserRole=res||this.userService.getRoleFromToken());
  }
  onLogout(){
    localStorage.clear();
    this.userPayload=undefined;
    this.regularUserRole=undefined;
    this.route.navigateByUrl("");
  }
}
