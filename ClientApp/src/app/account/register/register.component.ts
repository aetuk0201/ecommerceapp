import { ConstantsService } from './../../core/services/constants.service';
import { Router } from '@angular/router';
import { AccountService } from './../account.service';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AsyncValidatorFn,
} from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { timer, of } from 'rxjs';
import { switchMap, map } from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  errors: string[] = [];

  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private constantsService: ConstantsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      displayName: [null, [Validators.required]],
      email: [
        null,
        [
          Validators.required,
          Validators.pattern(this.constantsService.regexEmail),
        ],
        [this.validateEmailExists()],
      ],
      password: [null, [Validators.required]],
    });
  }

  onSubmit(): void {
    const registerInfo = {
      firstName: this.registerForm.get('firstName').value,
      lastName: this.registerForm.get('lastName').value,
      displayName: this.registerForm.get('displayName').value,
      email: this.registerForm.get('email').value,
      password: this.registerForm.get('password').value,
    };

    this.accountService.register(registerInfo).subscribe(
      (response) => {
        this.router.navigateByUrl('/shop');
      },
      (error) => {
        this.handleError(error);
        this.errors = error.errors;
      }
    );
  }

  validateEmailExists(): AsyncValidatorFn {
    return (control) => {
      return timer(500).pipe(
        switchMap(() => {
          if (!control.value) {
            return of(null);
          }
          return this.accountService.emailExists(control.value).pipe(
            map((response) => {
              return response ? { emailExists: true } : null;
            })
          );
        })
      );
    };
  }

  handleError(error: HttpErrorResponse) {
    console.log(error);
  }
}
