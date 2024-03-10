import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './component/login/login.component';
import { RegistrationComponent } from './component/registration/registration.component';
import { HomePageComponent } from './component/home-page/home-page.component';
import { TripsComponent } from './component/trips/trips.component';
import { DetailsTripComponent } from './component/details-trip/details-trip.component';
import { MYUserComponent } from './component/myuser/myuser.component';
import { MYUserToTripComponent } from './component/myuser-to-trip/myuser-to-trip.component';
import { OrderComponent } from './component/order/order.component';
import { AllUsersComponent } from './component/all-users/all-users.component';
import { UserToChangeComponent } from './component/user-to-change/user-to-change.component';


  
const routes: Routes = [
  {path:'',component:HomePageComponent},
  {path:'HomePage',component:HomePageComponent},
  
  {path:'AllTrip',component:TripsComponent},
    {path:'DetailsTripId/:id',component:DetailsTripComponent,
    children: [
      { path: 'order/:num', component:OrderComponent }
    ]
  },
  // {path: 'ChangeME', component:UserToChangeComponent},

  {path:'Login',component:LoginComponent},
  {path:'Registration',component:RegistrationComponent},
  
   { path: 'Myuser', component:MYUserComponent ,
    children: [
  
  {path: 'ShowTrip', component:MYUserToTripComponent},
  {path: 'ChangeME', component:UserToChangeComponent},
]
  },
  {path:'AllUsers',component:AllUsersComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
