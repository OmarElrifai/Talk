import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MemberProfile } from 'src/app/models/Member';
import { MemberService } from 'src/app/_services/member.service';
import {NgxGalleryOptions} from '@kolkov/ngx-gallery';
import {NgxGalleryImage} from '@kolkov/ngx-gallery';
import {NgxGalleryAnimation} from '@kolkov/ngx-gallery';
@Component({
  selector: 'app-members-details',
  templateUrl: './members-details.component.html',
  styleUrls: ['./members-details.component.css']
})
export class MembersDetailsComponent implements OnInit {

  constructor(private members:MemberService , private activeroute:ActivatedRoute) { }
  member:MemberProfile;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];


  ngOnInit(): void {
    this.GetMember();
    this.galleryOptions =
    [{
       width:'600px',
       height:'400px',
       imagePercent:100,
       thumbnailsColumns:4,
       imageAnimation:NgxGalleryAnimation.Slide
     },
    ];
    
  }

    getimages()
    {
      const images=[];
      for( const photo of this.member.photos)
      {
         images.push({
           small:photo.url,
           medium:photo.url,
           big:photo.url
         })
      }
      return images
    }
   
   GetMember()
   {
     this.members.GettMembers(this.activeroute.snapshot.paramMap.get('member')).subscribe
     (
       member=>{this.member=member;}
     );
     this.galleryImages=this.getimages()
   }
}
