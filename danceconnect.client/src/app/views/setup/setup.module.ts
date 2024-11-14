import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SetupRoutingModule } from './setup-routing.module';
import { SetUpComponent } from './set-up.component';


@NgModule({
  declarations: [
    SetUpComponent,
  ],
  imports: [
    CommonModule,
    SetupRoutingModule
  ]
})
export class SetupModule { }
