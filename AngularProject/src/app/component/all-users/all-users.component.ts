import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Classes/User';
import { UserSerService } from 'src/app/service/user-ser.service';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent implements OnInit{
  //משתנה
 users:Array<User>=new Array<User>()
  constructor(public user:UserSerService){}
  ngOnInit(): void {
    //קריאת שרת של כל המשתמשים
    this.user.GetAllUser().subscribe(
      Data => { this.users = Data; },
      Err => console.log(Err)
    )
  }
}
