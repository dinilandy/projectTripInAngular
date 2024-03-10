import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { TheTrip } from 'src/app/Classes/TheTrip';
import { TripsSerService } from 'src/app/service/trips-ser.service';
import { OrderComponent } from '../order/order.component';
import { OrderPlace } from 'src/app/Classes/OrderPlace';
import { UserSerService } from 'src/app/service/user-ser.service';
import { OrderSerService } from 'src/app/service/order-ser.service';

@Component({
  selector: 'app-details-trip',
  templateUrl: './details-trip.component.html',
  styleUrls: ['./details-trip.component.css']
})
export class DetailsTripComponent {
 
constructor(public so:OrderSerService ,public su:UserSerService ,public ar:ActivatedRoute,public serTripe:TripsSerService,public dialogService: DialogService){}
//משתנים
trips :TheTrip=new TheTrip()
 idTrip:number = 0
 bookingConfirmed: boolean = false;
 trip:TheTrip=new TheTrip();
 id:Number=0;
 open:boolean=false;
 openSuccesOrder:boolean=false;
 openErrorOrder:boolean=false;
 numOfPlaces:number=0;
 openErrorPlaces:boolean=false;

   ngOnInit(): void {
    debugger
     this.ar.params.subscribe(t=>this.idTrip = t['id'])
     const tripId= this.idTrip
     //קריאת שרת של טיולים בטיול קוד
     this.serTripe.getByIdTrips(tripId).subscribe(
      succ => { this.trip = succ; console.log(this.trips) },
      data => { this.trip = data })
     }
     //פונקציה לפתיחת שדה להכנסת כמות כרטיסים 
openOrder(){
  debugger
  this.open=true
 }
 //פונקציה של הזמנת הכרטיסים
 order(){
  debugger
   //אם כמות מקומות פנוים גדולה מהכמות שרוצה להזמין 
  if(this.trip.numberPlacesAvailable!>this.numOfPlaces)
 {
   debugger
   
      //הגדרת הזמנה חדשה
   const newOrder: OrderPlace=new OrderPlace(
                 0,
                 this.su.currectUser1.idUser,
                 new Date(),
                 undefined,
                 this.trip.idTrip,
                 this.numOfPlaces,
                 "",
                 "",
                 new Date()     
                 )
 console.log(newOrder);
     //שליחה לקריאת שרת להוספת הזמנה   
  this.so.addOrder(newOrder).subscribe(
   succes=>{ 
     alert(`הזמנת ${this.numOfPlaces}`)
     //פתיחת ההודעה שההזמנה נקלטה
   this.openSuccesOrder=true
   this.open=false;
   },
  err=>{
   console.log(err);
    this.openErrorOrder=true
 }
  )
 }
 //אם אין מספיק מקומות להזמין לטיול 
 else{
  this.openErrorPlaces=true
 }
 }
 }
    