import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { EmployeeService } from 'src/app/Components/Employee/services/employee.service';
import { getEmployee } from 'src/app/Components/attendance/models/getEmployee';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, OnDestroy {
  constructor(
    private employeeService: EmployeeService,
    private toastr: ToastrService
  ) {}
  subscription: Subscription = new Subscription();
  employees: getEmployee[] = [];
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees() {
    let employeeServiceSubscription = this.employeeService
      .getEmployees()
      .subscribe({
        next: (response: any) => {
          this.employees = response;
          console.log(response);
        },
        error: (error) => {
          this.toastr.error("can't save Employee !", 'Error');
        },
      });
    this.subscription.add(employeeServiceSubscription);
  }
}
