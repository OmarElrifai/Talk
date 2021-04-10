import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/AccountService';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private account:AccountService , private toastr:ToastrService) {
    
    
  }
  canActivate(): Observable<boolean> {
    return this.account.CurrentUser$.pipe
    (
      map
      (user=>{
           if(user) return true;
           this.toastr.error("Loggin in order to get access")
      })
    )
  }
  
}
