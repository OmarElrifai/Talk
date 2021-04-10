import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private https:HttpClient) { }
  users:any;
  register:boolean;
  ngOnInit(): void {
    this.getusers()
  }
  registering()
  {
    this.register = true;
  }

  getusers()
  {
    this.https.get('https://localhost:5001/api/users').subscribe
    (
      users =>{this.users=users}
    )
  }

  cancel(event:boolean)
  {
     this.register=event;
  }

}
