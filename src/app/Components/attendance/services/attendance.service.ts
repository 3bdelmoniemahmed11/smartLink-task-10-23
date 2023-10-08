import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { createAttendance } from '../models/createAttendance';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AttendanceService {
  apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) {}
  addEmployeeAttendance(attendance: createAttendance) { 
    return this.http.post(`${this.apiUrl}/Attendance`, attendance);
  }
  
}
