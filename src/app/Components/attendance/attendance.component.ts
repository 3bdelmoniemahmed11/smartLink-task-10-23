import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { getEmployee } from './models/getEmployee';
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AttendanceService } from './services/attendance.service';
import { EmployeeService } from '../Employee/services/employee.service';
@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css'],
})
export class AttendanceComponent implements OnInit, OnDestroy {
  constructor(
    private attendanceService: AttendanceService,
    private employeeService: EmployeeService,
    private toastr: ToastrService
  ) {}
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
  
  subscription: Subscription = new Subscription();
  employees: getEmployee[] = [];
  addEmployeeAttendanceForm = new FormGroup({
    employeeId: new FormControl('', Validators.required),
    attendanceDate: new FormControl('', Validators.required),
  });
  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees() {
    let getEmployeeServiceSubscription = this.employeeService
      .getEmployees()
      .subscribe({
        next: (response: any) => {
          this.employees = response;
        },
        error: (error) => {
          this.toastr.error("can't load Employees Names !", 'Error');
        },
      });
    this.subscription.add(getEmployeeServiceSubscription);
  }

  onSubmit() {
    if (this.addEmployeeAttendanceForm.valid) {
      debugger;
      let employeeServiceSubscription = this.attendanceService
        .addEmployeeAttendance(this.addEmployeeAttendanceForm.value)
        .subscribe({
          next: () => {
            this.toastr.success('Attendance  Added', 'Success');
            this.addEmployeeAttendanceForm.reset();
          },
          error: () => {
            this.toastr.error("can't save Employee Attendance !", 'Error');
          },
        });
      this.subscription.add(employeeServiceSubscription);
    }
  }
}
