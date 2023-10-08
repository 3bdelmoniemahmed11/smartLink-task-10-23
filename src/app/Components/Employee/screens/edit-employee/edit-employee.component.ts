import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { EmployeeService } from '../../services/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { getEmployee } from 'src/app/Components/attendance/models/getEmployee';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css'],
})
export class EditEmployeeComponent implements OnInit {
  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) {}
  subscription: Subscription = new Subscription();
  selectedGroup: string = '';
  employeeId: string = '';
  employeeData: getEmployee | null = null;
  editEmployeeForm = new FormGroup({
    id: new FormControl('', Validators.required),
    name: new FormControl('', Validators.required),
  });
  ngOnInit(): void {
    this.route.params.subscribe((params: any) => {
      this.employeeId = params['id'];
    });
    this.getEmployeeById();

    this.editEmployeeForm.patchValue({
      name: this.employeeData?.name,
    });
  }
  selectedGroupValidator() {
    return (control: any) => {
      const selectedGroup = this.editEmployeeForm?.get('group')?.value;
      if (selectedGroup === 'HR') {
        return Validators.required(control);
      }
      return null;
    };
  }
  patchEditEmployeeFormValues() {
    this.editEmployeeForm.patchValue({
      name: this.employeeData?.name,
      id: this.employeeData?.id,
    });
  }
  getEmployeeById() {
    let getEmployeeServiceSubscription = this.employeeService
      .getEmployeesById(this.employeeId)
      .subscribe({
        next: (response: any) => {
          this.employeeData = response;
          this.patchEditEmployeeFormValues();
        },
        error: (error) => {
          this.toastr.error("can't load Employee Data !", 'Error');
        },
      });
    this.subscription.add(getEmployeeServiceSubscription);
  }

  updateEmployee() {
    let updateEmployeeServiceSubscription = this.employeeService
      .updateEmployee(this.editEmployeeForm.value)
      .subscribe({
        next: (response: any) => {
          this.employeeData = response;
          this.toastr.success('updated Successfully', 'Success');
          this.router.navigate(['/app/home']);
        },
        error: (error) => {
          this.toastr.error("can't load Employee Data !", 'Error');
        },
      });
    this.subscription.add(updateEmployeeServiceSubscription);
  }
}
