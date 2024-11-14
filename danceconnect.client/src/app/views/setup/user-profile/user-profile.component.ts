import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {
  profileForm: FormGroup;
  profilePreview: string | ArrayBuffer | null = null;
  provinces: string[] = ['Ontario', 'Quebec', 'Nova Scotia', 'New Brunswick', 'Manitoba', 'British Columbia', 'Prince Edward Island', 'Saskatchewan', 'Alberta', 'Newfoundland and Labrador'];

  constructor(private fb: FormBuilder) {
    this.profileForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      gender: ['', Validators.required],
      profilePic: [null, Validators.required],
      fileUpload: [null],
      introVideo: ['', Validators.pattern(/https?:\/\/(www\.)?.+/)],
      street: ['', Validators.required],
      city: ['', Validators.required],
      postalCode: ['', [Validators.required, Validators.pattern(/^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$/)]],
      province: ['', Validators.required],
      dob: ['', Validators.required],
      phone: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]]
    });
  }

  onFileChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.profilePreview = reader.result;
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit() {
    if (this.profileForm.valid) {
      console.log("Form Submitted", this.profileForm.value);
    }
  }

  onCancel() {
    this.profileForm.reset();
    this.profilePreview = null;
  }

}
