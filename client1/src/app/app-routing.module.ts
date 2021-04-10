import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Guards/Auth.guard';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MembersDetailsComponent } from './members/members-details/members-details.component';
import { MembersListsComponent } from './members/members-lists/members-lists.component';
import { MessagesComponent } from './messages/messages.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'',
   runGuardsAndResolvers:'always',
   canActivate:[AuthGuard],
   children:
   [
    {path:'member',component:MembersListsComponent},
    {path:'member/:id',component:MembersDetailsComponent},
    {path:'messages',component:MessagesComponent}
   ]
  },
  
  {path:'lists',component:ListsComponent,canActivate:[AuthGuard]},
  
  {path:'**',component:HomeComponent,pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }