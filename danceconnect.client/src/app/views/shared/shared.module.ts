import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedRoutingModule } from './shared-routing.module';
import { SharedComponent } from './shared.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    SharedComponent,
    ContactUsComponent
  ],
  imports: [
    CommonModule,
    FormsModule, ReactiveFormsModule,
    SharedRoutingModule
  ]
})
export class SharedModule { }
