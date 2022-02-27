import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl: string = 'https://localhost:44318/api/auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http.post('https://localhost:44318/api/auth/Login', model).pipe(
      map((response: any) => {
        const result = response;
        if (result) {
          localStorage.setItem('accessToken', result.data.accessToken);
            
          console.log(this.decodedToken.email);
        }
      })
    );
  }

  register(model: any) {
    return this.http.post(
      'https://localhost:44318/api/user/registerUser',
      model
    );
  }

  loggedIn() {
    const token = localStorage.getItem('accessToken');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
