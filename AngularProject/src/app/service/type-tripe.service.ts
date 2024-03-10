import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TypesTripe } from '../Classes/TypesTrip';
import { TheTrip } from '../Classes/TheTrip';

@Injectable({
  providedIn: 'root'
})
export class TypeTripeService {
  
 currectTrip:TypesTripe=new TypesTripe()

  constructor(public http:HttpClient) { }

  getAll():Observable<Array<TypesTripe>>
  {
    return this.http.get<Array<TypesTripe>>("https://localhost:7012/api/TypesTrip")
  }

  getByid(id:number):Observable<Array<TheTrip>>
  {
    debugger
    return this.http.get<Array<TheTrip>>(`https://localhost:7012/api/TypesTrip/GetById/${id}`)

  }
}
