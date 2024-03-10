import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent {
//משתנים
  numOfPlaces: number = 0;
  availablePlaces: number = 0;
  constructor( public ref: DynamicDialogRef,public config: DynamicDialogConfig) {
    this.availablePlaces = config.data.availablePlaces;
  }

    //פונקצית סגירת ההזמנה אם יש מספיק
  confirmBooking() {
    debugger
    if (this.numOfPlaces && this.numOfPlaces > 0) {
        alert('ההזמנה בוצעה בהצלחה');
        this.ref.close({ bookingConfirmed: true });
      }
      else {
        alert("חרגת לא נשארו עוד מקומות")
      }
    }
  }

