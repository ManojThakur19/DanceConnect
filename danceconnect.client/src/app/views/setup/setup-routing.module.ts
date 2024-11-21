import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SetUpComponent } from './set-up.component';
import { UsersComponent } from './users/users.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { UsersGridComponent } from './users-grid/users-grid.component';
import { InstructorGridComponent } from './instructor-grid/instructor-grid.component';
import { InstructorListComponent } from './instructor-list/instructor-list.component';

const routes: Routes = [
  {
    path: '',
    component: SetUpComponent,
    children: [
      {
        path: 'users',
        component: UsersComponent
      },
      {
        path: 'user-profile',
        component: UserProfileComponent
      },
      {
        path: 'user-grids',
        component: UsersGridComponent
      },
      {
        path: 'instructor-grids',
        component: InstructorGridComponent
      },
      {
        path: 'instructors',
        component: InstructorListComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SetupRoutingModule { }
