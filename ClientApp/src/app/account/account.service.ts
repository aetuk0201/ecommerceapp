import { IRegisterInfo } from './../shared/models/registerInfo';
import { Router } from '@angular/router';
import { ConstantsService } from './../core/services/constants.service';
import { IAppUser } from './../shared/models/appUser';
import { BehaviorSubject, ReplaySubject, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.dev';
import { map } from 'rxjs/operators';
import { ILoginInfo } from '../shared/models/loginInfo';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<IAppUser>(1);
  currentuser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private constantsService: ConstantsService,
    private router: Router
  ) {}

  // getCurrentUserInfo() {
  //   return this.currentUserSource.value;
  // }

  getCurrentUser(token: string) {
    if (token === null) {
      this.currentUserSource.next(null);
      return of(null);
    }
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http
      .get(this.baseUrl + this.constantsService.getCurrentUserUrl, { headers })
      .pipe(
        map((user: IAppUser) => {
          if (user) {
            localStorage.setItem('token', user.token);
            this.currentUserSource.next(user);
          }
        })
      );
  }

  login(loginDto: ILoginInfo) {
    return this.http
      .post(this.baseUrl + this.constantsService.loginUrl, loginDto)
      .pipe(
        map((user: IAppUser) => {
          if (user) {
            localStorage.setItem('token', user.token);
            this.currentUserSource.next(user);
          }
        })
      );
  }

  register(registerInfo: IRegisterInfo) {
    return this.http
      .post(this.baseUrl + this.constantsService.registerUrl, registerInfo)
      .pipe(
        map((user: IAppUser) => {
          if (user) {
            localStorage.setItem('token', user.token);
            this.currentUserSource.next(user);
          }
        })
      );
  }

  logout(): void {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  emailExists(email: string) {
    return this.http.get(
      this.baseUrl + this.constantsService.emailExistsUrl + '?email=' + email
    );
  }
}
