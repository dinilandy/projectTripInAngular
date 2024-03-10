import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderPlace } from 'src/app/Classes/OrderPlace';
import { TheTrip } from 'src/app/Classes/TheTrip';
import { TypesTripe } from 'src/app/Classes/TypesTrip';
import { User } from 'src/app/Classes/User';
import { OrderSerService } from 'src/app/service/order-ser.service';
import { TripsSerService } from 'src/app/service/trips-ser.service';
import { TypeTripeService } from 'src/app/service/type-tripe.service';
import { UserSerService } from 'src/app/service/user-ser.service';

@Component({
  selector: 'app-myuser-to-trip',
  templateUrl: './myuser-to-trip.component.html',
  styleUrls: ['./myuser-to-trip.component.css']
})
export class MYUserToTripComponent {
  idUser?:number = 0
  idOrder?:number=0
  constructor(public ser:TripsSerService,public u:UserSerService ,public ar:ActivatedRoute,public r:Router,public type:TypeTripeService,public order:OrderSerService){
 this.idUser= this.u.currectUser1.idUser;
 this.idOrder=this.order.orderSer.idOrder;
}
//משתנים
selectedType:number=0
  openMyTrip:boolean=false;
  ListU: Array<TheTrip> = new Array<TheTrip>()
  ListTReplace: Array<TheTrip> = new Array<TheTrip>()
  ListTrip: Array<TheTrip> = new Array<TheTrip>()
  ListTripReplace: Array<TheTrip> = new Array<TheTrip>()
  newUser:User=new User()
  orderPs:Array<OrderPlace>=new Array<OrderPlace>()
  orderP:OrderPlace=new OrderPlace()
  users:Array<User>=new Array<User>()
  list: Array<TypesTripe> = new Array<TypesTripe>();
  filterTrips:Array<TheTrip>=new Array<TheTrip>()
  myTrips:Array<TheTrip>=new Array<TheTrip>()
   price:number=400

  ngOnInit(): void {
    debugger
    //קריאת שרת של טיול למשתמש
    this.u.getTripsByUser(this.u.currectUser1.idUser!).subscribe(

      succ => { this.ListU = succ;
        this.filterTrips=succ;
        console.log(this.ListU) },
      data => { this.ListU = data 
      })
      //קריאת שרת של כל ההזמנות
      this.order.getAll(this.order.orderSer.idOrder!).subscribe(

         succ => { this.orderPs= succ;},
        data => { this.orderPs = data }
      )
           //קריאת שרת של שליפת כל סוגי הטיולים 
    this.type.getAll().subscribe(
      succ=>
      
           {this.list=succ
            console.log(succ);
           }
      ,err=>{console.log(err);
     })
     //קריאת שרת של שליפה של כל הטיולים רק בתנאי שלא עבר תאריך הטיול
    this.ser.getAll().subscribe(
      Data => { this.ListTReplace = Data.filter(x=> new Date(x.date!)>new Date);
        this.ListU=Data.filter(x=> new Date(x.date!)>new Date); },
      Err => console.log(Err)
    )
    }
    //פונקצית סינון לפי תאריך ומחיר
    filterByDate(selectedIndex:Number|undefined)
    {
      debugger
     console.log(selectedIndex);
     if(selectedIndex==0)
  // מסננת את הטיולים שכבר התרחשו
     this.filterTrips = this.ListU.filter(trip => new Date(trip.date!).getTime() < Date.now());
     else if(selectedIndex==1)
     //טיולים שעוד יהיו 
     this.filterTrips = this.ListU.filter(trip => new Date(trip.date!).getTime() >= Date.now());
  else
  //מחיר
       this.filterTrips = this.ListU.filter(x => x.price!<=this.price);

    }
    //מחיקת הזמנה
 deleteOrder(id:number|undefined){
  debugger
  //קריאת שרת של כל ההזמנות
   this.order.getAllBookings().subscribe(
    succ=>{
      //סינון
      this.orderPs = succ.filter(book => book.idTrip== id && book.idUser == this.u.currectUser1.idUser &&new Date(book.date!).getTime() >= Date.now());
    //קריאת שרת של מחיקת הזמנה
  this.order.deleteOrder(this.orderPs[0].idOrder!).subscribe
  (
    succ=>{
      debugger
       if(succ==true){
       alert(" ההזמנה בוטלה")
        this.r.navigate([`./AllTrip`]);
        this.ngOnInit()
       }
       else{
       alert("נכשל נסה שוב")
        
       }
    },
    err=>{
      debugger
    alert("נכשל נסה שוב")
    }
  );
},
err=>{
  debugger
alert("נכשל נסה שוב")
}
);
}
}