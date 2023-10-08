import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LocalstorageService {
  constructor() {}
  setAuthToken(token: string): void {
    localStorage.setItem('token', token);
  }
  getAuthToken(): string | null{
   return  localStorage.getItem('token');
  }
}
