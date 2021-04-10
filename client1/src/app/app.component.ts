import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { user } from './models/User';
import { AccountService } from './_services/AccountService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'client1';
  
  constructor(private http:HttpClient ,private Accountservice:AccountService){}
  
  ngOnInit() {
  
    
  }
;
  

  
}
