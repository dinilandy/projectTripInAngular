import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TheTrip } from '../Classes/TheTrip';
import { TypesTripe } from '../Classes/TypesTrip';

@Injectable({
  providedIn: 'root'
})
export class TripsSerService {
  currectTrip:TypesTripe=new TypesTripe()
  currentUser:TheTrip=new TheTrip()
  constructor(public http:HttpClient) { }

  getAll():Observable<Array<TheTrip>>
  {
    return this.http.get<Array<TheTrip>>("https://localhost:7012/api/TheTripe")
  }
  getByIdTrips(id: number):Observable<TheTrip>{
    debugger
    return this.http.get<TheTrip>(`https://localhost:7012/api/TheTripe/GetTripById/${id}`)
}
getAllTripsUser(id:number): Observable<Array<TheTrip>> {
  return this.http.get<Array<TheTrip>>(`https://localhost:7012/api/User/GetAllTripsAsync/${id}`)
}
}
