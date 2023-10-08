import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './Components/home/screens/homeManagment/home.component';
import { AddEmployeeComponent } from './Components/Employee/screens/add-employee/add-employee.component';
import { AttendanceComponent } from './Components/attendance/attendance.component';
import { EditEmployeeComponent } from './Components/Employee/screens/edit-employee/edit-employee.component';
import { LoginComponent } from './Components/loginManagment/Screens/Login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'app',
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'addEmployee', component: AddEmployeeComponent },
      { path: 'attendance', component: AttendanceComponent },
      { path: 'editEmployee/:id', component: EditEmployeeComponent },
    ],
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
