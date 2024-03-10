import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Classes/User';
import { Observable } from 'rxjs';
import { TheTrip } from '../Classes/TheTrip';

@Injectable({
  providedIn: 'root'
})
export class UserSerService {

  currectUser1:User=new User()
   currentUser:User=new User()
  //האם מדובר במנהל
isManager:boolean=false;

  // manager:User=new User();
  constructor(public http:HttpClient) { }
  GetAllUser():Observable<Array<User>>
  {
    return this.http.get<Array<User>>("https://localhost:7012/api/User/GetAllAsync")    
  }

  GetUserByMailAndPassword(email:string , password:string):Observable<User>
  {
    return this.http.get<User>(`https://localhost:7012/api/User/GetUserByMailAndPasswordAsync/${email}/${password}`)
  }
  AddUser(U:User)
  {
    return this.http.post<User>(`https://localhost:7012/api/User/AddUserAsync/User`,U) 
  }
  change(U:User)
  {
    return this.http.put<boolean>(`https://localhost:7012/api/User/UpdateAsync/User`,U) 
  }
  getTripsByUser(Id:number):Observable<Array<TheTrip>>
  {
    return this.http.get<Array<TheTrip>>(`https://localhost:7012/api/User/GetAllTripsAsync/user?userId=${Id}`)
  }
  deleteUser(Id:number):Observable<boolean>
   {
    return this.http.delete<boolean>(`https://localhost:7012/api/User/DeleteAsync/${Id}`)
    
   }
}
