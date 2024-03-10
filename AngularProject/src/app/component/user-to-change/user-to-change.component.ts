import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TheTrip } from 'src/app/Classes/TheTrip';
import { User } from 'src/app/Classes/User';
import { UserSerService } from 'src/app/service/user-ser.service';

@Component({
  selector: 'app-user-to-change',
  templateUrl: './user-to-change.component.html',
  styleUrls: ['./user-to-change.component.css']
})
export class UserToChangeComponent implements OnInit{
  currectUser:User=new User()
  newUser:User=new User()
  users:Array<User>=new Array<User>()
  ListTrip:Array<TheTrip>=new Array<TheTrip>()
constructor(public Registr :UserSerService ,public routing:Router){
 
this.user = {
  email: 'dini@email.com',
  phone: '0527197044'
};
}
 
  public user: any;
  myForm:FormGroup =new FormGroup({});
  ngOnInit(): void {
    this.myForm = new FormGroup({
      'firstName': new FormControl(null,[this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
      'lastName':new FormControl(null, [this.isValidHebrewName.bind(this), Validators.required, Validators.minLength(2)]),
      'email': new FormControl(null,[this.isValidEmail.bind(this), Validators.required]),
      'phone':new FormControl(null, [Validators.required, Validators.minLength(9), Validators.maxLength(10)]),
      'password':new FormControl(null, [this.isValidPassword.bind(this), Validators.required, Validators.minLength(6)]),
      'firstAidCertificate':new FormControl(false)
      
    })
    this.newUser=this.Registr.currectUser1
   
  
    
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
    //פונקצית שינוי משתמש 
    change() {  
      debugger
 this.currectUser.firstAidCertificate=this.Registr.currectUser1.firstAidCertificate
 this.currectUser.idUser=this.Registr.currectUser1.idUser
     this.Registr.change(this.Registr.currectUser1).subscribe(
     succ => { 
       debugger       
         this.routing.navigate(['/AllTrip']);
     },
     err => {
       alert("אופס נסה שנית")
       console.log(err);
     });
       
   }
   //פונקצית מחיקת משתמש
   deleteUser(){
     debugger
     //קריאת שרת של כול הטיולים של משתמש
     this.Registr.getTripsByUser(Number(this.Registr.currectUser1.idUser)).subscribe(
       Data => { this.ListTrip = Data; if (this.ListTrip.length == 0) {

         debugger
         //ומחיקתו מהמסד
         this.Registr.deleteUser(this.newUser.idUser!).subscribe
           (
             succ=>{
               debugger
                 alert("הלקוח הוסר")
                window.location.reload()
             },
           )
         }
       else
       {
         alert("אא למחוק כי יש לו טיולים")
       }
      },
       Err => console.log(Err)
     )
   
     this.currectUser.idUser=this.Registr.currectUser1.idUser
     this.Registr.getTripsByUser(Number(this.user.currentUser.idUser)).subscribe(
       Data => { this.ListTrip = Data;  },
       Err => console.log(Err)
     );
   this.Registr.getTripsByUser( this.Registr.currectUser1.idUser!).subscribe(
     succ => {
       this.ListTrip = succ.filter(trip => new Date(trip.date!) > new Date());
       
     },
     error => {
       console.error('שגיאה במחיקת משתמש:', error);
       // כאן תוכל להטיל הודעת שגיאה או לבצע פעולות נוספות במקרה של כישלון
     }
   );
   
   }
 }
