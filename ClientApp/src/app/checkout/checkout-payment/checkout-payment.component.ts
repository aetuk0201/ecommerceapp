import { Router, NavigationExtras } from '@angular/router';
import { CheckoutService } from './../checkout.service';
import { CartService } from './../../cart/cart.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ICart } from 'src/app/shared/models/cart';
import { IOrder } from 'src/app/shared/models/order';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss'],
})
export class CheckoutPaymentComponent implements OnInit {
  @Input() checkOutForm: FormGroup;

  constructor(
    private cartService: CartService,
    private checkoutService: CheckoutService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  submitOrder() {
    const cart = this.cartService.getCurrentCartValue();
    const orderToCreate = this.getOrderToCreate(cart);

    const address = this.checkOutForm.get('addressForm').value;

    orderToCreate.addressToShip = address;

    this.checkoutService.createOrder(orderToCreate).subscribe(
      (order: IOrder) => {
        console.log('order created succesfully');
        console.log(order);
        this.cartService.deleteCartFromLocalStorage(cart.id);
        const navigationExtras: NavigationExtras = { state: order };
        this.router.navigate(['checkout/success'], navigationExtras);
      },
      (err) => {
        console.log(err);
      }
    );
  }

  private getOrderToCreate(cart: ICart) {
    return {
      cartId: cart.id,
      deliveryMethodId: +this.checkOutForm
        .get('deliveryForm')
        .get('deliveryMethod').value,
      addressToShip: this.checkOutForm.get('addressForm').value,
    };
  }
}
