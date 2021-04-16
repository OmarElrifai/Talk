import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { user } from '../models/User';
import { AccountService } from '../_services/AccountService';
import { GetUsers } from '../_services/GetUsersService';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  
  users:any;
  model:any={} 
  
  constructor
  (
    public accountservice : AccountService, 
    private Users:GetUsers , 
    private route:Router,
    private toastr:ToastrService
  ) { }

  ngOnInit(): void {
    this.setcurrentuser();
    
  }

  //GetUsers()
  //{
    //this.Users.GetUsers().subscribe
   // (
     // response =>
      //{
        // this.users=response
     // },
      //error=>
      //{
       // console.log(error)
     // }
    //)
  //}

  login()
  { 
    this.accountservice.login(this.model).subscribe(
      response => 
      {
        this.route.navigateByUrl("/member")
        
      },
      error =>{
        console.log(error),
        this.toastr.error(error.error)
      }
      )
  }
  loginOut()
  {
    this.accountservice.logOut() ;
    this.route.navigateByUrl("/");
  }
   
  

  setcurrentuser()
  {
    const user:user = JSON.parse(localStorage.getItem('user'));
    this.accountservice.setuserbuffer(user)
  }
}
