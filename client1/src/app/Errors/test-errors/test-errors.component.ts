import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  Validationerror:string[]=[];
  BaseUrl='https://localhost:5001/api/';
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }

  ServerError()
  {
    this.http.get(this.BaseUrl+'buggy/ServerError').subscribe(
      response=>
      {
        console.log(response)
      },
      error=>
    {
      console.log(error)
    }
    )
  }

  Auth()
  {
    this.http.get(this.BaseUrl+'buggy/Auth').subscribe(
      response=>
      {
        console.log(response)
      },
      error=>
    {
      console.log(error)
    }
    )
  }

  BadRequest()
  {
    this.http.get(this.BaseUrl+'buggy/BadRequest').subscribe(
      response=>
      {
        console.log(response)
      },
      error=>
    {
      console.log(error)
    }
    )
  }
  
  NotFound()
  {
    this.http.get(this.BaseUrl+'buggy/NotFound').subscribe(
      response=>
      {
        console.log(response)
      },
      error=>
    {
      console.log(error)
    }
    )
  }

  ValidationError()
  {
    this.http.post(this.BaseUrl+'Register/register',{}).subscribe(
      response=>
      {
        console.log(response)
      },
      error=>
    {
      console.log(error)
      this.Validationerror=error;
      
    }
    )
  }

  
}
