import { Component } from '@angular/core';
import { Register } from './register';
import { RegisterService } from './register.service';
import { Router } from '@angular/router';
import { first } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  formData = new Register();

  isPosting: boolean = false;

  constructor(public _registerService: RegisterService, public router: Router) { }

  register() {
    this._registerService.register(this.formData)
      .pipe(first())
      .subscribe(data => {

        this.router.navigate(['/auth/login']);
      },
        error => {
          this.isPosting = false;
        });
  }
}
