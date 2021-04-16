import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import {user} from '../models/User';
import {map} from 'rxjs/operators';
import { stringify } from '@angular/compiler/src/util';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseurl=environment.MainUrl;
  constructor(private https : HttpClient) { }
  private userbuffer = new ReplaySubject<user>(1);
  CurrentUser$ = this.userbuffer.asObservable();

  register(model:any)
  {
    return this.https.post(this.baseurl+'register/register',model).pipe
    (
       map
       (
         (user:user)=>
         {
           if(user)
           {
             localStorage.setItem('user',JSON.stringify(user));
             this.userbuffer.next(user)
           }
         }
       )
    )
  }

  login (model:any)
  {
    return this.https.post(this.baseurl+'register/login',model).pipe
    (
      map((response:user) => 
      {const User = response;
        if(User)
        {localStorage.setItem('user',JSON.stringify(User))
        this.userbuffer.next(User)}
      })

      
    );

  }

  setuserbuffer(user:user)
  {
    this.userbuffer.next(user)
  }
  logOut()
  {
    localStorage.removeItem('user');
    this.userbuffer.next(null);
  }



}
