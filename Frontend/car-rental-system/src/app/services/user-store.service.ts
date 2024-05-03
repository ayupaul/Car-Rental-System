import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
  dataSubject:BehaviorSubject<any>=new BehaviorSubject<any>(null);
  constructor() { }
  getData(){
    return this.dataSubject.asObservable();
  }
  setData(value:any){
    this.dataSubject.next(value);
  }
}
