import { ConstantsService } from './../../core/services/constants.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ILoginInfo } from './../../shared/models/loginInfo';
import { AccountService } from './../account.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(
    private accountService: AccountService,
    private constantsService: ConstantsService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.returnUrl =
      this.activatedRoute.snapshot.queryParams.returnUrl || '/shop';
    this.createLoginForm();
  }

  createLoginForm(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.pattern(this.constantsService.regexEmail),
      ]),
      password: new FormControl('', [Validators.required]),
    });
  }

  onSubmit(): void {
    const loginInfo: ILoginInfo = {
      email: this.loginForm.get('email').value,
      password: this.loginForm.get('password').value,
    };

    this.accountService.login(loginInfo).subscribe(
      () => {
        this.router.navigateByUrl(this.returnUrl);
      },
      (error) => {
        this.handleError(error);
      }
    );
  }

  handleError(error: any): void {
    console.log(error);
  }
}
