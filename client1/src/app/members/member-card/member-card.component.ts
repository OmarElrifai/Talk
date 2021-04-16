import { Component, Input, OnInit } from '@angular/core';
import { MemberProfile } from 'src/app/models/Member';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {

  
  @Input() member:MemberProfile;
  constructor() { }

  ngOnInit(): void {
  }

}
