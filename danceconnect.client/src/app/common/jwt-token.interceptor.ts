import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {
  intercept(req: any, next: any): Observable<HttpEvent<any>> {
    var currentUser = JSON.parse(localStorage.getItem('currentUser') ?? "");
    console.log("User", currentUser);

    if (currentUser && currentUser.token) {
      console.log("User Token", currentUser);
      const cloned = req.clone({
        setHeaders: {
          Authorization: `Bearer ${currentUser.token.value}`
        }
      });
    }
    console.log("Request", req);
    return next.handle(req);
  }
};


//intercept(request: HttpRequest<any>, next: HttpHandler): Observable < HttpEvent < any >> {
//  // add authorization header with jwt token if available
//  let currentUser = this._authService.currentUserValue;
//  if(currentUser && currentUser.token) {
//  request = request.clone({
//    setHeaders: {
//      Authorization: `Bearer ${currentUser.token}`
//    }
//  });
//}

//return next.handle(request);
//    }
