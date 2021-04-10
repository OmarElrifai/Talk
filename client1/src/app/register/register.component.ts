import { Component, EventEmitter, Input, OnInit ,Output} from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/AccountService';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
 // @Input() usersinputfromhome:any;
  @Output() cancelrequest = new EventEmitter();
  model:any={};

  constructor(private accountservice:AccountService,private toastr:ToastrService) { }
 
  
  ngOnInit(): void {
  }

  submit()
  {
    this.accountservice.register(this.model).subscribe
    (
      respone=>
      {
        this.cancelevent();
      },
      error=>
      {
          this.toastr.error(error.error)
      }
      
    )
  }
   
  cancelevent()
  {
     this.cancelrequest.emit(false);
     
  }


}
