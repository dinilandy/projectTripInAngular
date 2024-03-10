import { Component } from '@angular/core';
import { User } from './Classes/User';
import { UserSerService } from './service/user-ser.service';
import { OrderPlace } from './Classes/OrderPlace';
import { OrderSerService } from './service/order-ser.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user:User=new User()
  order:OrderPlace=new OrderPlace()
  
  constructor(public UserS:UserSerService,public Orderser:OrderSerService) {
    this.user=UserS.currectUser1
    this.order=Orderser.orderSer
  }
  
  ngOnInit(): void {
    debugger
    this.user=this.UserS.currectUser1
    this.order=this.Orderser.orderSer

  }
  title = 'my_Angular';
}
