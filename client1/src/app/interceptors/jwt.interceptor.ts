import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpHeaders
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/AccountService';
import { user } from '../models/User';
import { take } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let currentUser: user;

    this.accountService.CurrentUser$.pipe(take(1)).subscribe(response => currentUser = response);
    if (currentUser) {
      request = request.clone({
        setHeaders: 
  {Authorization:`Bearer ${currentUser.Token}`
      }  
      })
    }

    return next.handle(request);
  }
}

