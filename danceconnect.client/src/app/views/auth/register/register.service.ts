import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { UrlHelper } from '../../../common/url-helper';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private http: HttpClient) {
  }

  register(data: any): Observable<any> {
    //const httpHeaders = new HttpHeaders();
    //httpHeaders.set('Content-Type', 'application/json');

    console.log('REGISTER', data);
    return this.http.post<string>(`${UrlHelper.backEndUrl}/api/auth/registration`, data)
      .pipe(map(res => res as any));
  }
}
