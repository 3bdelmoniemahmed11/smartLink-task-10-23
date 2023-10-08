import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { loginRequest } from '../models/loginRequest';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AthunticationService {
  
  constructor(private http: HttpClient) { }
  apiUrl: string = environment.apiUrl;
  
  login(loginRequest: loginRequest) { 
    return this.http.post(`${this.apiUrl}/Auth`, loginRequest);
  }

}
