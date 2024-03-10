import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TheTrip } from 'src/app/Classes/TheTrip';
import { TypesTripe } from 'src/app/Classes/TypesTrip';
import { User } from 'src/app/Classes/User';
import { TypeTripeService } from 'src/app/service/type-tripe.service';
import { UserSerService } from 'src/app/service/user-ser.service';

@Component({
  selector: 'app-myuser',
  templateUrl: './myuser.component.html',
  styleUrls: ['./myuser.component.css']
})
export class MYUserComponent {
  //משתנים
  user:User = new User()
  myTrips:Array< TheTrip>=new Array<TheTrip>()
  allTypes:Array< TypesTripe>=new Array<TypesTripe>()
  filterTrips:Array< TheTrip>=new Array<TheTrip>()
  selectedType:number=0;
  constructor(public ser:UserSerService, public r:Router,public typeSer:TypeTripeService){
    this.user = ser.currentUser
  }
  ngOnInit(): void {
    this.user = this.ser.currentUser
    }
  ChangeMe(){
    //שליחה לקומפננטה הרשמה אם ערכים ואפשרות לעדכון
    this.r.navigate(['/Myuser/ChangeME'])
  }
  AllTrip(){
    //שליחה לקומפננטה של הצגת טיולים
     this.r.navigate(['/Myuser/ShowTrip'])
  }
}
