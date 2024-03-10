import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';
import { TheTrip } from 'src/app/Classes/TheTrip';
import { TypesTripe } from 'src/app/Classes/TypesTrip';
import { TripsSerService } from 'src/app/service/trips-ser.service';
import { TypeTripeService } from 'src/app/service/type-tripe.service';
import { UserSerService } from 'src/app/service/user-ser.service';
@Component({
  selector: 'app-trips',
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit{

constructor(public trip: TripsSerService, public kindTrip: TypeTripeService, public r: Router, public user: UserSerService) {
}
ngOnInit(): void {
  debugger
  //קריאת שרת של  כל הטיולים
  this.trip.getAll().subscribe(
    Data => {
      this.ListT = Data.filter(x=> new Date(x.date!)>new Date);
      this.ListTReplace = Data.filter(x=> new Date(x.date!)>new Date);
       console.log(Data);
    },
    Err => console.log(Err)
  )
  //קריאת שרת של כל הסוגי טיולים
  this.kindTrip.getAll().subscribe(
    Data => { this.list = Data; },
    Err => console.log(Err)
  )
//קריאת שרת של כל הטיולים למשתמש
  this.user.getTripsByUser(Number(this.user.currentUser.idUser)).subscribe(
    Data => { this.ListTrip = Data; this.ListTripReplace = Data },
    Err => console.log(Err)
  )

}

//בודק מי נמצא ברשימת הטיולים של המשתמש הנוכחי
find(trip: TheTrip): number {
  for (let i = 0; i < this.ListTrip.length; i++) {
    if (this.ListTrip[i].idTrip == trip.idTrip)
      return 0;
  }
  return 1;
}

//משתני מחלקה
showDiv: boolean = false;
ListT: Array<TheTrip> = new Array<TheTrip>()
ListTReplace: Array<TheTrip> = new Array<TheTrip>()
ListTrip: Array<TheTrip> = new Array<TheTrip>()
ListTripReplace: Array<TheTrip> = new Array<TheTrip>()
//רשימת סוגי הטיולים מיובאת מהמסד
list: Array<TypesTripe> = new Array<TypesTripe>();
//סינון לפי סוג טיול
onOptionSelected(event: Event) {
  const selectedOption = (event.target as HTMLSelectElement).value;
  let numericValue = Number(selectedOption);
  if (numericValue == 0) {
    this.ListT = this.ListTReplace
    this.ListTrip = this.ListTripReplace
  }
  else {
    this.ListT = this.ListTReplace.filter(x => x.idType == numericValue)
    this.ListTrip = this.ListTripReplace.filter(x => x.idType == numericValue)
  }
}
//ניתוב לטיול ספציפי
GetDetails(id: number | undefined) {
  this.r.navigate([`DetailsTripId/${id}`])
}
}



