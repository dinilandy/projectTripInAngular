import { Component} from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { User } from 'src/app/Classes/User';
import { Router } from '@angular/router';
import { UserSerService } from 'src/app/service/user-ser.service';
       
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  //משתנה
  currectUser:User=new User()
  constructor(public LoginSer :UserSerService ,public routing:Router){}

  checkUser()
  {
    debugger
    //הכנסת ערכים למשתמש הנוכחי
    const email=this.currectUser.email
    const password=this.currectUser.passwordIn

    window.localStorage.clear()
    //הקצאת משתמש חדש שהוא יהיה המנהל
  const m=new User(
    52,"מנהל","דיני","0527197044","dini0527197044@gmail.com","123dtitb",true
  )
  debugger
  //localStorage שליפת המנהל מה
  let man:string=window.localStorage.getItem("manager")!;
   //בשביל הפעם הראשונה שישים ערך מנהל 
   if(man==null)
   window.localStorage.setItem("manager",JSON.stringify(m))
      
  //בדיקה אם מדובר במנהל 
  if(email==m.email&&password==m.passwordIn)
   { this.LoginSer.currectUser1=m;
     this.LoginSer.isManager=true;
     this.routing.navigate([`./AllTrip`])
  }
  else
  //קריאת שרת למשתמש על ידי אמייל וסיסמא
  this.LoginSer.GetUserByMailAndPassword(email!,password!).subscribe(
    Succ=>{if(Succ.firstName!=null){
      this.LoginSer.currectUser1=Succ;
      console.log(this.LoginSer.currectUser1);
      this.routing.navigate([`./AllTrip`])
    }
    else
    {
      alert("!!לקוח זה אינו מזוהה, הרשם עכשיו")
      this.routing.navigate([`/Registration`])
    }
    },
    Err=>{
      debugger
      alert("!!לקוח זה אינו מזוהה, הרשם עכשיו")
      console.log(Err)
      this.routing.navigate([`/Registration`])
    }
  );
}
//בדיקת תקינות
email = new FormControl('', [Validators.required, Validators.email]);
password= new FormControl('',[Validators.required,Validators.min(2)]);
getErrorMessage() {
  if (this.email.hasError('required')) {
    return 'You must enter a value';
  }
  return this.email.hasError('email') ? 'Not a valid email' : '';
}
}