import { Component, OnInit } from '@angular/core';
import { MemberProfile } from 'src/app/models/Member';
import { MemberService } from 'src/app/_services/member.service';

@Component({
  selector: 'app-members-lists',
  templateUrl: './members-lists.component.html',
  styleUrls: ['./members-lists.component.css']
})
export class MembersListsComponent implements OnInit {

  constructor(private member:MemberService) { }

  members:MemberProfile[];
  ngOnInit(): void {
    this.getmembers()
  }

  getmembers()
  {
    this.member.GetMembers().subscribe
    (
      response=>{this.members=response}
    )
  }

}
