import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { createEmployeeDTO } from 'src/app/Components/Employee/models/createEmploye';
@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}
  addEmployee(employeeData: createEmployeeDTO) {
    return this.http.post(`${this.apiUrl}/Employee`, employeeData);
  }
  getEmployees() {
    return this.http.get(`${this.apiUrl}/Employee`);
  }
  getEmployeesById(employeeId: string) {
    {
      return this.http.get(`${this.apiUrl}/Employee/find`, {
        params: { employeeId: employeeId },
      });
    }
  }
  updateEmployee(employee: any) {
    return this.http.put(`${this.apiUrl}/Employee`, employee);
  }
}
