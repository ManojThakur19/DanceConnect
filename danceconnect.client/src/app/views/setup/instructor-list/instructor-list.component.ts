import { Component, OnInit } from '@angular/core';
import { InstructorService } from '../instructor-profile/instructor.service';
import { Instructor, InstructorResponse } from '../instructor-profile/instructor';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-instructor-list',
  templateUrl: './instructor-list.component.html',
  styleUrl: './instructor-list.component.css'
})
export class InstructorListComponent implements OnInit {

  instructors: InstructorResponse[] = [];
  filter = new FormControl('', { nonNullable: true });
  constructor(private _instructorService: InstructorService) { }

  ngOnInit() {
    this._instructorService.getInstructors().subscribe(instrcts => {
      this.instructors = instrcts;
      console.log('INSTRUCTORS', instrcts);
    })
  }
}
