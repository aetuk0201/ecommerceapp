import { CartService } from './../../cart/cart.service';
import { IDeliveryMethod } from './../../shared/models/deliveryMethod';
import { CheckoutService } from './../checkout.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss'],
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkOutForm: FormGroup;
  deliveryMethods: IDeliveryMethod[];

  constructor(
    private checkOutService: CheckoutService,
    private cartService: CartService
  ) {}

  ngOnInit(): void {
    this.checkOutService.getDeliveryMethods().subscribe(
      (dm: IDeliveryMethod[]) => {
        this.deliveryMethods = dm;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.cartService.setShippingPrice(deliveryMethod);
  }
}
