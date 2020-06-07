import { ConstantsService } from './../services/constants.service';
import { environment } from './../../../environments/environment.dev';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss'],
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.baseUrl;
  validationErrors: any;

  constructor(private http: HttpClient, private constatns: ConstantsService) {}

  ngOnInit(): void {}

  get404Error(): void {
    this.http
      .get(this.baseUrl + this.constatns.getProductUrl + '?productId=42')
      .subscribe(
        (response) => {
          console.log(response);
        },
        (error) => {
          console.log(error);
        }
      );
  }

  get500Error(): void {
    this.http.get(this.baseUrl + '/api/buggy/servererror').subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  get400ValidationError(): void {
    this.http
      .get(this.baseUrl + this.constatns.getProductUrl + '?productId=fortytwo')
      .subscribe(
        (response) => {
          console.log(response);
        },
        (error) => {
          console.log(error);
          this.validationErrors = error.errors;
        }
      );
  }

  get400Error(): void {
    this.http.get(this.baseUrl + '/api/buggy/badrequest').subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
