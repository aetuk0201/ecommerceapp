import { AccountService } from './../account/account.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { error } from 'protractor';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss'],
})
export class CheckoutComponent implements OnInit {
  @Input() checkOutForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.createCheckOutForm();
    this.getAddressFormValues();
  }

  createCheckOutForm(): void {
    this.checkOutForm = this.fb.group({
      addressForm: this.fb.group({
        firstName: [null, Validators.required],
        lastName: [null, Validators.required],
        addressLine1: [null, Validators.required],
        city: [null, Validators.required],
        state: [null, Validators.required],
        zipCode: [null, Validators.required],
        addressType: [null, Validators.required],
        appUserId: [null, Validators.required],
      }),
      deliveryForm: this.fb.group({
        deliveryMethod: [null, Validators.required],
      }),
      paymentForm: this.fb.group({
        nameOnCard: [null, Validators.required],
      }),
    });
  }

  getAddressFormValues() {
    this.accountService.getUserAddress().subscribe(
      (address) => {
        if (address) {
          console.log(address);
          this.checkOutForm.get('addressForm').patchValue(address);
        }
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
