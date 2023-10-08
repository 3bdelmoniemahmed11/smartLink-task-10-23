import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptorService } from './Core/interceptors/auth-interceptor.service';
import { HomeComponent } from './Components/home/screens/homeManagment/home.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { AddEmployeeComponent } from './Components/Employee/screens/add-employee/add-employee.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AttendanceComponent } from './Components/attendance/attendance.component';
import { EditEmployeeComponent } from './Components/Employee/screens/edit-employee/edit-employee.component';
import { LoginComponent } from './Components/loginManagment/Screens/Login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavbarComponent,
    AddEmployeeComponent,
    AttendanceComponent,
    EditEmployeeComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
