import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  Backend:string="http://localhost:5095/api/User"

  constructor(private http:HttpClient) {
  
   }

  //login
  login(userDetails:any):Observable<any>{
    return this.http.post(`${this.Backend}/login`,userDetails);
  }
  //get user by id
  getUser(id:any):Observable<any>{
    console.log(id);
    return this.http.get(`${this.Backend}/getUser/${id}`);
  }
  //store token
  storeToken(tokenValue:any){
   
    localStorage.setItem('token',tokenValue);
  }
  getToken(){
    const token=localStorage.getItem('token');
    return token;
  }
  decodedToken(){
    const jwtHelper=new JwtHelperService();
    const token=this.getToken() ?? '';
    return jwtHelper.decodeToken(token);
  }
  isLoggedIn(){
    return !!localStorage.getItem('token');
  }
  getRoleFromToken(){
    const usertoken=this.decodedToken();
    if(usertoken){
      return usertoken.role;
    }
  }
  getIdFromToken(){
    const usertoken=this.decodedToken();
    if(usertoken){
      return usertoken.UserId;
    }
  }
  getUserNameFromToken(){
    const usertoken=this.decodedToken();
    if(usertoken){
      return usertoken.unique_name||usertoken.name;
    }
  }
}
