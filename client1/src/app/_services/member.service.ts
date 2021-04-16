import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MemberProfile } from '../models/Member';

const httpOptions=
{
  headers:new HttpHeaders 
  ({Authorization:'Bearer '+JSON.parse(localStorage.getItem('user')).token})  
}
@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseurl=environment.MainUrl;
  constructor(private http:HttpClient) { }

  GetMembers()
  {
    return this.http.get<MemberProfile[]>(this.baseurl+"Member",httpOptions);
  }
  
  GettMembers(username:string)
  {
    return this.http.get<MemberProfile>(environment.MainUrl+"Member/"+username,httpOptions);
  }

}
