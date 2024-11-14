import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { UrlHelper } from '../../../common/url-helper';
import { User } from '../../../common/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private currentUserSubject: BehaviorSubject<User> = new BehaviorSubject<User>(new User());
  public currentUser: Observable<User>;

  constructor(private http: HttpClient) {
    //this.currentUserSubject = new BehaviorSubject<User>(localStorage.getItem('currentUser') ? JSON.parse(localStorage.getItem('currentUser')) : null);
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(data: any) {
    return this.http.post<any>(`https://localhost:7155/api/auth/login`, data)
      .pipe(map(user => {
        // login successful if there's a jwt token in the response
        if (user && user.token) {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        }

        return user;
      }));
  }
}
