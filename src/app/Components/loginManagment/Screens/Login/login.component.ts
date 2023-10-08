import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { AthunticationService } from '../../Services/athuntication.service';
import { LocalstorageService } from 'src/app/Core/localStorageService/localstorage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit, OnDestroy {
  subscription: Subscription = new Subscription();
  accessdeniedMessage: string = '';
  constructor(
    private AthenticationService: AthunticationService,
    private localStorageService: LocalstorageService,
    private router: Router
  ) {}
  loginForm = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
  });
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void { }
  
  onSubmit(): void {
    if (this.loginForm.valid) {
      let AthenticationServiceSubscription = this.AthenticationService.login(
        this.loginForm.value
      ).subscribe({
        next: (response: any) => {
          this.localStorageService.setAuthToken(response.token);
          this.router.navigateByUrl('/app');
        },
        error: (error) => {
          this.accessdeniedMessage = error.error;
        },
      });
      this.subscription.add(AthenticationServiceSubscription);
    }
  }
}
