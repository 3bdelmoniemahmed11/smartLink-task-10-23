import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../services/employee.service';
import { Subscription } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css'],
})
export class AddEmployeeComponent implements OnInit {
  constructor(
    private employeeService: EmployeeService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}
  subscription: Subscription = new Subscription();
  selectedGroup: string = '';
  fields: { [key: string]: any[] } = {
    HR: [
      {
        id: 'email',
        type: 'text',
        label: 'Username',
        placeholder: 'Enter Username',
      },
      {
        id: 'password',
        type: 'password',
        label: 'Password',
        placeholder: 'Enter Password',
      },
    ],
    Normal: [],
  };

  addEmployeeForm = new FormGroup({
    name: new FormControl('', Validators.required),
    group: new FormControl('', Validators.required),
    email: new FormControl('', [this.selectedGroupValidator()]),
    password: new FormControl('', [this.selectedGroupValidator()]),
  });

  onSubmit() {
    if (this.addEmployeeForm.valid) {
      let employeeServiceSubscription = this.employeeService
        .addEmployee(this.addEmployeeForm.value)
        .subscribe({
          next: (response: any) => {
            console.log(response);
            this.toastr.success("Employeee Added", "Success");
            this.addEmployeeForm.reset();
          },
          error: (error) => {
            console.log(error);
              this.toastr.error("can't save Employee !", "Error");
          },
        });
      this.subscription.add(employeeServiceSubscription);
    }
  }
  selectedGroupValidator() {
    return (control: any) => {
      const selectedGroup = this.addEmployeeForm?.get('group')?.value;
      if (selectedGroup === 'HR') {
        return Validators.required(control);
      }
      return null;
    };
  }
}
