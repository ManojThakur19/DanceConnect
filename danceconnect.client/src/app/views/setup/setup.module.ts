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
import { JwtTokenInterceptor } from '../../common/jwt-token.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { InstructorListComponent } from './instructor-list/instructor-list.component';
import { HeaderComponent } from '../../layout/header/header.component';
import { FooterComponent } from '../../layout/footer/footer.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    SetUpComponent,
    UserProfileComponent,
    InstructorProfileComponent,
    UsersGridComponent,
    InstructorGridComponent,
    InstructorListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    SetupRoutingModule,
    UsersComponent,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtTokenInterceptor,
      multi: true
    }
  ]
})
export class SetupModule { }
