import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserServiceService } from '../services/user-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private userService:UserServiceService,private route:Router){}
  canActivate(): Observable<boolean> | Promise<boolean> | boolean {
    if (this.userService.getRoleFromToken()=='Admin') {
      return true;
    } else {
      this.route.navigateByUrl("dashboard");
      return false;
    }
  }
  
}
