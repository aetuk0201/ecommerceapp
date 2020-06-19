import { ICartItem } from './../shared/models/cartItem';
import { Observable } from 'rxjs';
import { CartService } from './cart.service';
import { Component, OnInit } from '@angular/core';
import { ICart } from '../shared/models/cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit {
  cart$: Observable<ICart>;

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.cart$ = this.cartService.cart$;
  }

  removeCartItem(item: ICartItem) {
    this.cartService.removeItemFromCart(item);
  }

  incrementItemQuantity(item: ICartItem) {
    this.cartService.incrementItemQuantity(item);
  }

  decrementItemQuantity(item: ICartItem) {
    this.cartService.decrementItemQuantity(item);
  }
}
