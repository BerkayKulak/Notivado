import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [
    './login.component.css',
    './vendor/bootstrap/css/bootstrap.min.css',
    './fonts/font-awesome-4.7.0/css/font-awesome.min.css',
    './fonts/iconic/css/material-design-iconic-font.min.css',
    './vendor/animate/animate.css',
    './vendor/css-hamburgers/hamburgers.min.css',
    './vendor/animsition/css/animsition.min.css',
    './vendor/select2/select2.min.css',
    './vendor/select2/select2.min.css',
    './vendor/daterangepicker/daterangepicker.css',
    './css/util.css',
    './css/main.css',
  ],
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private router: Router) {}

  ngOnInit(): void {}

  login() {
    this.authService.login(this.model).subscribe(
      (next) => {
        console.log('login başarılı');
        this.router.navigate(['/todo']);
      },
      (error) => {
        console.log('Login hatalı');
      }
    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('accessToken');
    console.log('logout');
    this.router.navigate(['/home']);
  }
}
