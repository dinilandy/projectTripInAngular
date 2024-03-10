import { Time } from "@angular/common";

export class TheTrip{
    constructor(public  idTrip ?:number,public targetTripe?:string ,public idType?:number ,public date?:Date ,public  leavingTime?:Time
         ,public durationTripInHours ?:number,public numberPlacesAvailable ?:number,public price?:number ,public  image?:string ,public nameType?:string ,public medic?:boolean)
    {

    }
}



 
 