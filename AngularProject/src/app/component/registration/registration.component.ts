import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TheTrip } from 'src/app/Classes/TheTrip';
import { User } from 'src/app/Classes/User';
import { UserSerService } from 'src/app/service/user-ser.service';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent {
  newCustomer:User=new User()
  currectUser:User=new User()
  newUser:User=new User()
  users:Array<User>=new Array<User>()
  ListTrip:Array<TheTrip>=new Array<TheTrip>()
constructor(public customerS:UserSerService,public Routing:Router){
  this.user = {
  email: 'dini@email.com',
  phone: '0527197044'
};
}
 
  public user: any;
    saveUser(){
    debugger
    this.newCustomer.idUser=0
  this.newCustomer.firstAidCertificate=false
    this.customerS.AddUser(this.newCustomer).subscribe
  (
    succ=>{
      debugger
      if(succ==null)
       {
           console.log(succ);   
       }
      else
    {
      //עדכון הלקוח הנוכחי בסרוויס 
      this.customerS.GetUserByMailAndPassword(this.newCustomer.email!,this.newCustomer.passwordIn!).subscribe(
        succ=>{
          this.customerS.currectUser1=succ
        }
      )
 //שליחה לדף כל הטיולים 
         this.Routing.navigate([`./AllTrip`]);
    }  
    },
    err=>{
      
      //אם יש שגיאה נרענן את לדף ההרשמה
  
    }
  )
}
myForm:FormGroup =new FormGroup({});
ngOnInit(): void {
  this.myForm = new FormGroup({
    'firstName': new FormControl(null,[this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
    'lastName':new FormControl(null, [this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
    'email': new FormControl(null,[this.isValidEmail.bind(this), Validators.required]),
    'phone':new FormControl(null, [Validators.required, Validators.minLength(9), Validators.maxLength(10)]),
    'password':new FormControl(null, [this.isValidPassword.bind(this), Validators.required, Validators.minLength(6)])
  })
}
get myPass() { return this.myForm.controls['password'] }
  get myFN() { return this.myForm.controls['firstName'] }
  get myLN() { return this.myForm.controls['lastName'] }
  get myPhone() { return this.myForm.controls['phone'] }
  get myMail() { return this.myForm.controls['email'] }

//תקינות לשם
isValidHebrewName(name: AbstractControl) {
  if (!/^[א-ת\s]+$/.test(name.value)) {
    return { 'notvalid': true };
  }
  return null;
}

//תקינות מייל
isValidEmail(email: AbstractControl) {
  if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email.value)) {
    return { 'notvalid': true };
  }
  return null;
}

//תקינות סיסמה
isValidPassword(password: AbstractControl) {
  if (!/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$/.test(password.value)) {
    return { 'notvalid': true };
  }
  return null;
}
 }

