import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegistrationComponent } from './component/registration/registration.component';
import { LoginComponent } from './component/login/login.component';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './component/home-page/home-page.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { IgxInputGroupModule, IgxTextSelectionModule,IgxIconModule,IgxMaskModule,IgxSelectModule, IgxCardModule} from "igniteui-angular";
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import { TripsComponent } from './component/trips/trips.component';
import { DetailsTripComponent } from './component/details-trip/details-trip.component';
import { MYUserComponent } from './component/myuser/myuser.component';
import { MYUserToTripComponent } from './component/myuser-to-trip/myuser-to-trip.component';
import { DialogService } from 'primeng/dynamicdialog';
import { MenuModule } from 'primeng/menu';
import { MessageService } from 'primeng/api';
import { OrderComponent } from './component/order/order.component';
import { AllUsersComponent } from './component/all-users/all-users.component';
import {MatTableModule} from '@angular/material/table';
import{MatSelectModule}from '@angular/material/select';
import { UserToChangeComponent } from './component/user-to-change/user-to-change.component';
@NgModule({
  declarations: [
    AppComponent,
    TripsComponent,
    RegistrationComponent,
    LoginComponent,
    HomePageComponent,
    DetailsTripComponent,
    MYUserComponent,
    MYUserToTripComponent,
    OrderComponent,
    AllUsersComponent,
    UserToChangeComponent,
    
  ],
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NoopAnimationsModule,
    IgxInputGroupModule,
    IgxTextSelectionModule,
    IgxIconModule,
    IgxMaskModule,
    IgxSelectModule,
    MatCardModule,
    MatButtonModule,
    MatTableModule,
    MatSelectModule,
    MenuModule,
	  IgxCardModule
	
  ],
  providers: [DialogService,MessageService ],
  bootstrap: [AppComponent]
})
export class AppModule {
}


