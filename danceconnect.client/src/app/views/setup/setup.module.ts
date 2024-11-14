import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SetupRoutingModule } from './setup-routing.module';
import { SetUpComponent } from './set-up.component';
import { UsersComponent } from './users/users.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { InstructorProfileComponent } from './instructor-profile/instructor-profile.component';
import { UsersGridComponent } from './users-grid/users-grid.component';
import { InstructorGridComponent } from './instructor-grid/instructor-grid.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SetUpComponent,
    UserProfileComponent,
    InstructorProfileComponent,
    UsersGridComponent,
    InstructorGridComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SetupRoutingModule,
    UsersComponent
  ]
})
export class SetupModule { }
