import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GetUsers {

  constructor(private http:HttpClient) { }
  Registerurl="https://localhost:5001/api/"
  GetUsers()
  {
    return this.http.get(this.Registerurl+"users")
  }
  
}
