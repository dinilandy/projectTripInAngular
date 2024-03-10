import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderPlace } from '../Classes/OrderPlace';

@Injectable({
  providedIn: 'root'
})
export class OrderSerService {
orderSer:OrderPlace=new OrderPlace()
  constructor(public http:HttpClient) { }
  getAll(id:number):Observable <Array<OrderPlace>>
  {
    debugger
    return this.http.get<Array<OrderPlace>>(`https://localhost:7012/api/OrderPlace/GetAllToTrip/${id}`)
  }
  getAllBookings(): Observable<Array<OrderPlace>> 
  {
    debugger
    return this.http.get<Array<OrderPlace>>(`https://localhost:7012/api/OrderPlace`)
  }
  addOrder(order:OrderPlace):Observable<number>
  {
    debugger
    return this.http.post<number>(`https://localhost:7012/api/OrderPlace/AddOrderPlace`,order)
  }
  deleteOrder(id:number):Observable<boolean>
  {
    debugger
    return this.http.delete<boolean>(`https://localhost:7012/api/OrderPlace/DeleteOrderPlace/${id}`)
  }
}
