import { Time } from "@angular/common";

export class OrderPlace{
    constructor(public idOrder?:number,public idUser?:number,public orderDate?:Date, public orderTime?:Time ,public idTrip?:number,
        public numberPlaces?:number,public name?:string ,public targetTripe?:string ,public date ?:Date)
    {

    }
}
