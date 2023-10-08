import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalstorageService } from '../localStorageService/localstorage.service';
@Injectable({
  providedIn: 'root',
})
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private localStorageService:LocalstorageService) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let authToken = this.localStorageService.getAuthToken();
   const authRequest = request.clone({
     setHeaders: {
       Authorization: `Bearer ${authToken}`,
     },
   });
   return next.handle(authRequest);
  }
}
